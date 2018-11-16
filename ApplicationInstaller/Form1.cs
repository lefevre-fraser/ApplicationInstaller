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
    public partial class Form1 : Form, CallBack
    {
        List<string> programName = new List<string>();
        List<string> filePath = new List<string>();
        List<string> silentInstall = new List<string>();
        List<string> silentUninstall = new List<string>();
        bool Skip = false;
        bool Cancel = false;
        string location = "Applications.csv";

        public Form1()
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

            using (var reader = new StreamReader(@location))
            {
                while(!reader.EndOfStream)
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

        }


        //On click, grab any selected items from the first list and move them to the other one.
        private void btnAddQueue_Click(object sender, EventArgs e)
        {
            foreach (int index in selectInstallList.SelectedIndices)
            {
                if (!queueList.Items.Contains(selectInstallList.Items[index]))
                {
                    queueList.Items.Add(selectInstallList.Items[index]);
                }
            }
        }

        private void btnRemoveQueue_Click(object sender, EventArgs e)
        {
            List<int> mylist = (queueList.SelectedIndices.Cast<int>().ToList());
            mylist.Reverse();
            foreach (int index in mylist)
            {
                queueList.Items.RemoveAt(index);
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            //For each of the objects in the queue
            //Call SilentInstall.exe with the correct parameters, and wait until it is finished


            List<string> QueuedItems = queueList.Items.Cast<string>().ToList();
            foreach (string PackageName in QueuedItems)
            {
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

                Thread thread = new Thread(() => {
                    Form2 progress = new Form2(PackageName, true);
                    Application.Run(progress);
                });
                thread.Start();

                int index = programName.IndexOf(PackageName);
                string Arguments = "-p \"" + filePath[index] + "\"";
                Arguments += " -f \"" + silentInstall[index] + "\"";
                Arguments += " -i";

                RunningTask task = new RunningTask();
                task._callBack = this;
                task.Execute(PackageName, Arguments);

                thread.Abort();
            }
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            //For each of the objects in the queue
            //Call SilentInstall.exe with the correct parameters, and wait until it is finished


            List<string> QueuedItems = queueList.Items.Cast<string>().ToList();
            foreach (string PackageName in QueuedItems)
            {
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

                Thread thread = new Thread(() => {
                    Form2 progress = new Form2(PackageName, false);
                    Application.Run(progress);
                });
                thread.Start();

                int index = programName.IndexOf(PackageName);
                string Arguments = "-p \"" + filePath[index] + "\"";
                Arguments += " -f \"" + silentUninstall[index] + "\"";
                Arguments += " -u";

                RunningTask task = new RunningTask();
                task._callBack = this;
                task.Execute(PackageName, Arguments);

                thread.Abort();
            }
        }

        void CallBack.Function(string PackageName, Task task)
        {
            task.Wait();
            queueList.Items.Remove(PackageName);
        }

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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Application Installer v1.0\nWritten by Fraser LeFevre\nand Jeffrey Pearson");
        }

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

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            //Make sure the user has only selected one item
            //If they haven't, warn them instead of doing anything.
            //Make sure the item is not the first item in the list.
            //If all criteria are met, swap the item with the one above it
            if (queueList.SelectedIndices.Count < 1)
                MessageBox.Show("WARNING:\nYou must select an\nitem to use this feature.");
            else if (queueList.SelectedIndices.Count > 1)
                MessageBox.Show("WARNING:\nOnly one program may be\nselected to use this feature.");
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

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            //Make sure the user has only selected one item
            //If they haven't, warn them instead of doing anything.
            //Make sure the item is not the last item in the list.
            //If all criteria are met, swap the item with the one below it
            if (queueList.SelectedIndices.Count < 1)
                MessageBox.Show("WARNING:\nYou must select an\nitem to use this feature.");
            else if (queueList.SelectedIndices.Count > 1)
                MessageBox.Show("WARNING:\nOnly one program may be\nselected to use this feature.");
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
    }
}
