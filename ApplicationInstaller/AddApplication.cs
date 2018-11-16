using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ookii.Dialogs.WinForms;

namespace ApplicationInstaller
{
    public partial class AddApplication : Form
    {
        public CallBack _callBack;
        public AddApplication()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = PkgNameTxtBox.Text.Trim();
            string path = FolderPathTxtBox.Text.Trim();
            string install = InstallProgTxtBox.Text.Trim();
            string uninstall = UninstallProgTxtBox.Text.Trim();
            if (_callBack.Function(name, path, install, uninstall))
                this.Close();
        }

        private void BtnFolderBrowse_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog fd = new VistaFolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string path = fd.SelectedPath;
                FolderPathTxtBox.Text = path;
            }
            
        }
    }
}
