using System;
using System.Collections.Generic;
using System.Text;

namespace NameGenerator
{
    public class LanguageBase
    {
        public string Name { get; set; }
        public string Filename { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public decimal MultiWordProbability { get; set; }
        public List<string> Names { get; set; }
        public string DuplicateLetters { get; set; }
        public Dictionary<string, List<string>> Chains { get; set; }
        public bool IsInitialized { get { return Min > 0; } }

        public LanguageBase()
        {
            Names = new List<string>();
            Min = -1;
            Max = -1;
            MultiWordProbability = -1;
            DuplicateLetters = string.Empty;
        }

        public static LanguageBase UnpackBase(string baseString)
        {
            LanguageBase lBase = new LanguageBase();

            string[] parts = baseString.Split('|');

            if (parts.Length < 6)
            {
                throw new Exception("Invalid file format.  Too few parameters.");
            }

            lBase.Name = parts[0];

            int tempInt = -1;

            if (!int.TryParse(parts[1], out tempInt) || tempInt < 1)
            {
                throw new Exception("Invalid file format.  Invalid Min.");
            }

            lBase.Min = tempInt;

            if (!int.TryParse(parts[2], out tempInt) || tempInt < 1)
            {
                throw new Exception("Invalid file format.  Invalid Max.");
            }

            lBase.Max = tempInt;

            lBase.DuplicateLetters = parts[3];

            decimal tempDec = -1;

            if (!decimal.TryParse(parts[4], out tempDec) || tempDec < 0)
            {
                throw new Exception("Invalid file format.  Invalid Min.");
            }

            lBase.MultiWordProbability = tempDec;

            lBase.Names = new List<string>(parts[5].Split(','));

            for (int i = 0; i < lBase.Names.Count; i++)
            {
                lBase.Names[i] = lBase.Names[i].Trim();
            }

            return lBase;
        }
    }
}
