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

        public ConfirmationBox(string PackageName, string Action) : this()
        {
            this.Continue.Select();
            this.Action.Text = Action;
            this.PackageName.Text = PackageName;

            TimeLeft.Text = "Continuing in: " + (StartTime / 1000) + " seconds";

            time = new Timer();
            time.Interval = Interval;
            time.Tick += new EventHandler(TimeOut);
            time.Start();
        }

        void TimeOut(object sender, EventArgs e)
        {
            LapsedTime += Interval;

            TimeLeft.Text = "Continuing in: " + ((StartTime - LapsedTime) / 1000) + " seconds";

            if (LapsedTime == StartTime)
            {
                _callBack.Function(false, false);
                this.Close();
            }
        }

        private void Skip_Click(object sender, EventArgs e)
        {
            _callBack.Function(true, false);
            this.Close();
        }

        private void Contiue_Click(object sender, EventArgs e)
        {
            _callBack.Function(false, false);
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            _callBack.Function(false, true);
            this.Close();
        }
    }
}
