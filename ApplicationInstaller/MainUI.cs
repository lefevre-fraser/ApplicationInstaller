using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace ApplicationInstaller
{
    
    public partial class MainUI : Form, CallBack
    {
        private Dictionary<string, Program> _programs = new Dictionary<string, Program>();
        private List<List<string>> UndoBranch = new List<List<string>>();
        
        bool _skip = false;
        bool _cancel = false;
        string _location = "AllApplications.csv";

        // default constructor 
        // initialize the UI form
        public MainUI()
        {
            InitializeComponent();
            populateList();
        }

        /*
         * This function will fill the checked list with items from a CSV file
         */
        private void populateList()
        {
            // clear the current lists
            selectInstallList.Items.Clear();
            queueList.Items.Clear();
            _programs.Clear();

            try
            {
                using (var reader = new StreamReader(_location))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        _programs[values[0]] = new Program(values[0], values[1], values[2], values[3]);

                        selectInstallList.Items.Add(values[0]);
                    }

                }

                //Make the window title reflect the current open file
                string fileName = _location.Substring(_location.LastIndexOf('\\') + 1);
                this.Text = "Application Installer - " + fileName;
            } catch (Exception e)
            {
                MessageBox.Show("Unable to open default csv file");
            }

        }

        // Not sarcastic
        private void whatAmIDoingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program is used to \ninstall applications.\nLots of them :)");
        }

        //Basic Information
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Application Installer v1.0\nWritten by Fraser LeFevre\nand Jeffrey Pearson");
        }

        //Gets a file path and calls populate list after saving it
        private void openApplicationFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open a file and save it's path into the location string
            // for use by the populateList() method.
            var fd = new OpenFileDialog();
            fd.Filter = "CSV files (*.csv)|*.csv|All Files (*.*)|*.*";
            if(fd.ShowDialog() == DialogResult.OK)
            {
                _location = fd.FileName;
            }
            populateList();
        }

        

        //Selects all items in the list with focus
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (queueList.ContainsFocus)
            {
                int size = queueList.Items.Count;

                for (int i = 0; i < size; i++)
                {
                    queueList.SetSelected(i, true);
                }
            }
            else if (selectInstallList.ContainsFocus)
            {
                int size = selectInstallList.Items.Count;

                for (int i = 0; i < size; i++)
                {
                    selectInstallList.SetSelected(i, true);
                }
            }
            
        }

        //Do you like undo?
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ensure there is undo information
            if (UndoBranch.Count == 0)
                return;

            // clear the queue as is
            queueList.Items.Clear();

            // insert the items from the last Queue action
            foreach(string pkgName in UndoBranch.Last<List<string>>())
            {
                queueList.Items.Add(pkgName);
            }
            UndoBranch.RemoveAt(UndoBranch.Count - 1);
        }

        /*
         * AddProgram:
         *  Adds a program to the application list
         */
        private void addProgramToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // create an instance of the application wizard and use *this for the callback on complete function.
            ApplicationWizard addApplication = new ApplicationWizard();
            addApplication._callBack = this;
            addApplication.ShowDialog();

            //Update the Form Text
            string fileName = _location.Substring(_location.LastIndexOf('\\') + 1);
            this.Text = "Application Installer - " + fileName;
        }

        /*
         * EditProgram:
         *  Edits programs from the applications list
         */
        private void editProgramsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // colllect the current information
            string OldPackageName = (string)selectInstallList.SelectedItem;
            string path = _programs[OldPackageName]._path;
            string installer = _programs[OldPackageName]._installer;
            string uninstaller = _programs[OldPackageName]._uninstaller;

            // send the information to the application wizard and use *this for the callback function.
            ApplicationWizard editApplication = new ApplicationWizard(OldPackageName, path, installer, uninstaller);
            editApplication._callBack = this;
            editApplication.ShowDialog();

            //Update the Form Text
            string fileName = _location.Substring(_location.LastIndexOf('\\') + 1);
            this.Text = "Application Installer - " + fileName;
        }

        /*
         * Function: Application Wizard
         *  handles the results of the application wizard
         */
        bool CallBack.Function(string OldPackageName, string Name, string Path, string Installer, string Uninstaller)
        {
            // check that an application name was specified
            if (Name == "")
            {
                MessageBox.Show("Must enter an Application Name");
                return false;
            }

            // this is the creation of a new program in the list
            if (OldPackageName == "")
            {
                // if the name exists in the list ask to overwrite it first
                if (_programs.ContainsKey(Name))
                {
                    DialogResult confirm = MessageBox.Show("Program name already exists in program list.\nDo You want to replace it?",
                    "Confirm/Deny", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        _programs[Name] = new Program(Name, Path, Installer, Uninstaller);
                    }
                    else
                    {
                        return false;
                    }
                }
                // otherwise just add it in
                else
                {
                    _programs[Name] = new Program(Name, Path, Installer, Uninstaller);
                }
            }

            // the program is being edited
            else
            {
                // if name did not change just replace the old one
                if (Name == OldPackageName)
                {
                    selectInstallList.Items.Add(Name);
                    selectInstallList.Items.Remove(OldPackageName);
                    _programs[Name] = new Program(Name, Path, Installer, Uninstaller);
                }

                // otherwise check if the new name exists in the list already
                else
                {
                    // if the new name exists in the list ask to overwrite it first
                    if (_programs.ContainsKey(Name))
                    {
                        DialogResult confirm = MessageBox.Show("Program name already exists in program list.\nDo You want to replace it?",
                        "Confirm/Deny", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            _programs.Remove(OldPackageName);
                            _programs[Name] = new Program(Name, Path, Installer, Uninstaller);
                        }
                        else
                        {
                            return false;
                        }
                    }

                    // otherwise just overwrite it
                    else
                    {
                        _programs.Remove(OldPackageName);
                        _programs[Name] = new Program(Name, Path, Installer, Uninstaller);
                    }
                }
            }

            return true;
        }

        /*
         * RemoveProgram:
         *  removes a program from the applications list
         */
        private void removeProgramToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //If no programs are selected, don't do anything 
            if (selectInstallList.SelectedIndices.Count == 0)
                return;

            // itterates through each selected item and removes it if the user says to
            List<string> RemoveItems = selectInstallList.SelectedItems.Cast<string>().ToList();
            foreach (string packageName in RemoveItems)
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete " +
                    packageName + " from the applications list?",
                    "Confirm/Deny", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    _programs.Remove(packageName);
                    selectInstallList.Items.Remove(packageName);

                    //Update the Form Text
                    string fileName = _location.Substring(_location.LastIndexOf('\\') + 1);
                    this.Text = "Application Installer - " + fileName;
                }
            }
        }

        /*
         * Save As Function
         * Saves the current state of the applications list
         * to a selected file, and then saves the file to 
         * the location variable.
         */
        private void saveCurrentConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a SaveFileDialog to save the file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files|*.csv";
            saveFileDialog.Title = "Save Current Application List";
            //saveFileDialog.InitialDirectory = _location.Substring(0, _location.LastIndexOf("\\"));
            saveFileDialog.ShowDialog();

            //Get the dialog result, and make sure a file was selected.
            if(saveFileDialog.FileName != "")
            {
                //Write a CSV file line bby line.
                try
                {
                    //Delete the file if it already exists.
                    //This makes sure we don't append to and make a huge file
                    if (File.Exists(@saveFileDialog.FileName))
                    {
                        File.Delete(@saveFileDialog.FileName);
                    }

                    //Open the file for writing
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(@saveFileDialog.FileName))
                    {
                        foreach (KeyValuePair<string, Program> program in  _programs)
                        {
                            if (program.Value._name != "")
                            {
                                file.WriteLine(program.Value._name + ',' + program.Value._path + ',' + program.Value._installer + ',' + program.Value._uninstaller);
                            }
                        }
                    }

                    //Update the file location locally so we can reference it later
                    _location = saveFileDialog.FileName;

                    //Update the file title
                    string fileName = _location.Substring(_location.LastIndexOf('\\') + 1);
                    this.Text = "Application Installer - " + fileName + " - File Saved";

                } catch (Exception e2)
                {
                    MessageBox.Show("Error writing to file: " + saveFileDialog.FileName);
                }
            }
            
        }

        /*
         * Save Function
         * Saves the current state of the application list
         * to the last opened CSV file
         */
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Write a CSV file line bby line.
            try
            {

                //Delete the file if it already exists.
                //This makes sure we don't append to and make a huge file
                if(File.Exists(_location))
                {
                    File.Delete(_location);
                }

                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(_location))
                {
                    //Write to the file
                    foreach (KeyValuePair<string, Program> program in _programs)
                    {
                        if (program.Value._name != "")
                        {
                            file.WriteLine(program.Value._name + ',' + program.Value._path + ',' + program.Value._installer + ',' + program.Value._uninstaller);
                        }
                    }
                }

                //Update the file title
                string fileName = _location.Substring(_location.LastIndexOf('\\') + 1);
                this.Text = "Application Installer - " + fileName + " - File Saved";
            }
            catch (Exception e2)
            {
                MessageBox.Show("Error writing to file: " + _location);
            }
        }

        //Because sarcasm makes everyone's day better :D
        private void reallyINeedHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("applicationinstaller.sarcasticcomment." + new Random().Next(0,100));
        }
    }
}


