using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface SaveLog
    {
        void Save(Exception error, string App_Name);
    }
}
