using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NameGenerator
{
    public partial class MainForm : Form
    {
        private Dictionary<string, LanguageBase> _languages = new Dictionary<string, LanguageBase>();
        private Dictionary<string, List<string>> _cultures = new Dictionary<string, List<string>>();
        private const string _cultureNone = "<None>";
        private string _cultureDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Cultures");

    public MainForm()
        {
            InitializeComponent();

            LoadLanguages();
            LoadCultures();

            if (_languages.Count == 0)
            {
                MessageBox.Show("No Language Files Found");
            }

            ddlNameType.SelectedIndex = 0;
            btnSaveNames.Enabled = false;
        }

        #region Initialization Methods
        private void LoadLanguages()
        {
            string languageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "User Languages");

            if (!Directory.Exists(languageDirectory))
            {
                Directory.CreateDirectory(languageDirectory);
            }

            string orignalLanguageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Original Azgaar Languages");

            if (!Directory.Exists(languageDirectory))
            {
                Directory.CreateDirectory(orignalLanguageDirectory);
            }

            lbLanguages.Sorted = true;

            string[] languageFiles = Directory.GetFiles(orignalLanguageDirectory);
            foreach (string languageFile in languageFiles)
            {
                LanguageBase lBase = new LanguageBase();

                lBase.Name = Path.GetFileNameWithoutExtension(languageFile);
                lBase.Filename = languageFile;

                _languages.Add(lBase.Name, lBase);
            }

            languageFiles = Directory.GetFiles(languageDirectory);
            foreach (string languageFile in languageFiles)
            {
                LanguageBase lBase = new LanguageBase();

                lBase.Name = Path.GetFileNameWithoutExtension(languageFile);
                lBase.Filename = languageFile;

                if (_languages.ContainsKey(lBase.Name))
                    _languages[lBase.Name] = lBase;
                else
                    _languages.Add(lBase.Name, lBase);
            }

            foreach (LanguageBase lbLanguage in _languages.Values)
            {
                lbLanguages.Items.Add(lbLanguage.Name);
            }
        }

        private void LoadCultures()
        {
            if (!Directory.Exists(_cultureDirectory))
            {
                Directory.CreateDirectory(_cultureDirectory);
            }

            string[] cultureFiles = Directory.GetFiles(_cultureDirectory);
            ddlCultures.Items.Clear();
            ddlCultures.Items.Add(_cultureNone);
            ddlCultures.SelectedIndex = 0;

            foreach (string cultureFile in cultureFiles)
            {
                string cultureName = Path.GetFileNameWithoutExtension(cultureFile);

                _cultures.Add(cultureName, File.ReadAllText(cultureFile).Split(",").ToList());
                ddlCultures.Items.Add(cultureName);
            }             
        }
        #endregion // Initialization Methods

        #region Button Handlers
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            List<string> usedNames = new List<string>();

            lbNames.Items.Clear();
            btnSaveNames.Enabled = false;

            for (int x = 0; x < numNumberToGenerate.Value; x++)
            {
                string randomBase = (string)lbLanguages.CheckedItems[random.Next(0, lbLanguages.CheckedItems.Count)];

                if (!_languages[randomBase].IsInitialized)
                {
                    _languages[randomBase] = LanguageBase.UnpackBase(File.ReadAllText(_languages[randomBase].Filename));
                }

                string name = string.Empty;

                do
                {
                    if (ddlNameType.Text == "State")
                    {
                        name = NameProcessor.GetStateName(_languages[randomBase]);
                    }
                    else
                    {
                        name = NameProcessor.GetBaseName(_languages[randomBase]);
                    }
                } while (usedNames.Contains(name));

                usedNames.Add(name);

                if (chkShowSourceLanguage.Checked)
                {
                    name += $" ({_languages[randomBase].Name})";
                }

                lbNames.Items.Add(name);
            }

            btnSelectAllNames.Enabled = true;
        }

        private void btnSaveCulture_Click(object sender, EventArgs e)
        {
            CultureNameDialog cnd = new CultureNameDialog();            
            cnd.ShowDialog();
            
            if (cnd.DialogResult != DialogResult.OK)
                return;

            string cultureName = cnd.CultureName;
            string cultureFilename = Path.Combine(_cultureDirectory, cultureName + ".txt");

            if (File.Exists(cultureFilename))
            {
                if (MessageBox.Show($"Culture {cultureName} already exists.  Overwrite?", 
                    "File Already Exists", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                File.Delete(cultureFilename);
            }

            List<string> cultureLanguages = new List<string>();
          
            foreach (string language in lbLanguages.CheckedItems)
            {
                cultureLanguages.Add(language);
            }

            if (_cultures.ContainsKey(cultureName))
                _cultures[cultureName] = cultureLanguages;
            else
            {
                _cultures.Add(cultureName, cultureLanguages);

                ddlCultures.Items.Add(cultureName);
                ddlCultures.SelectedItem = cultureName;
            }

            string cultureList = cultureLanguages.Aggregate((i, j) => i + "," + j);
            File.WriteAllText(cultureFilename, cultureList);            
        }

        private void btnSaveNames_Click(object sender, EventArgs e)
        {
            string namesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Names");

            if (!Directory.Exists(namesDirectory))
            {
                Directory.CreateDirectory(namesDirectory);
            }

            string namefile = string.Empty;

            if ((string)ddlCultures.SelectedItem != _cultureNone)
            {
                namefile = (string)ddlCultures.SelectedItem;
            }
            else
            { 
                for (int x = 0; x < 3 && x < lbLanguages.CheckedItems.Count; x++)
                {
                    namefile += (string)lbLanguages.CheckedItems[x];
                }
            }

            namefile += "Names.txt";

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*.txt";
            sfd.InitialDirectory = namesDirectory;
            sfd.FileName = namefile;
            sfd.Title = "Save Names to File";
            
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            string fileName = sfd.FileName;
            List<string> names = new List<string>();

            if (File.Exists(fileName))
            {
                if (MessageBox.Show($"Name file {Path.GetFileName(fileName)} already exists.  Append?",
                    "File Already Exists", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                names.AddRange(File.ReadAllLines(fileName));
            }

            foreach (string name in lbNames.CheckedItems)
            {
                names.Add(name);
            }

            File.WriteAllLines(fileName, names.ToArray());
        }

        private void btnSelectAllLanguages_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < lbNames.Items.Count; x++)
            {
                lbNames.SetItemChecked(x, true);
            }
        }
        private void btnSelectAllNames_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < lbLanguages.Items.Count; x++)
            {
                lbLanguages.SetItemChecked(x, true);
            }
        }

        private void btnSelectNoneLanguages_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < lbLanguages.Items.Count; x++)
            {
                lbLanguages.SetItemChecked(x, false);
            }
        }
        #endregion // Button Handlers

        #region Languages List Box Handlers
        private void lbLanguages_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (ddlCultures.SelectedIndex != 0)
                ddlCultures.SelectedIndex = 0;

            btnGenerate.Enabled = lbLanguages.CheckedItems.Count > 0 || e.NewValue == CheckState.Checked;
        }

        private void lbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbLanguages.ClearSelected();
        }
        #endregion // Languages List Box Handlers

        #region Names List Box Handlers
        private void lbNames_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnSaveNames.Enabled = e.NewValue == CheckState.Checked || lbNames.CheckedItems.Count > 1;
        }
        private void lbNames_MouseClick(object sender, MouseEventArgs e)
        {
            btnSaveNames.Enabled = lbLanguages.CheckedItems.Count > 0;
        }

        private void lbNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbNames.ClearSelected();
        }
        #endregion // Names List Box Handlers

        #region Cultures Drop Down Handlers
        private void ddlCultures_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if ((string)ddlCultures.SelectedItem == string.Empty || (string)ddlCultures.SelectedItem == _cultureNone)
                return;

            List<string> cultureLanguages = _cultures[(string)ddlCultures.SelectedItem];
           
            for (int x = 0; x < lbLanguages.Items.Count; x++)
            {
                lbLanguages.SetItemChecked(x, cultureLanguages.Contains(lbLanguages.Items[x]));
            }
        }
        #endregion // Cultures Drop Down Handlers
    }
}
