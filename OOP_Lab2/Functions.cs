using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP_Lab2
{
    public class Functions
    {
        public static string randomString()
        {
            Random rnd = new Random();
            Char[] pwdChars = new Char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string result = String.Empty;
            for (int i = 0; i < 10; i++)
                result += pwdChars[rnd.Next(0, 25)];
            return result;
        }

        public static bool isString(string str, string where)
        {
            string pattern = @"^[A-Za-zА-Яа-я]+$";
            Match match = Regex.Match(str, pattern);
            if (match.Success)
            {
                return match.Success;
            }
            throw new MyException("Вы ввели не буквенное значение в " + where);
        }

        public static bool isInteger(string str, string where)
        {
            string pattern = "^[0-9]+$";
            Match match = Regex.Match(str, pattern);
            if (match.Success)
            {
                return match.Success;
            }
            throw new MyException("Вы ввели не целое число в " + where);
        }

        public static bool isFloat(string str, string where)
        {
            string pattern = "^[0-9]*[.][0-9]*$";
            Match match = Regex.Match(str, pattern);
            if (match.Success)
            {
                return match.Success;
            }
            throw new MyException("Вы ввели не дробное число в " + where);
        }

    }
}
