using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationInstaller
{
    public delegate void OnPreExecute(object Object);
    public delegate void OnPostExecute(object Object);

    class RunningTask
    {
        public CallBack _callBack;
        public event OnPreExecute _onPreExecute;
        public event OnPostExecute _onPostExecute;

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
                // execute the pre execute method(s)
                _onPreExecute?.Invoke(PackageName);

                // create a commandline process with passed arguments
                Process p = new Process();
                p.StartInfo.FileName = "SilentInstall.exe";
                p.StartInfo.Arguments = Arguments;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.WaitForExit();

                // execute the post execute method(s)
                _onPostExecute?.Invoke(PackageName);
            });
        }
    }
}
