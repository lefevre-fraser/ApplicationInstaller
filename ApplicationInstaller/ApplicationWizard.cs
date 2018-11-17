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
    public partial class ApplicationWizard : Form
    {
        public CallBack _callBack;
        private int _index = -1;
        private bool _edit = false;

        public ApplicationWizard()
        {
            InitializeComponent();
        }

        public ApplicationWizard(int index, string packageName, string path, string install, string uninstall) : this()
        {
            PkgNameTxtBox.Text = packageName;
            FolderPathTxtBox.Text = path;
            InstallProgTxtBox.Text = install;
            UninstallProgTxtBox.Text = uninstall;
            _edit = true;
            _index = index;
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
            if (_callBack.Function(_edit, _index, name, path, install, uninstall))
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

        private void FileBrowse_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();
            fd.Filter = "Batch (*.bat)|*.bat|PowerShell (*.ps1)|*.ps1|Executables (*.exe)|*.exe|Msi's (*.msi)|*.msi|All Files (*.*)|*.*";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                Button button = (Button)sender;
                if (button.Name == "BtnInstallBrowse")
                {
                    string FilePath = fd.FileName;
                    InstallProgTxtBox.Text = FilePath.Substring(FilePath.LastIndexOf('\\') + 1);
                }
                else if (button.Name == "BtnUninstallBrowse")
                {
                    string FilePath = fd.FileName;
                    UninstallProgTxtBox.Text = FilePath.Substring(FilePath.LastIndexOf('\\') + 1);
                }
            }
        }
    }
}
