using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Zero : Exception
    {
        public Zero(string message) : base(message)
        {

        }
    }
}
