using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NameGenerator
{
    public static class NameProcessor
    {
        public static Dictionary<string, List<string>> GetChain(LanguageBase lBase)
        {
            Dictionary<string, List<string>> chains = new Dictionary<string, List<string>>();

            string previousCharacter = string.Empty;

            foreach (string name in lBase.Names)
            {
                string tempName = name.Trim().ToLower();

                Match match = Regex.Match(tempName, @"[^\u0000-\u007F]");
                bool basicCharacters = match.Success;

                string syllable = string.Empty;
                for (int i = -1; i < tempName.Length; i += syllable.Length > 0 ? syllable.Length : 1)
                {
                    syllable = string.Empty;

                    previousCharacter = i > -1 ? tempName[i].ToString() : string.Empty;
                    bool containsVowels = false;

                    for (int c = i + 1; c < tempName.Length && syllable.Length < 5; c++)
                    {
                        char? currentCharacter = tempName[c];
                        char? nextCharacter = c + 1 < tempName.Length ? tempName[c + 1] : (char?)null;

                        syllable += currentCharacter;

                        if (syllable == " " || syllable == "-")
                            break;  // syllable starts with space or hyphen

                        if (nextCharacter == null || nextCharacter == ' ' || nextCharacter == '-')
                            break; // No need to check

                        if (IsVowel(currentCharacter))
                            containsVowels = true;

                        if (currentCharacter == 'y' && nextCharacter == 'e') 
                            continue; // 'ye'
                        
                        if (basicCharacters)
                        { 
                            // English-like
                            if (currentCharacter == 'o' && nextCharacter == 'o') 
                                continue; // 'oo'

                            if (currentCharacter == 'e' && nextCharacter == 'e') 
                                continue; // 'ee'

                            if (currentCharacter == 'a' && nextCharacter == 'e') 
                                continue; // 'ae'

                            if (currentCharacter == 'c' && nextCharacter == 'h') 
                                continue; // 'ch'
                        }

                        if (IsVowel(currentCharacter) && currentCharacter == nextCharacter) 
                            break; // two same vowels in a row

                        if (containsVowels && c + 2 < tempName.Length && IsVowel(tempName[c + 2])) 
                            break; // syllable has vowel and additional vowel is expected soon
                    }

                    if (!chains.ContainsKey(previousCharacter))
                        chains[previousCharacter] = new List<string>();

                    chains[previousCharacter].Add(syllable);
                }
            }

            
            return chains;
        }

        public static string GetBaseName(LanguageBase lBase, int minLen = -1, int maxLen = -1)
        {
            if (minLen < 1)
                minLen = lBase.Min;

            if (maxLen < 1)
                maxLen = lBase.Max;

            Random rand = new Random();

            if (lBase.Chains == null)
                lBase.Chains = GetChain(lBase);

            string name = string.Empty;
            List<string> syllables = lBase.Chains[string.Empty];


            string currentSyllable = syllables[rand.Next(0, syllables.Count())];

            int z = 0;

            for (int i = 0; i < 20; i++)
            {
                z = i;
                if (currentSyllable == "")
                { // end of word
                    if (name.Length < minLen)
                    {
                        currentSyllable = "";
                        name = "";
                        syllables = lBase.Chains[string.Empty];
                    }
                    else
                        break;
                }
                else
                {
                    if (name.Length + currentSyllable.Length > maxLen)
                    {
                        // word too long
                        if (name.Length < minLen)
                            name += currentSyllable;
                        break;
                    }
                    else
                        syllables = lBase.Chains[currentSyllable[currentSyllable.Length - 1].ToString().ToLower()];

                    if (syllables == null)
                        syllables = lBase.Chains[string.Empty];
                }

                name += currentSyllable;
                currentSyllable = syllables[rand.Next(0, syllables.Count() - 1)];
            }

            char? lastCharacter = name.Length > 0 ? name[name.Length - 1] : (char?)null;

            if (lastCharacter == '\'' || lastCharacter == ' ' || lastCharacter == '-')
                name = name.Substring(0, name.Length - 1); // not allow some characters at the end

            Match match = Regex.Match(name, "[^\u0000-\u007f]");
            bool basicCharacters = match.Success;

            string cleanedName = string.Empty;

            for (int i = 0; i < name.Length; i++)
            {
                char c = name[i];

                if (i < name.Length - 2 && c == name[i + 1] && !lBase.DuplicateLetters.Contains(c))
                    continue;

                if (cleanedName.Length == 0)
                {
                    cleanedName += char.ToUpper(c);
                    continue;
                }
                
                if (cleanedName.EndsWith("-") && c == ' ') 
                    continue;

                if (cleanedName.EndsWith(" "))
                {
                    cleanedName += char.ToUpper(c); // capitalize letter after space
                    continue;
                }

                if (cleanedName.EndsWith("-"))
                {
                    cleanedName += char.ToUpper(c); // capitalize letter after space
                    continue;
                }

                if (i < name.Length - 2 && c == 'a' && name[i + 1] == 'e') 
                    continue; // "ae" => "e"


                if (basicCharacters && i + 1 < name.Length && !IsVowel(c) && !IsVowel(name[i - 1]) && !IsVowel(name[i + 1]))
                {
                    continue; // remove consonant between 2 consonants
                }

                if (i + 2 < name.Length && c == name[i + 1] && c == name[i + 2])
                    continue; // remove three same letters in a row

                cleanedName += c;
            }

            string[] nameParts = cleanedName.Split(' ');

            if (nameParts.Where(x => x.Length < 2).Select(x => x).Any())
            {
                bool first = true;

                foreach (string part in nameParts)
                {
                    if (first)
                    {
                        cleanedName += part;
                        first = false;
                    }
                    else
                    {
                        cleanedName += part.ToLower();
                    }
                }
            }

            if (cleanedName.Length < 2)
            {
                cleanedName = lBase.Names[rand.Next(0, lBase.Names.Count() - 1)];
            }

            return cleanedName;

        }

       public static string GetStateName(LanguageBase lBase)
        {
            string name = GetBaseName(lBase);

            // exclude endings inappropriate for states name
            if (name.Contains(" ")) 
                name = name[0].ToString().ToUpper() + name.Replace(" ", "").ToLower().Substring(1); // don't allow multiword state names
            
            if (name.Length > 6 && name.ToLower().EndsWith("berg")) 
                name = name.Substring(0, name.Length -4); // remove -berg for any

            if (name.Length > 5 && name.ToLower().EndsWith("ton"))
                name = name.Substring(0, name.Length - 3); // remove -ton for any

            if (lBase.Name == "Ruthenian" && (name.EndsWith("sk") || name.EndsWith("ev") || name.EndsWith("ov")))
                name = name.Substring(0, name.Length - 2); // remove -sk/-ev/-ov for Ruthenian
            else if (lBase.Name == "Japanese") 
                return IsVowel(name[name.Length - 1]) ? name : name + "u"; // Japanese ends on any vowel or -u
            else if (lBase.Name == "Arabic" && Probability(.4)) 
                name = IsVowel(char.ToLower(name[0])) ? "Al" + name.ToLower() : "Al " + name; // Arabic starts with -Al

            if (lBase.Name != "Fantasy - Human Generic" && lBase.Name.StartsWith("Fantasy - ")) 
                return name; // no suffix for fantasy bases

            // define if suffix should be used
            if (name.Length > 3 && IsVowel(char.ToLower(name[name.Length - 1])))
            {
                if (IsVowel(char.ToLower(name[name.Length - 2])) && Probability(.85))
                    name = name.Substring(0, name.Length - 2); // 85% for vv
                else if (Probability(.7)) 
                    name = name.Substring(0, name.Length - 1); // ~60% for cv
                else return name;
            }
            else if (Probability(.4)) 
                return name; // 60% for cc and vc

            string suffix = "ia"; // standard suffix

            Random rnd = new Random();
            double rndNum = rnd.NextDouble();
            int len = name.Length;

            if (lBase.Name == "Italian" && rndNum < .03 && len < 7) 
                suffix = "terra"; // Italian
            else if ((lBase.Name == "Spanish" || lBase.Name == "Castillian") && rndNum < .03 && len < 7) 
                suffix = "terra"; // Spanish
            else if (lBase.Name == "Portuguese" && rndNum < .03 && len < 7) 
                suffix = "terra"; // Portuguese
            else if (lBase.Name == "French" && rndNum < .03 && len < 7) 
                suffix = "terre"; // French
            else if (lBase.Name == "German" && rndNum < .5 && len < 7) 
                suffix = "land"; // German
            else if (lBase.Name == "English" && rndNum < .4 && len < 7) 
                suffix = "land"; // English
            else if (lBase.Name == "Nordic" && rndNum < .3 && len < 7) 
                suffix = "land"; // Nordic
            else if (lBase.Name == "Fantasy - Human Generic" && rndNum < .1 && len < 7) 
                suffix = "land"; // generic Human
            else if (lBase.Name == "Greek" && rndNum < .1) 
                suffix = "eia"; // Greek
            else if (lBase.Name == "Finnic" && rndNum < .35) 
                suffix = "maa"; // Finnic
            else if (lBase.Name == "Hungarian" && rndNum < .4 && len < 6) 
                suffix = "orszag"; // Hungarian
            else if (lBase.Name == "Turkish" ) 
                suffix = rndNum < .6 ? "stan" : "ya"; // Turkish
            else if (lBase.Name == "Korean" ) 
                suffix = "guk"; // Korean
            else if (lBase.Name == "Chinese" ) 
                suffix = " Guo"; // Chinese
            else if (lBase.Name == "Nahuatl" ) 
                suffix = rndNum < .5 && len < 6 ? "tlan" : "co"; // Nahuatl
            else if (lBase.Name == "Berber"  && rndNum < .8) 
                suffix = "a"; // Berber
            else if (lBase.Name == "Arabic"  && rndNum < .8) 
                suffix = "a"; // Arabic

            return ValidateSuffix(name, suffix);
        }

        public static string ValidateSuffix(string name, string suffix)
        {
            if (name.EndsWith(suffix))
                return name; // no suffix if name already ends with it
            
            char firstChar = suffix[0];

            if (name.EndsWith(firstChar))
                name = name.Substring(0, name.Length - 1); // remove name last letter if it's a suffix first letter
            
            if (IsVowel(firstChar) == IsVowel(name[name.Length - 1]) && IsVowel(firstChar) == IsVowel(name[name.Length - 2]))
                    name = name.Substring(0, name.Length - 1); // remove name last char if 2 last chars are the same type as suffix's 1st
            
            if (name[name.Length - 1] == firstChar)
                name = name.Substring(0, name.Length - 1); // remove name last letter if it's a suffix first letter

            return name + suffix;
        }

        private static bool IsVowel(char? character)
        {
            return character != null && "aeiouyɑ'əøɛœæɶɒɨɪɔɐʊɤɯаоиеёэыуюяàèìòùỳẁȁȅȉȍȕáéíóúýẃőűâêîôûŷŵäëïöüÿẅãẽĩõũỹąęįǫųāēīōūȳăĕĭŏŭǎěǐǒǔȧėȯẏẇạẹịọụỵẉḛḭṵṳ".Contains((char)character);
        }

        private static bool Probability(double odds)
        {
            Random rnd = new Random();
            return rnd.NextDouble() < odds;
        }

    }
}
