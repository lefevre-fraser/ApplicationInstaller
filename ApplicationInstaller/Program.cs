using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInstaller
{
    class Program
    {
        public string _name { get; private set; }
        public string _path { get; private set; }
        public string _installer { get; private set; }
        public string _uninstaller { get; private set; }

        public Program(string name, string path, string installer, string uninstaller)
        {
            _name = name;
            _path = path;
            _installer = installer;
            _uninstaller = uninstaller;
        }
    }
}
