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

        /*
         * Overload Constructor:
         *  for editing applications
         *  takes in current application information
         */
        public ApplicationWizard(int index, string packageName, string path, string install, string uninstall) : this()
        {
            // set fields to application data
            PkgNameTxtBox.Text = packageName;
            FolderPathTxtBox.Text = path;
            InstallProgTxtBox.Text = install;
            UninstallProgTxtBox.Text = uninstall;
            _edit = true;
            _index = index;
        }

        // Cancel Button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // close if process is canceled
            this.Close();
        }

        /*
         * Submit Button:
         *  get field information and call the callback to save the data
         *  close dialog when complete
         */
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = PkgNameTxtBox.Text.Trim();
            string path = FolderPathTxtBox.Text.Trim();
            string install = InstallProgTxtBox.Text.Trim();
            string uninstall = UninstallProgTxtBox.Text.Trim();
            if (_callBack.Function(_edit, _index, name, path, install, uninstall))
                this.Close();
        }

        // Browse Folder Button
        private void BtnFolderBrowse_Click(object sender, EventArgs e)
        {
            // open folder browse diolog
            VistaFolderBrowserDialog fd = new VistaFolderBrowserDialog();

            // insert returned data into form
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string path = fd.SelectedPath;
                FolderPathTxtBox.Text = path;
            }
            
        }

        // Browse File Button
        private void FileBrowse_Click(object sender, EventArgs e)
        {
            // open file browser dialog
            var fd = new OpenFileDialog();
            fd.Filter = "Batch (*.bat)|*.bat|PowerShell (*.ps1)|*.ps1|Executables (*.exe)|*.exe|Msi's (*.msi)|*.msi|All Files (*.*)|*.*";

            // insert returned filename into the form
            if (fd.ShowDialog() == DialogResult.OK)
            {
                Button button = (Button)sender;

                // function called for the install file
                if (button.Name == "BtnInstallBrowse")
                {
                    string FilePath = fd.FileName;
                    InstallProgTxtBox.Text = FilePath.Substring(FilePath.LastIndexOf('\\') + 1);
                }

                // function called for the uninstall file
                else if (button.Name == "BtnUninstallBrowse")
                {
                    string FilePath = fd.FileName;
                    UninstallProgTxtBox.Text = FilePath.Substring(FilePath.LastIndexOf('\\') + 1);
                }
            }
        }
    }
}
