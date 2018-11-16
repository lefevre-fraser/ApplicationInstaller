using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInstaller
{
    public interface CallBack
    {
        void Function(string PackageName, Task task);
        void Function(bool Skip, bool Cancel);
        bool Function(string Name, string Path, string Install, string Uninstall);
    }
}
