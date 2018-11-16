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
            string location = "Applications.csv";
            selectInstallList.SelectionMode = SelectionMode.MultiExtended;
            queueList.SelectionMode = SelectionMode.MultiExtended;
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
    }
}
