namespace ApplicationInstaller
{
    partial class AddApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameLabel = new System.Windows.Forms.Label();
            this.PkgNameTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FolderPathTxtBox = new System.Windows.Forms.TextBox();
            this.BtnFolderBrowse = new System.Windows.Forms.Button();
            this.InstallProgTxtBox = new System.Windows.Forms.TextBox();
            this.LabelIProgram = new System.Windows.Forms.Label();
            this.btnInstallBrowse = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LabelUProgram = new System.Windows.Forms.Label();
            this.UninstallProgTxtBox = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(13, 13);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // PkgNameTxtBox
            // 
            this.PkgNameTxtBox.Location = new System.Drawing.Point(130, 10);
            this.PkgNameTxtBox.Name = "PkgNameTxtBox";
            this.PkgNameTxtBox.Size = new System.Drawing.Size(522, 20);
            this.PkgNameTxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Folder Location";
            // 
            // FolderPathTxtBox
            // 
            this.FolderPathTxtBox.Location = new System.Drawing.Point(130, 50);
            this.FolderPathTxtBox.Name = "FolderPathTxtBox";
            this.FolderPathTxtBox.Size = new System.Drawing.Size(441, 20);
            this.FolderPathTxtBox.TabIndex = 3;
            // 
            // BtnFolderBrowse
            // 
            this.BtnFolderBrowse.Location = new System.Drawing.Point(577, 48);
            this.BtnFolderBrowse.Name = "BtnFolderBrowse";
            this.BtnFolderBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtnFolderBrowse.TabIndex = 4;
            this.BtnFolderBrowse.Text = "Browse...";
            this.BtnFolderBrowse.UseVisualStyleBackColor = true;
            this.BtnFolderBrowse.Click += new System.EventHandler(this.BtnFolderBrowse_Click);
            // 
            // InstallProgTxtBox
            // 
            this.InstallProgTxtBox.Location = new System.Drawing.Point(130, 91);
            this.InstallProgTxtBox.Name = "InstallProgTxtBox";
            this.InstallProgTxtBox.Size = new System.Drawing.Size(441, 20);
            this.InstallProgTxtBox.TabIndex = 5;
            // 
            // LabelIProgram
            // 
            this.LabelIProgram.AutoSize = true;
            this.LabelIProgram.Location = new System.Drawing.Point(12, 94);
            this.LabelIProgram.Name = "LabelIProgram";
            this.LabelIProgram.Size = new System.Drawing.Size(99, 13);
            this.LabelIProgram.TabIndex = 6;
            this.LabelIProgram.Text = "Installation Program";
            // 
            // btnInstallBrowse
            // 
            this.btnInstallBrowse.Location = new System.Drawing.Point(577, 89);
            this.btnInstallBrowse.Name = "btnInstallBrowse";
            this.btnInstallBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnInstallBrowse.TabIndex = 7;
            this.btnInstallBrowse.Text = "Browse...";
            this.btnInstallBrowse.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(577, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LabelUProgram
            // 
            this.LabelUProgram.AutoSize = true;
            this.LabelUProgram.Location = new System.Drawing.Point(12, 134);
            this.LabelUProgram.Name = "LabelUProgram";
            this.LabelUProgram.Size = new System.Drawing.Size(112, 13);
            this.LabelUProgram.TabIndex = 9;
            this.LabelUProgram.Text = "Uninstallation Program";
            // 
            // UninstallProgTxtBox
            // 
            this.UninstallProgTxtBox.Location = new System.Drawing.Point(130, 131);
            this.UninstallProgTxtBox.Name = "UninstallProgTxtBox";
            this.UninstallProgTxtBox.Size = new System.Drawing.Size(441, 20);
            this.UninstallProgTxtBox.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(496, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(577, 173);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // AddApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 205);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LabelUProgram);
            this.Controls.Add(this.UninstallProgTxtBox);
            this.Controls.Add(this.btnInstallBrowse);
            this.Controls.Add(this.LabelIProgram);
            this.Controls.Add(this.InstallProgTxtBox);
            this.Controls.Add(this.BtnFolderBrowse);
            this.Controls.Add(this.FolderPathTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PkgNameTxtBox);
            this.Controls.Add(this.NameLabel);
            this.Name = "AddApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Application Wizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox PkgNameTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FolderPathTxtBox;
        private System.Windows.Forms.Button BtnFolderBrowse;
        private System.Windows.Forms.TextBox InstallProgTxtBox;
        private System.Windows.Forms.Label LabelIProgram;
        private System.Windows.Forms.Button btnInstallBrowse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LabelUProgram;
        private System.Windows.Forms.TextBox UninstallProgTxtBox;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
    }
}