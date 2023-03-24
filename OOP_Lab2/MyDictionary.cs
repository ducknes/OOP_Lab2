using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace OOP_Lab2
{
    class MyDictionary
    {
        private static Dictionary<string, Bank> _dictionary = new Dictionary<string, Bank> { };

        public static event EventHandler objectCreated;
        public static event EventHandler objectDeleted;

        public static bool Add(string key, Bank bank)
        {
            if (_dictionary.ContainsKey(key))
            {
                return false;
            }
            _dictionary.Add(key, bank);
            objectCreated?.Invoke(bank, null);
            return true;
        }

        public static void Remove(string key)
        {
            _dictionary.Remove(key);
            objectDeleted?.Invoke(key, null);
        }

        public static int BankCount()
        {
            return _dictionary.Count();
        }

        public static Dictionary<string, Bank> GetMyDictionary()
        {
            return _dictionary;
        }

        public static Bank FindBankByName(string name)
        {
            return _dictionary[name];
        }

        public static string[] GetKeysList()
        {
            string[] keys = new string[BankCount()];
            int i = 0;
            foreach (var item in  _dictionary)
            {
                keys[i++] = item.Key;
            }

            return keys;
        }

        public static void AddForTest()
        {
            _dictionary.Add(BankCount().ToString(), new Bank());
        }

        public static void Clear()
        {
            _dictionary.Clear();
        }
    }
}
