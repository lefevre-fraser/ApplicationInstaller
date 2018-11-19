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
        List<string> programName = new List<string>();
        List<string> filePath = new List<string>();
        List<string> silentInstall = new List<string>();
        List<string> silentUninstall = new List<string>();
        List<Pair> UndoBranch = new List<Pair>();

        bool Skip = false;
        bool Cancel = false;
        string location = "AllApplications.csv";

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
            selectInstallList.Items.Clear();
            queueList.Items.Clear();
            try
            {
                using (var reader = new StreamReader(@location))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        programName.Add(values[0]);
                        filePath.Add(values[1]);
                        silentInstall.Add(values[2]);
                        silentUninstall.Add(values[3]);
                        selectInstallList.Items.Add(values[0]);
                    }

                }

                //Make the window title reflect the current open file
                string fileName = location.Substring(location.LastIndexOf('\\') + 1);
                this.Text = "Application Installer - " + fileName;
            } catch (Exception e)
            {
                MessageBox.Show("Unable to open default csv file");
            }

        }


        //On click, grab any selected items from the first list and move them to the other one.
        private void btnAddQueue_Click(object sender, EventArgs e)
        {
            UndoBranch.Add(new Pair(true, queueList.Items));
            foreach (int index in selectInstallList.SelectedIndices)
            {
                if (!queueList.Items.Contains(selectInstallList.Items[index]))
                {
                    queueList.Items.Add(selectInstallList.Items[index]);
                }
            }
        }

        //Removes items from the queue
        private void btnRemoveQueue_Click(object sender, EventArgs e)
        {
            UndoBranch.Add(new Pair(false, queueList.Items));
            List<int> mylist = (queueList.SelectedIndices.Cast<int>().ToList());
            mylist.Reverse();
            foreach (int index in mylist)
            {
                queueList.Items.RemoveAt(index);
            }
        }

        /*
         * Install:
         *  Installs all items selected in the queue
         */
        private void btnInstall_Click(object sender, EventArgs e)
        {
            //For each of the objects in the queue
            //Call SilentInstall.exe with the correct parameters, and wait until it is finished
            List<string> QueuedItems = queueList.Items.Cast<string>().ToList();
            foreach (string PackageName in QueuedItems)
            {
                // allow user the chance to skip or cancel the install process
                ConfirmationBox CBox = new ConfirmationBox(PackageName, "Preparing To Install");
                CBox._callBack = this;
                CBox.ShowDialog();
                if (Skip)
                {
                    Skip = false;
                    continue;
                }
                if (Cancel)
                {
                    Cancel = false;
                    break;
                }

                // create a new thread to run the progress bar on
                Thread thread = new Thread(() => {
                    ProgressBarUI progress = new ProgressBarUI(PackageName, true);
                    Application.Run(progress);
                });
                thread.Start();

                // setup arguments for install process
                int index = programName.IndexOf(PackageName);
                string Arguments = "-p \"" + filePath[index] + "\"";
                Arguments += " -f \"" + silentInstall[index] + "\"";
                Arguments += " -i";

                // create the task to install the program
                RunningTask task = new RunningTask();
                task._callBack = this;
                task.Execute(PackageName, Arguments);

                // kill the progress bar
                thread.Abort();
            }
        }

        /*
         * Uninstall:
         *  Uninstalls all items selected in the queue
         */
        private void btnUninstall_Click(object sender, EventArgs e)
        {
            //For each of the objects in the queue
            //Call SilentInstall.exe with the correct parameters, and wait until it is finished
            List<string> QueuedItems = queueList.Items.Cast<string>().ToList();
            foreach (string PackageName in QueuedItems)
            {
                // allow user the chance to skip or cancel the uninstall process
                ConfirmationBox CBox = new ConfirmationBox(PackageName, "Preparing To Uninstall");
                CBox._callBack = this;
                CBox.ShowDialog();
                if (Skip)
                {
                    Skip = false;
                    continue;
                }
                if (Cancel)
                {
                    Cancel = false;
                    break;
                }

                // create a new thread to run the progress bar on
                Thread thread = new Thread(() => {
                    ProgressBarUI progress = new ProgressBarUI(PackageName, false);
                    Application.Run(progress);
                });
                thread.Start();

                // setup arguments for uninstall process
                int index = programName.IndexOf(PackageName);
                string Arguments = "-p \"" + filePath[index] + "\"";
                Arguments += " -f \"" + silentUninstall[index] + "\"";
                Arguments += " -u";

                // create the task to uninstall the program
                RunningTask task = new RunningTask();
                task._callBack = this;
                task.Execute(PackageName, Arguments);

                // kill the progress bar
                thread.Abort();
            }
        }

        // callback to handle the completion of an intsall/uninstall
        void CallBack.Function(string PackageName, Task task)
        {
            task.Wait();
            queueList.Items.Remove(PackageName);
        }

        // callback to handle skiping or canceling of installing/uninstalling programs
        void CallBack.Function(bool Skip, bool Cancel)
        {
            this.Skip = Skip;
            this.Cancel = Cancel;
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
                location = fd.FileName;
            }
            populateList();
        }

        /*
         * MoveUp:
         *  Moves an item up in the queue list
         */
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            //Make sure the user has only selected one item
            //If they haven't, warn them instead of doing anything.
            //Make sure the item is not the first item in the list.
            //If all criteria are met, swap the item with the one above it
            if (queueList.SelectedIndices.Count < 1)
                MessageBox.Show("WARNING:\nYou must select a queued\nitem to use this feature.");
            else if (queueList.SelectedIndices.Count > 1)
                MessageBox.Show("WARNING:\nOnly one queued program may be\nselected to use this feature.");
            else if (queueList.SelectedIndex != 0) //Make sure this isn't the first object before we move it
            {
                int from = queueList.SelectedIndices[0];
                int to = from--; //Get's the one on top of it
                var temp = queueList.Items[to];
                queueList.Items[to] = queueList.Items[from];
                queueList.Items[from] = temp;
                queueList.ClearSelected();
                queueList.SetSelected(from, true);
            }
        }

        /*
         * MoveDown:
         *  Move items down in the queue list
         */
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            //Make sure the user has only selected one item
            //If they haven't, warn them instead of doing anything.
            //Make sure the item is not the last item in the list.
            //If all criteria are met, swap the item with the one below it
            if (queueList.SelectedIndices.Count < 1)
                MessageBox.Show("WARNING:\nYou must select a queued\nitem to use this feature.");
            else if (queueList.SelectedIndices.Count > 1)
                MessageBox.Show("WARNING:\nOnly one queued program may be\nselected to use this feature.");
            else if (queueList.SelectedIndex != queueList.Items.Count - 1) //Make sure this isn't the last object before we move it
            {
                int from = queueList.SelectedIndices[0];
                int to = from++; //Get's the one beneath it
                var temp = queueList.Items[to];
                
                queueList.Items[to] = queueList.Items[from];
                queueList.Items[from] = temp;
                queueList.ClearSelected();
                queueList.SetSelected(from, true);
            }
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
            foreach(string pkgName in UndoBranch.Last<Pair>().QueueList)
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
            string fileName = location.Substring(location.LastIndexOf('\\') + 1);
            this.Text = "Application Installer - " + fileName;
        }

        /*
         * EditProgram:
         *  Edits programs from the applications list
         */
        private void editProgramsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // colllect the current information
            string PackageName = (string)selectInstallList.SelectedItem;
            int index = programName.IndexOf(PackageName);
            string path = filePath[index];
            string install = silentInstall[index];
            string uninstall = silentUninstall[index];

            // send the information to the application wizard and use *this for the callback function.
            ApplicationWizard editApplication = new ApplicationWizard(index, PackageName, path, install, uninstall);
            editApplication._callBack = this;
            editApplication.ShowDialog();

            //Update the Form Text
            string fileName = location.Substring(location.LastIndexOf('\\') + 1);
            this.Text = "Application Installer - " + fileName;
        }

        /*
         * Function: Application Wizard
         *  handles the results of the application wizard
         */
        bool CallBack.Function(bool Edit, int Index, string Name, string Path, string Install, string Uninstall)
        {
            // check that an application name was specified
            if (Name == "")
            {
                MessageBox.Show("Must enter an Application Name");
                return false;
            }

            // ensure the program name is not in the list if we are not editing
            if (this.programName.Contains(Name) && !Edit)
            {
                MessageBox.Show("Application name already in list");
                return false;
            }

            // if not editing, add the items to the list
            if (!Edit)
            {
                selectInstallList.Items.Add(Name);
                this.programName.Add(Name);
                this.filePath.Add(Path);
                this.silentInstall.Add(Install);
                this.silentUninstall.Add(Uninstall);

                return true;
            }

            // replace the old items in the list with the new values from editing
            string OldName = this.programName[Index];
            selectInstallList.Items.Remove(OldName);
            selectInstallList.Items.Add(Name);
            this.programName[Index] = Name;
            this.filePath[Index] = Path;
            this.silentInstall[Index] = Install;
            this.silentUninstall[Index] = Uninstall;

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
                int index = programName.IndexOf(packageName);

                var confirm = MessageBox.Show("Are you sure you want to delete " +
                    packageName + " from the applications list?",
                    "Confirm/Deny", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    programName.RemoveAt(index);
                    filePath.RemoveAt(index);
                    silentInstall.RemoveAt(index);
                    silentUninstall.RemoveAt(index);
                    selectInstallList.Items.Remove(packageName);

                    //Update the Form Text
                    string fileName = location.Substring(location.LastIndexOf('\\') + 1);
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
                        int i = 0;
                        foreach (var name in  programName)
                        {
                            if (name != "")
                            {
                                file.WriteLine(programName[i] + ',' + filePath[i] + ',' + silentInstall[i] + ',' + silentUninstall[i]);
                            }
                            i++;
                        }
                    }

                    //Update the file location locally so we can reference it later
                    location = saveFileDialog.FileName;

                    //Update the file title
                    string fileName = location.Substring(location.LastIndexOf('\\') + 1);
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
                if(File.Exists(@location))
                {
                    File.Delete(@location);
                }

                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@location))
                {
                    //Write to the file
                    int i = 0;
                    foreach (var name in programName)
                    {
                        if (name != "")
                        {
                            file.WriteLine(programName[i] + ',' + filePath[i] + ',' + silentInstall[i] + ',' + silentUninstall[i]);
                        }
                        i++;
                    }
                }

                //Update the file title
                string fileName = location.Substring(location.LastIndexOf('\\') + 1);
                this.Text = "Application Installer - " + fileName + " - File Saved";
            }
            catch (Exception e2)
            {
                MessageBox.Show("Error writing to file: " + location);
            }
        }

        //Because sarcasm makes everyone's day better :D
        private void reallyINeedHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("applicationinstaller.sarcasticcomment." + new Random().Next(0,100));
        }
    }

    /*
     * Pair:
     * Used for undo, hold a bool that
     * tells what action was preformed
     * and a list of the QueueList when
     * that action was made
     */
    class Pair
    {
        public Pair(bool Add, ListBox.ObjectCollection QueueList)
        {
            this.Add = Add;
            this.QueueList = QueueList.Cast<string>().ToList();
        }
        public bool Add;
        public List<string> QueueList;
    }
}


