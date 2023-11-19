using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;



namespace ConsoleApp1
{
    internal class SaveLogJSON : SaveLog
    {
        void SaveLog.Save(Exception error, string App_Name)
        {

            List<string> dates = new List<string>();
            var sb = new StringBuilder();
            var trace = new StackTrace(error, true);
            foreach (var frame in trace.GetFrames())
            {
                sb.Append($"Строка:{frame.GetFileLineNumber()}  ");
                sb.Append($"Столбец:{frame.GetFileColumnNumber()} ");
                sb.Append($"Метод:{frame.GetMethod()}");
            }
            string json = File.ReadAllText("Error.json");
            dates = JsonConvert.DeserializeObject<List<string>>(json);
            if (dates == null)
            {
                dates = new List<string>();
            }
            dates.Add($"{error.Message}\t{DateTime.Now}\t{App_Name}\t{sb}####$$$####");
            using (FileStream fs = new FileStream("Error.json", FileMode.OpenOrCreate))
            {
                System.Text.Json.JsonSerializer.Serialize<List<string>>(fs, dates);
            }
        }
    }
}
