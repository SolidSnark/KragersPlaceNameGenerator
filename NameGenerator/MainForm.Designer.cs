namespace NameGenerator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbLanguages = new System.Windows.Forms.CheckedListBox();
            this.lblSelectLanguages = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.ddlCultures = new System.Windows.Forms.ComboBox();
            this.btnSaveCulture = new System.Windows.Forms.Button();
            this.btnSaveNames = new System.Windows.Forms.Button();
            this.lbNames = new System.Windows.Forms.CheckedListBox();
            this.numNumberToGenerate = new System.Windows.Forms.NumericUpDown();
            this.ddlNameType = new System.Windows.Forms.ComboBox();
            this.lblOrCulture = new System.Windows.Forms.Label();
            this.lblNameType = new System.Windows.Forms.Label();
            this.grpInputSettings = new System.Windows.Forms.GroupBox();
            this.grpOutputSettings = new System.Windows.Forms.GroupBox();
            this.chkShowSourceLanguage = new System.Windows.Forms.CheckBox();
            this.lblNumberToGenerate = new System.Windows.Forms.Label();
            this.lblNames = new System.Windows.Forms.Label();
            this.btnSelectAllNames = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberToGenerate)).BeginInit();
            this.grpInputSettings.SuspendLayout();
            this.grpOutputSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLanguages
            // 
            this.lbLanguages.CheckOnClick = true;
            this.lbLanguages.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbLanguages.FormattingEnabled = true;
            this.lbLanguages.Location = new System.Drawing.Point(22, 51);
            this.lbLanguages.Name = "lbLanguages";
            this.lbLanguages.Size = new System.Drawing.Size(282, 244);
            this.lbLanguages.TabIndex = 0;
            this.lbLanguages.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lbLanguages_ItemCheck);
            this.lbLanguages.SelectedIndexChanged += new System.EventHandler(this.lbLanguages_SelectedIndexChanged);
            // 
            // lblSelectLanguages
            // 
            this.lblSelectLanguages.AutoSize = true;
            this.lblSelectLanguages.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSelectLanguages.Location = new System.Drawing.Point(22, 21);
            this.lblSelectLanguages.Name = "lblSelectLanguages";
            this.lblSelectLanguages.Size = new System.Drawing.Size(162, 25);
            this.lblSelectLanguages.TabIndex = 1;
            this.lblSelectLanguages.Text = "Select Languages:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGenerate.Location = new System.Drawing.Point(362, 478);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 32);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(190, 23);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(51, 25);
            this.btnAll.TabIndex = 3;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnSelectAllLanguages_Click);
            // 
            // btnNone
            // 
            this.btnNone.Location = new System.Drawing.Point(253, 23);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(51, 25);
            this.btnNone.TabIndex = 3;
            this.btnNone.Text = "None";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnSelectNoneLanguages_Click);
            // 
            // ddlCultures
            // 
            this.ddlCultures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCultures.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ddlCultures.FormattingEnabled = true;
            this.ddlCultures.Location = new System.Drawing.Point(131, 354);
            this.ddlCultures.Name = "ddlCultures";
            this.ddlCultures.Size = new System.Drawing.Size(173, 25);
            this.ddlCultures.Sorted = true;
            this.ddlCultures.TabIndex = 4;
            this.ddlCultures.SelectedIndexChanged += new System.EventHandler(this.ddlCultures_SelectedIndexChanged);
            // 
            // btnSaveCulture
            // 
            this.btnSaveCulture.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSaveCulture.Location = new System.Drawing.Point(22, 301);
            this.btnSaveCulture.Name = "btnSaveCulture";
            this.btnSaveCulture.Size = new System.Drawing.Size(189, 32);
            this.btnSaveCulture.TabIndex = 5;
            this.btnSaveCulture.Text = "Save Selection As Culture";
            this.btnSaveCulture.UseVisualStyleBackColor = true;
            this.btnSaveCulture.Click += new System.EventHandler(this.btnSaveCulture_Click);
            // 
            // btnSaveNames
            // 
            this.btnSaveNames.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSaveNames.Location = new System.Drawing.Point(576, 478);
            this.btnSaveNames.Name = "btnSaveNames";
            this.btnSaveNames.Size = new System.Drawing.Size(151, 32);
            this.btnSaveNames.TabIndex = 6;
            this.btnSaveNames.Text = "Save Names to File";
            this.btnSaveNames.UseVisualStyleBackColor = true;
            this.btnSaveNames.Click += new System.EventHandler(this.btnSaveNames_Click);
            // 
            // lbNames
            // 
            this.lbNames.CheckOnClick = true;
            this.lbNames.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbNames.FormattingEnabled = true;
            this.lbNames.Location = new System.Drawing.Point(362, 45);
            this.lbNames.Name = "lbNames";
            this.lbNames.Size = new System.Drawing.Size(365, 424);
            this.lbNames.TabIndex = 0;
            this.lbNames.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lbNames_ItemCheck);
            this.lbNames.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbNames_MouseUp);
            // 
            // numNumberToGenerate
            // 
            this.numNumberToGenerate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numNumberToGenerate.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numNumberToGenerate.Location = new System.Drawing.Point(177, 59);
            this.numNumberToGenerate.Name = "numNumberToGenerate";
            this.numNumberToGenerate.Size = new System.Drawing.Size(150, 25);
            this.numNumberToGenerate.TabIndex = 7;
            this.numNumberToGenerate.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // ddlNameType
            // 
            this.ddlNameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlNameType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ddlNameType.FormattingEnabled = true;
            this.ddlNameType.Items.AddRange(new object[] {
            "City",
            "State"});
            this.ddlNameType.Location = new System.Drawing.Point(177, 19);
            this.ddlNameType.Name = "ddlNameType";
            this.ddlNameType.Size = new System.Drawing.Size(150, 25);
            this.ddlNameType.TabIndex = 8;
            // 
            // lblOrCulture
            // 
            this.lblOrCulture.AutoSize = true;
            this.lblOrCulture.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOrCulture.Location = new System.Drawing.Point(21, 351);
            this.lblOrCulture.Name = "lblOrCulture";
            this.lblOrCulture.Size = new System.Drawing.Size(104, 25);
            this.lblOrCulture.TabIndex = 1;
            this.lblOrCulture.Text = "Or Culture:";
            // 
            // lblNameType
            // 
            this.lblNameType.AutoSize = true;
            this.lblNameType.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNameType.Location = new System.Drawing.Point(6, 19);
            this.lblNameType.Name = "lblNameType";
            this.lblNameType.Size = new System.Drawing.Size(165, 25);
            this.lblNameType.TabIndex = 1;
            this.lblNameType.Text = "Select Name Type:";
            // 
            // grpInputSettings
            // 
            this.grpInputSettings.Controls.Add(this.lblSelectLanguages);
            this.grpInputSettings.Controls.Add(this.lbLanguages);
            this.grpInputSettings.Controls.Add(this.btnAll);
            this.grpInputSettings.Controls.Add(this.lblOrCulture);
            this.grpInputSettings.Controls.Add(this.btnNone);
            this.grpInputSettings.Controls.Add(this.ddlCultures);
            this.grpInputSettings.Controls.Add(this.btnSaveCulture);
            this.grpInputSettings.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpInputSettings.Location = new System.Drawing.Point(12, 17);
            this.grpInputSettings.Name = "grpInputSettings";
            this.grpInputSettings.Size = new System.Drawing.Size(333, 395);
            this.grpInputSettings.TabIndex = 9;
            this.grpInputSettings.TabStop = false;
            this.grpInputSettings.Text = "Input Settings";
            // 
            // grpOutputSettings
            // 
            this.grpOutputSettings.Controls.Add(this.chkShowSourceLanguage);
            this.grpOutputSettings.Controls.Add(this.lblNumberToGenerate);
            this.grpOutputSettings.Controls.Add(this.lblNameType);
            this.grpOutputSettings.Controls.Add(this.numNumberToGenerate);
            this.grpOutputSettings.Controls.Add(this.ddlNameType);
            this.grpOutputSettings.Location = new System.Drawing.Point(12, 418);
            this.grpOutputSettings.Name = "grpOutputSettings";
            this.grpOutputSettings.Size = new System.Drawing.Size(333, 135);
            this.grpOutputSettings.TabIndex = 10;
            this.grpOutputSettings.TabStop = false;
            this.grpOutputSettings.Text = "Output Settings";
            // 
            // chkShowSourceLanguage
            // 
            this.chkShowSourceLanguage.AutoSize = true;
            this.chkShowSourceLanguage.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkShowSourceLanguage.Location = new System.Drawing.Point(64, 95);
            this.chkShowSourceLanguage.Name = "chkShowSourceLanguage";
            this.chkShowSourceLanguage.Size = new System.Drawing.Size(228, 29);
            this.chkShowSourceLanguage.TabIndex = 11;
            this.chkShowSourceLanguage.Text = "Show Source Language";
            this.chkShowSourceLanguage.UseVisualStyleBackColor = true;
            // 
            // lblNumberToGenerate
            // 
            this.lblNumberToGenerate.AutoSize = true;
            this.lblNumberToGenerate.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumberToGenerate.Location = new System.Drawing.Point(38, 59);
            this.lblNumberToGenerate.Name = "lblNumberToGenerate";
            this.lblNumberToGenerate.Size = new System.Drawing.Size(133, 25);
            this.lblNumberToGenerate.TabIndex = 1;
            this.lblNumberToGenerate.Text = "# To Generate:";
            // 
            // lblNames
            // 
            this.lblNames.AutoSize = true;
            this.lblNames.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNames.Location = new System.Drawing.Point(362, 17);
            this.lblNames.Name = "lblNames";
            this.lblNames.Size = new System.Drawing.Size(74, 25);
            this.lblNames.TabIndex = 1;
            this.lblNames.Text = "Names:";
            // 
            // btnSelectAllNames
            // 
            this.btnSelectAllNames.Enabled = false;
            this.btnSelectAllNames.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSelectAllNames.Location = new System.Drawing.Point(478, 478);
            this.btnSelectAllNames.Name = "btnSelectAllNames";
            this.btnSelectAllNames.Size = new System.Drawing.Size(92, 32);
            this.btnSelectAllNames.TabIndex = 3;
            this.btnSelectAllNames.Text = "Select All";
            this.btnSelectAllNames.UseVisualStyleBackColor = true;
            this.btnSelectAllNames.Click += new System.EventHandler(this.btnSelectAllLanguages_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 565);
            this.Controls.Add(this.btnSelectAllNames);
            this.Controls.Add(this.lblNames);
            this.Controls.Add(this.grpOutputSettings);
            this.Controls.Add(this.grpInputSettings);
            this.Controls.Add(this.lbNames);
            this.Controls.Add(this.btnSaveNames);
            this.Controls.Add(this.btnGenerate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Fantasy Place Name Generator";
            ((System.ComponentModel.ISupportInitialize)(this.numNumberToGenerate)).EndInit();
            this.grpInputSettings.ResumeLayout(false);
            this.grpInputSettings.PerformLayout();
            this.grpOutputSettings.ResumeLayout(false);
            this.grpOutputSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lbLanguages;
        private System.Windows.Forms.Label lblSelectLanguages;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.ComboBox ddlCultures;
        private System.Windows.Forms.Button btnSaveCulture;
        private System.Windows.Forms.Button btnSaveNames;
        private System.Windows.Forms.CheckedListBox lbNames;
        private System.Windows.Forms.NumericUpDown numNumberToGenerate;
        private System.Windows.Forms.ComboBox ddlNameType;
        private System.Windows.Forms.Label lblOrCulture;
        private System.Windows.Forms.Label lblNameType;
        private System.Windows.Forms.GroupBox grpInputSettings;
        private System.Windows.Forms.GroupBox grpOutputSettings;
        private System.Windows.Forms.Label lblNumberToGenerate;
        private System.Windows.Forms.Label lblNames;
        private System.Windows.Forms.CheckBox chkShowSourceLanguage;
        private System.Windows.Forms.Button btnSelectAllNames;
    }
}

