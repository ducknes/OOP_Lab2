using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_Lab2
{
    public class MyException : Exception
    {
        public MyException() : base() { }
        public MyException(string message) : base(message) { }

        public static string isString(string str, string where)
        {
            string pattern = @"^[A-Za-zА-Яа-я0-9]+$";
            Match match = Regex.Match(str, pattern);
            if (match.Success)
            {
                return str;
            }
            throw new MyException("Вы ввели не буквенное значение в " + where);
        }

        public static int isInteger(string str, string where)
        {
            string pattern = "^[0-9]+$";
            Match match = Regex.Match(str, pattern);
            if (match.Success)
            {
                return Convert.ToInt32(str);
            }
            throw new MyException("Вы ввели не целое число в " + where);
        }

        public static double isDouble(string str, string where)
        {
            string pattern = "([0-9]*[.])*[0-9]+";
            Match match = Regex.Match(str, pattern);
            if (match.Success)
            {
                str = str.Replace(".", ",");
                return Convert.ToDouble(str);
            }
            throw new MyException("Вы ввели не дробное число в " + where);
        }

        public static int randomPrice()
        {
            Thread.Sleep(20);
            Random rnd = new Random();
            return rnd.Next(1, 100);
        }

    }
}
