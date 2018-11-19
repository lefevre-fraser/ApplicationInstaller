using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationInstaller
{
    public partial class ConfirmationBox : Form
    {
        public CallBack _callBack;
        Timer time;
        int LapsedTime = 0;
        int StartTime = 5000;
        int Interval = 1000;

        public ConfirmationBox()
        {
            InitializeComponent();
        }

        // ConfirmationBox constructor
        public ConfirmationBox(string PackageName, string Action) : this()
        {
            // setup the UI
            this.Continue.Select();
            this.Action.Text = Action;
            this.PackageName.Text = PackageName;

            TimeLeft.Text = "Continuing in: " + (StartTime / 1000) + " seconds";

            // Initiate the timer
            time = new Timer();
            time.Interval = Interval;
            time.Tick += new EventHandler(TimeOut);
            time.Start();
        }

        // timer event
        void TimeOut(object sender, EventArgs e)
        {
            // Update time left in UI
            LapsedTime += Interval;
            TimeLeft.Text = "Continuing in: " + ((StartTime - LapsedTime) / 1000) + " seconds";

            // if time is up close the dialog
            if (LapsedTime == StartTime)
            {
                _callBack.Function(false, false);
                this.Close();
            }
        }

        // Skip Button
        private void Skip_Click(object sender, EventArgs e)
        {
            // skip one installation
            _callBack.Function(true, false);
            this.Close();
        }

        // Continue Button
        private void Contiue_Click(object sender, EventArgs e)
        {
            // continue with the instalations
            _callBack.Function(false, false);
            this.Close();
        }

        // Cancel button
        private void Cancel_Click(object sender, EventArgs e)
        {
            // Cancel the instalations
            _callBack.Function(false, true);
            this.Close();
        }
    }
}
