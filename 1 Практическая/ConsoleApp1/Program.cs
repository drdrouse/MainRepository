using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SaveLog saveLogTXT = new SaveLogText();
            SaveLog saveLogXML = new SaveLogXML();
            SaveLog saveLogJSON = new SaveLogJSON();
            try
            {
                string text;
                double x1;
                double x2;
                string path = "Параметры.txt";
                if (File.Exists(path) == false)
                {
                    throw new FileException("Файла не существует");
                }
                else
                    text = File.ReadAllText(path);
                string[] array = text.Split(' ');
                if (double.TryParse(array[0], out double d) == false
                    || double.TryParse(array[1], out double b) == false
                    || double.TryParse(array[2], out double c) == false)
                {
                    throw new NumberException("В файле записаны не числа");
                }
                if (double.Parse(array[0]) == 0)
                {
                    throw new ZeroNumberException("Это не квадратное уравнение");
                }
                double D = Math.Pow(double.Parse(array[1]), 2) - 4 * double.Parse(array[0]) * double.Parse(array[2]);
                if (D > 0)
                {
                    x1 = (-double.Parse(array[1]) + Math.Sqrt(D))/(2* double.Parse(array[0]));
                    x2 = (-double.Parse(array[1]) - Math.Sqrt(D)) /(2 * double.Parse(array[0]));
                    Console.WriteLine($"Вот корни:\nx1={x1}\nx2={x2}");
                }
                else if (D == 0)
                {
                    throw new Zero("Дискриминант равен нулю");
                }
                else
                {
                    throw new DownZero("Нет корней");
                }
            }
            catch (FileException ex) {
                saveLogTXT.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
                saveLogXML.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
                saveLogJSON.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
            }
            catch (Zero ex) { 
                saveLogTXT.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
                saveLogXML.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
                saveLogJSON.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
            }
            catch (DownZero ex) { 
                saveLogTXT.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
                saveLogXML.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
                saveLogJSON.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
            }
            catch (NumberException ex) { 
                saveLogTXT.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
                saveLogXML.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
                saveLogJSON.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
            }
            catch (ZeroNumberException ex) { 
                saveLogTXT.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
                saveLogXML.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
                saveLogJSON.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
            }
            catch (Exception ex) { 
                saveLogTXT.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
                saveLogXML.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
                saveLogJSON.Save(ex, Assembly.GetExecutingAssembly().GetName().FullName.ToString());
            }
            finally
            {
                Console.WriteLine($"Уравнение решено верно.");
            }
        }
    }  
 
}
