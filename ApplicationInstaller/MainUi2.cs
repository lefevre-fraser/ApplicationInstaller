using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationInstaller
{

    /*
     * This file is for some of the button functionality in the MainUI Form Class
     */
    public partial class MainUI
    {
        Thread _progressBar;
        bool _installing;
        //On click, grab any selected items from the first list and move them to the other one.
        private void btnAddQueue_Click(object sender, EventArgs e)
        {
            UndoBranch.Add(queueList.Items.Cast<string>().ToList());
            foreach (string ProgramName in selectInstallList.SelectedItems)
            {
                if (!queueList.Items.Contains(ProgramName))
                {
                    queueList.Items.Add(ProgramName);
                }
            }
        }

        //Removes items from the queue
        private void btnRemoveQueue_Click(object sender, EventArgs e)
        {
            UndoBranch.Add(queueList.Items.Cast<string>().ToList());
            List<string> ItemsToRemove = queueList.SelectedItems.Cast<string>().ToList();
            foreach (string ProgramName in ItemsToRemove)
            {
                queueList.Items.Remove(ProgramName);
            }
        }

        /*
         * Install:
         *  Installs all items in the queue
         */
        private void btnInstall_Click(object sender, EventArgs e)
        {
            // set action to installing
            _installing = true;

            // exit if no items are in the queue
            if (queueList.Items.Count <= 0)
            {
                return;
            }

            // get the first item from the list
            string ProgramName = (string)queueList.Items[0];

            // allow user the chance to skip or cancel the uninstall process
            ConfirmationBox CBox = new ConfirmationBox(ProgramName, "Preparing To Install");
            CBox._callBack = this;
            CBox.ShowDialog();

            // skip the install of the current program
            if (_skip)
            {
                _skip = false;
                queueList.Items.Remove(ProgramName);
                btnInstall_Click(sender, e);
                return;
            }

            // cancel installation of all programs not yet installed
            if (_cancel)
            {
                _cancel = false;
                return;
            }

            // create a new thread to run the progress bar on
            _progressBar = new Thread(() =>
            {
                ProgressBarUI progress = new ProgressBarUI(ProgramName, _installing);
                Application.Run(progress);
            });
            _progressBar.Start();

            // setup arguments for install process
            string Arguments = "-p \"" + _programs[ProgramName]._path + "\"";
            Arguments += " -f \"" + _programs[ProgramName]._installer + "\"";
            Arguments += " -i";

            // create the task to install the program
            RunningTask task = new RunningTask();
            task._onPostExecute += FinishAction;
            task.Execute(ProgramName, Arguments);
        }

        /*
         * Uninstall:
         *  Uninstalls all items in the queue
         */
        private void btnUninstall_Click(object sender, EventArgs e)
        {
            // set the current action as uninstalling
            _installing = false;

            // exit if there are no items in the queue
            if (queueList.Items.Count <= 0)
            {
                return;
            }

            // get the first item from the list
            string ProgramName = (string) queueList.Items[0];

            // allow user the chance to skip or cancel the uninstall process
            ConfirmationBox CBox = new ConfirmationBox(ProgramName, "Preparing To Uninstall");
            CBox._callBack = this;
            CBox.ShowDialog();

            // if skip go to the next programs
            if (_skip)
            {
                _skip = false;
                queueList.Items.Remove(ProgramName);
                btnUninstall_Click(sender, e);
                return;
            }

            // if cancel then terminate program
            if (_cancel)
            {
                _cancel = false;
                return;
            }

            // create a new thread to run the progress bar on
            _progressBar = new Thread(() => {
                ProgressBarUI progress = new ProgressBarUI(ProgramName, _installing);
                Application.Run(progress);
            });
            _progressBar.Start();

            // setup arguments for uninstall process
            string Arguments = "-p \"" + _programs[ProgramName]._path + "\"";
            Arguments += " -f \"" + _programs[ProgramName]._uninstaller + "\"";
            Arguments += " -u";

            // create the task to uninstall the program
            RunningTask task = new RunningTask();
            task._onPostExecute += FinishAction;
            task.Execute(ProgramName, Arguments);
        }

        // callback to handle skiping or canceling of installing/uninstalling programs
        void CallBack.Function(bool Skip, bool Cancel)
        {
            this._skip = Skip;
            this._cancel = Cancel;
        }

        /*
         * Finish Action
         * takes care of removing the package name from the list
         * and destroying the progress bar thread
         */
        public void FinishAction(object Object)
        {
            // invoke these commands on the main ui thread
            this.BeginInvoke((MethodInvoker)delegate
            {
                // remove the package name from the queue list
                queueList.Items.Remove((string) Object);

                // destroy the progress bar
                try
                {
                    _progressBar.Abort();
                } catch(System.Threading.ThreadAbortException error)
                {
                    // don't care
                }

                // start the next action if there is anything left in the queue
                if (_installing)
                {
                    btnInstall_Click(null, null);
                }
                else
                {
                    btnUninstall_Click(null, null);
                }
            });
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
                // add an undo point
                UndoBranch.Add(queueList.Items.Cast<string>().ToList());

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
                // add an undo point
                UndoBranch.Add(queueList.Items.Cast<string>().ToList());

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
