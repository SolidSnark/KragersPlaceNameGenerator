using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NameGenerator
{    
    public partial class CultureNameDialog : Form
    {
        public string CultureName { get; set; }

        public CultureNameDialog()
        {
            InitializeComponent();
        }

        private void txtCultureName_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = txtCultureName.Text.Length > 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CultureName = txtCultureName.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
