using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ZeroNumberException : Exception
    {
        public ZeroNumberException(string message) : base(message)
        {

        }
    }
}
