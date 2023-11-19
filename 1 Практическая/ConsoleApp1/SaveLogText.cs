using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SaveLogText : SaveLog
    {
        void SaveLog.Save(Exception error, string App_Name)
        {
            StackTrace traceLog = new StackTrace();
            var sb = new StringBuilder();
            var trace = new StackTrace(error, true);
            foreach (var frame in trace.GetFrames())
            {
                sb.Append($"Строка:{frame.GetFileLineNumber()}  ");
                sb.Append($"Столбец:{frame.GetFileColumnNumber()} ");
                sb.Append($"Метод:{frame.GetMethod()}");
            }
            using (StreamWriter writer = new StreamWriter("Error.txt", true))
            {
                writer.Write($"{error.Message}\t{DateTime.Now}\t{App_Name}\t{sb}####$$$#### ");
            }

        }
    }
}
