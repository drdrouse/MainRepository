using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                string text;
                double x1;
                double x2;
                string path = "D:\\Учёба\\Предметы\\Тестирование и отладка программного обеспечения\\Параметры.txt";
                if (File.Exists(path) == false)
                {
                    throw new FileException("Ты чё дурак, такого файла нет!!!");
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
            catch (FileException ex) { Console.WriteLine(ex.Message); }
            catch (Zero ex) { Console.WriteLine(ex.Message); }
            catch (DownZero ex) { Console.WriteLine(ex.Message); }
            catch (NumberException ex) { Console.WriteLine(ex.Message); }
            catch (ZeroNumberException ex) { Console.WriteLine(ex.Message); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                Console.WriteLine($"Уравнение решено верно.");
            }
        }
    }

    class NumberException : Exception
    {
        public NumberException(string message) : base(message)
        {

        }
    }
    class ZeroNumberException : Exception
    {
        public ZeroNumberException(string message) : base(message)
        {

        }
    }
    class FileException : Exception
    {
        public FileException(string message) : base(message)
        {

        }
    }

    class Zero : Exception
    {
        public Zero(string message) : base(message)
        {

        }
    }

    class DownZero : Exception
    {
        public DownZero(string message) : base(message)
        {

        }
    }
}
