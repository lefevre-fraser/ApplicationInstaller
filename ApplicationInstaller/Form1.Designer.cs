namespace ApplicationInstaller
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queueList = new System.Windows.Forms.ListBox();
            this.selectInstallList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddQueue = new System.Windows.Forms.Button();
            this.btnRemoveQueue = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnuninstall = new System.Windows.Forms.Button();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openApplicationFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whatAmIDoingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(737, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openApplicationFileToolStripMenuItem,
            this.saveCurrentConfigurationToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProgramToolStripMenuItem,
            this.removeProgramToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whatAmIDoingToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // queueList
            // 
            this.queueList.FormattingEnabled = true;
            this.queueList.Location = new System.Drawing.Point(330, 51);
            this.queueList.Name = "queueList";
            this.queueList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.queueList.Size = new System.Drawing.Size(287, 381);
            this.queueList.TabIndex = 3;
            // 
            // selectInstallList
            // 
            this.selectInstallList.FormattingEnabled = true;
            this.selectInstallList.Location = new System.Drawing.Point(13, 51);
            this.selectInstallList.Name = "selectInstallList";
            this.selectInstallList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.selectInstallList.Size = new System.Drawing.Size(292, 381);
            this.selectInstallList.Sorted = true;
            this.selectInstallList.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Available Applications";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Queued Applications";
            // 
            // btnAddQueue
            // 
            this.btnAddQueue.Location = new System.Drawing.Point(642, 62);
            this.btnAddQueue.Name = "btnAddQueue";
            this.btnAddQueue.Size = new System.Drawing.Size(75, 67);
            this.btnAddQueue.TabIndex = 8;
            this.btnAddQueue.Text = "Add to Queue";
            this.btnAddQueue.UseVisualStyleBackColor = true;
            this.btnAddQueue.Click += new System.EventHandler(this.btnAddQueue_Click);
            // 
            // btnRemoveQueue
            // 
            this.btnRemoveQueue.Location = new System.Drawing.Point(642, 135);
            this.btnRemoveQueue.Name = "btnRemoveQueue";
            this.btnRemoveQueue.Size = new System.Drawing.Size(75, 67);
            this.btnRemoveQueue.TabIndex = 9;
            this.btnRemoveQueue.Text = "Remove From Queue";
            this.btnRemoveQueue.UseVisualStyleBackColor = true;
            this.btnRemoveQueue.Click += new System.EventHandler(this.btnRemoveQueue_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(642, 208);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(75, 67);
            this.btnInstall.TabIndex = 10;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnuninstall
            // 
            this.btnuninstall.Location = new System.Drawing.Point(642, 281);
            this.btnuninstall.Name = "btnuninstall";
            this.btnuninstall.Size = new System.Drawing.Size(75, 67);
            this.btnuninstall.TabIndex = 11;
            this.btnuninstall.Text = "Uninstall";
            this.btnuninstall.UseVisualStyleBackColor = true;
            this.btnuninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openApplicationFileToolStripMenuItem
            // 
            this.openApplicationFileToolStripMenuItem.Name = "openApplicationFileToolStripMenuItem";
            this.openApplicationFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openApplicationFileToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.openApplicationFileToolStripMenuItem.Text = "Open Application File";
            this.openApplicationFileToolStripMenuItem.Click += new System.EventHandler(this.openApplicationFileToolStripMenuItem_Click);
            // 
            // addProgramToolStripMenuItem
            // 
            this.addProgramToolStripMenuItem.Name = "addProgramToolStripMenuItem";
            this.addProgramToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.addProgramToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.addProgramToolStripMenuItem.Text = "Add Program";
            // 
            // removeProgramToolStripMenuItem
            // 
            this.removeProgramToolStripMenuItem.Name = "removeProgramToolStripMenuItem";
            this.removeProgramToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.removeProgramToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.removeProgramToolStripMenuItem.Text = "Remove Program";
            // 
            // whatAmIDoingToolStripMenuItem
            // 
            this.whatAmIDoingToolStripMenuItem.Name = "whatAmIDoingToolStripMenuItem";
            this.whatAmIDoingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.whatAmIDoingToolStripMenuItem.Text = "What am I doing?";
            this.whatAmIDoingToolStripMenuItem.Click += new System.EventHandler(this.whatAmIDoingToolStripMenuItem_Click);
            // 
            // saveCurrentConfigurationToolStripMenuItem
            // 
            this.saveCurrentConfigurationToolStripMenuItem.Name = "saveCurrentConfigurationToolStripMenuItem";
            this.saveCurrentConfigurationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveCurrentConfigurationToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.saveCurrentConfigurationToolStripMenuItem.Text = "Save Current Configuration";
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(642, 354);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 28);
            this.btnMoveUp.TabIndex = 12;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(642, 388);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(75, 28);
            this.btnMoveDown.TabIndex = 13;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 450);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnuninstall);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnRemoveQueue);
            this.Controls.Add(this.btnAddQueue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectInstallList);
            this.Controls.Add(this.queueList);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Installer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ListBox queueList;
        private System.Windows.Forms.ListBox selectInstallList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddQueue;
        private System.Windows.Forms.Button btnRemoveQueue;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnuninstall;
        private System.Windows.Forms.ToolStripMenuItem openApplicationFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whatAmIDoingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentConfigurationToolStripMenuItem;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
    }
}

