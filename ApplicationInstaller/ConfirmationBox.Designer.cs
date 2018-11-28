namespace ApplicationInstaller
{
    partial class ConfirmationBox
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
            this.Action = new System.Windows.Forms.Label();
            this.PackageName = new System.Windows.Forms.Label();
            this.Skip = new System.Windows.Forms.Button();
            this.Continue = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.TimeLeft = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Action
            // 
            this.Action.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Action.Location = new System.Drawing.Point(12, 9);
            this.Action.Name = "Action";
            this.Action.Size = new System.Drawing.Size(447, 30);
            this.Action.TabIndex = 0;
            this.Action.Text = "Action";
            this.Action.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PackageName
            // 
            this.PackageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PackageName.Location = new System.Drawing.Point(12, 39);
            this.PackageName.Name = "PackageName";
            this.PackageName.Size = new System.Drawing.Size(447, 36);
            this.PackageName.TabIndex = 1;
            this.PackageName.Text = "PackageName";
            this.PackageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Skip
            // 
            this.Skip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Skip.Location = new System.Drawing.Point(74, 120);
            this.Skip.Name = "Skip";
            this.Skip.Size = new System.Drawing.Size(98, 38);
            this.Skip.TabIndex = 2;
            this.Skip.Text = "Skip";
            this.Skip.UseVisualStyleBackColor = true;
            this.Skip.Click += new System.EventHandler(this.Skip_Click);
            // 
            // Continue
            // 
            this.Continue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Continue.Location = new System.Drawing.Point(178, 120);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(114, 38);
            this.Continue.TabIndex = 3;
            this.Continue.Text = "Continue";
            this.Continue.UseVisualStyleBackColor = true;
            this.Continue.Click += new System.EventHandler(this.Contiue_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.Location = new System.Drawing.Point(298, 120);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(98, 38);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // TimeLeft
            // 
            this.TimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLeft.Location = new System.Drawing.Point(12, 84);
            this.TimeLeft.Name = "TimeLeft";
            this.TimeLeft.Size = new System.Drawing.Size(447, 33);
            this.TimeLeft.TabIndex = 5;
            this.TimeLeft.Text = "TimeLeft";
            this.TimeLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfirmationBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 170);
            this.ControlBox = false;
            this.Controls.Add(this.TimeLeft);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Continue);
            this.Controls.Add(this.Skip);
            this.Controls.Add(this.PackageName);
            this.Controls.Add(this.Action);
            this.MaximumSize = new System.Drawing.Size(487, 209);
            this.MinimumSize = new System.Drawing.Size(487, 209);
            this.Name = "ConfirmationBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Installer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Action;
        private System.Windows.Forms.Label PackageName;
        private System.Windows.Forms.Button Skip;
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label TimeLeft;
    }
}