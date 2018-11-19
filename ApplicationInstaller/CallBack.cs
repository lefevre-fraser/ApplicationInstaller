using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInstaller
{
    public interface CallBack
    {
        // function for install/uninstall complete
        void Function(string PackageName, Task task);

        // function for skip or cancel install/uninstall process
        void Function(bool Skip, bool Cancel);

        // application wizard oncomplete function
        bool Function(bool Edit, int Index, string Name, string Path, string Install, string Uninstall);
    }
}
