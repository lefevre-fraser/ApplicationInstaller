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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string PackageName, bool install) : this()
        {
            ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            ProgressBar.MarqueeAnimationSpeed = 50;
            ProgramName.Text = PackageName;

            if (install)
            {
                Action.Text = "Now Installing";
            }
            else
            {
                Action.Text = "Now Uninstalling";
            }
        }
    }
}
