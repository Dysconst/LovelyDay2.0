using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBD
{
    interface IShell
    {
        ShellType myType { get; }
        void WriteStream(string someData);
    }
}
