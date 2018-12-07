using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInstaller
{
    public interface CallBack
    {
        // function for skip or cancel install/uninstall process
        void Function(bool Skip, bool Cancel);

        // application wizard oncomplete function
        bool Function(string OldPackageName, string Name, string Path, string Install, string Uninstall);
    }
}
