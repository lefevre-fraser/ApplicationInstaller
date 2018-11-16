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

        public void Execute(string PackageName, string Arguments)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                Process p = new Process();
                p.StartInfo.FileName = "SilentInstall.exe";
                p.StartInfo.Arguments = Arguments;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.WaitForExit();
            });

            _callBack.Function(PackageName, task);
        }
    }
}
