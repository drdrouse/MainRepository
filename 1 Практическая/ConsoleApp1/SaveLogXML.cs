using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class SaveLogXML : SaveLog
    {
        void SaveLog.Save(Exception error, string App_Name)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
            var sb = new StringBuilder();
            List<string> date = new List<string>();
            var trace = new StackTrace(error, true);
            foreach (var frame in trace.GetFrames())
            {
                sb.Append($"Строка:{frame.GetFileLineNumber()}  ");
                sb.Append($"Столбец:{frame.GetFileColumnNumber()} ");
                sb.Append($"Метод:{frame.GetMethod()}");
            }
            try
            {
                using (FileStream fs = new FileStream("Error.xml", FileMode.OpenOrCreate))
                {
                    date = xmlSerializer.Deserialize(fs) as List<string>;
                }
            }
            catch (Exception ex)
            {
            }
            date.Add($"{error.Message}\t{DateTime.Now}\t{App_Name}\t{sb}");
            using (FileStream fs = new FileStream("Error.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, date);
            }
        }
    }
}
