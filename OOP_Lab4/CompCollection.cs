using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Lab2
{
    /// <summary>
    /// Класс-коллекция экземпляров
    /// </summary>
    internal class CompCollection
    {

        public delegate void Handler(string message);
        public delegate void EditHandler(string type, string value);

        public static event Handler createComp;
        public static event Handler deleteComp;
        public static event Handler findComp;
        public static event EditHandler editComp;
        public static event EditHandler printCompField;

        private static List<Computer> compCollection = new List<Computer>(); //база компьютеров
        private static int computerCount = 0;



        /// <summary>
        /// Добавление компьютера в базу
        /// </summary>
        /// <param name="comp"></param>
        public static void add(Computer comp)
        {
            createComp?.Invoke($"Добавлен компьютер с ID:{comp.ComputerID}");
            compCollection.Add(comp);
        }

        /// <summary>
        /// Удаление компьютера из базы
        /// </summary>
        /// <param name="ID"></param>
        public static void remove(string localID)
        {
            foreach (Computer computer in compCollection)
            {

                if (computer.ComputerID == localID)
                {
                    deleteComp?.Invoke($"Удален компьютер с ID:{localID}");
                    compCollection.Remove(computer);
                    return;
                }
            }
            deleteComp?.Invoke($"Данного компьютера нет в базе");
            return;
        }

        /// <summary>
        /// Поиск компьютера в базе
        /// </summary>
        /// <param name="localID"></param>
        /// <returns></returns>
        public static Computer find(string localID)
        {
            foreach (Computer computer in compCollection)
            {
                if (computer.ComputerID == localID)
                {
                    return computer;
                }
            }
            findComp?.Invoke($"Такого компьютера нет в базе");
            return null;
        }

        /// <summary>
        /// Вывод базы 
        /// </summary>
        /// <returns></returns>
        public static string print()
        {
            String compStr = "Пока что не добавлено ни одного компьютера";

            if (compCollection.Count != 0)
            {
                compStr = "";
                foreach (Computer computer in compCollection)
                {
                    compStr += computer.ComputerID + " ";
                }
            }
            return compStr;
        }

        /// <summary>
        /// Получить число компьютеров в базе
        /// </summary>
        /// <returns></returns>
        public static int getComputerCount()
        {
            computerCount = compCollection.Count;
            return computerCount;
        }

        /// <summary>
        /// Изменить поле выбранного компьютера
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="newField"></param>
        public static void editField(Computer computer, string fieldType, string newField)
        {
            string eventFieldType = "";

            switch (fieldType)
            {
                case "ProcessorType":
                    computer.ProcessorType = newField;
                    eventFieldType = "тип процессора";
                    break;
                case "ProcessorFrequency":
                    computer.ProcessorFrequency = Convert.ToDouble(newField);
                    eventFieldType = "частота процессора";
                    break;
                case "MemoryCapacity":
                    computer.MemoryCapacity = Convert.ToInt32(newField);
                    eventFieldType = "объем озу";
                    break;
                case "ComputerCost":
                    computer.ComputerCost = Convert.ToInt32(newField);
                    eventFieldType = "цена";
                    break;
                case "VideoCard":
                    computer.VideoCard = newField;
                    eventFieldType = "тип видеокарты";
                    break;
                case "VideoCapacity":
                    computer.VideoCapacity = Convert.ToInt32(newField);
                    eventFieldType = "объем видеопамяти";
                    break;
                case "PowerUnit":
                    computer.PowerUnit = Convert.ToInt32(newField);
                    eventFieldType = "мощность БП";
                    break;
                default:
                    break;
            }
            editComp?.Invoke(eventFieldType, newField);
        }

        /// <summary>
        /// Вывести поле выбранного компьютера
        /// </summary>
        /// <param name="computer"></param>
        /// <param name="newField"></param>
        public static void printField(Computer computer, string fieldType)
        {
            string eventFieldType = "";
            string localField = "";

            switch (fieldType)
            {
                case "ProcessorType":
                    localField = computer.ProcessorType;
                    eventFieldType = "тип процессора";
                    break;
                case "ProcessorFrequency":
                    localField = computer.ProcessorFrequency.ToString();
                    eventFieldType = "частота процессора";
                    break;
                case "MemoryCapacity":
                    localField = computer.MemoryCapacity.ToString();
                    eventFieldType = "объем озу";
                    break;
                case "ComputerCost":
                    localField = computer.ComputerCost.ToString();
                    eventFieldType = "цена";
                    break;
                case "VideoCard":
                    localField = computer.VideoCard;
                    eventFieldType = "тип видеокарты";
                    break;
                case "VideoCapacity":
                    localField = computer.VideoCapacity.ToString();
                    eventFieldType = "объем видеопамяти";
                    break;
                case "PowerUnit":
                    localField = computer.PowerUnit.ToString();
                    eventFieldType = "мощность БП";
                    break;
                default:
                    break;      
            }
            printCompField?.Invoke(eventFieldType, localField);
        }

        /// <summary>
        /// Стресс тест коллекции
        /// </summary>
        /// <returns></returns>
        public static int[] stressTest()
        {
            compCollection.Clear();

            int[] results = new int[3];
            Computer.compNumber = 0;
            int StartTime = Environment.TickCount;
            for (int i = 0; i < 100000; i++)
            {
                Computer localComp = new Computer();
                compCollection.Add(localComp);
            }
            results[0] = Environment.TickCount - StartTime;

            int StartTime2 = Environment.TickCount;
            List<Computer> stressTestList = new List<Computer>();
            for (int i = 0; i < compCollection.Count; i++)
            {
                stressTestList.Add(compCollection[i]);     
            }
            results[1] = Environment.TickCount - StartTime2;

            stressTestList.Clear();
            List<int> randomNumbers = new List<int>();
            Random random = new Random();

            int StartTime3 = Environment.TickCount;
            for (int i = 0; i < 100000; i++)
            {
                int newNumber = random.Next(0, 100000);
                stressTestList.Add(compCollection[newNumber]);
            }
            results[2] = Environment.TickCount - StartTime3;

            compCollection.Clear();

            return results;
        }
    }
}
