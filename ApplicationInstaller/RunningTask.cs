using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationInstaller
{
    class RunningTask
    {
        public CallBack _callBack;

        public RunningTask()
        {
            
        }

        /*
         * Execute:
         *  Executes an installer or uninstaller
         */
        public void Execute(string PackageName, string Arguments)
        {
            // create a new task so that UI does not "hang"
            Task task = Task.Factory.StartNew(() =>
            {
                // create a commandline process with passed arguments
                Process p = new Process();
                p.StartInfo.FileName = "SilentInstall.exe";
                p.StartInfo.Arguments = Arguments;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.WaitForExit();
            });

            // on process complete.
            _callBack.Function(PackageName, task);
        }
    }
}
