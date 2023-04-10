using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2
{
    public class Computer : IComparable<Computer>
    {
        private String computerID;                    //id компьютера
        private String processorType = "Отсутствует"; //тип процессора
        private double processorFrequency = 0;        //частота процессора
        private int memoryCapacity = 0;               //объем озу
        private String videoCard = "Отсутствует";     //модель видеокарты
        private int videoCapacity = 0;                //объем видеопамяти
        private int powerUnit = 0;                    //мощность блока питания
        private int computerCost = 0;                 //цена компьютера

        public static int compNumber = 0;             //кол.во компов

        // <summary>
        /// Пустой компьютер
        /// </summary>
        public Computer()
        {
            computerID = idGenerator();
        }

        /// <summary>
        /// Пустой компьютер с предварительной ценой
        /// </summary>
        /// <param name="computerCost"></param>
        public Computer(int computerCost)
        {
            computerID = idGenerator();
            this.computerCost = computerCost;
        }

        /// <summary>
        /// Компьютер с процессором
        /// </summary>
        /// <param name="type"></param>
        /// <param name="processorFrequency"></param>
        public Computer(String type, double processorFrequency)

        {
            computerID = idGenerator();
            this.processorType = type;
            this.processorFrequency = processorFrequency;
        }

        /// <summary>
        /// Полный компьютер
        /// </summary>
        /// <param name="processorType"></param>
        /// <param name="processorFrequency"></param>
        /// <param name="memoryCapacity"></param>
        /// <param name="computerCost"></param>
        /// <param name="videoCard"></param>
        /// <param name="videoCapacity"></param>
        /// <param name="powerUnit"></param>
        public Computer(string processorType, double processorFrequency, int memoryCapacity,
            int computerCost, string videoCard, int videoCapacity, int powerUnit)
        {
            computerID = idGenerator();
            this.processorType = processorType;
            this.processorFrequency = processorFrequency;
            this.memoryCapacity = memoryCapacity;
            this.computerCost = computerCost;
            this.videoCard = videoCard;
            this.videoCapacity = videoCapacity;
            this.powerUnit = powerUnit;
        }

        /// <summary>
        /// Генерирует id
        /// </summary>
        /// <param name="computerID"></param>
        /// <returns>Сгенерированный id</returns>
        private String idGenerator()
        {
            Random random = new Random();
            compNumber++;
            computerID = compNumber.ToString();
            return computerID;
        }

        /// <summary>
        /// Конвертирует id из 10сс в 16сс
        /// </summary>
        /// <param name="computerID"></param>
        public void idConvertor()
        {
            computerID = Convert.ToString(Convert.ToInt32(computerID), 16);

        }


        /// <summary>
        /// Выдаёт всю доступную информацию о текущем компьютере
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"ID: {computerID} \n" +
                $"Processor: {processorType} | {processorFrequency} MHz \n" +
                $"Memory: {memoryCapacity} MB \n" +
                $"Videocard: {videoCard} | {videoCapacity} GB\n" +
                $"Power Unit: {powerUnit} W \n" +
                $"Cost: {computerCost} $";
        }

        public int CompareTo(Computer other)
        {
            if (other is null)
            {
                throw new ArgumentException("Некорректное значение параметра");
            }
            return processorType.CompareTo(other.processorType);
        }

        //геттеры и сетторы для всех полей (непосредственно обращаясь к полю)
        public string ProcessorType { get => processorType; set => processorType = value; }
        public double ProcessorFrequency { get => processorFrequency; set => processorFrequency = value; }
        public int MemoryCapacity { get => memoryCapacity; set => memoryCapacity = value; }
        public int ComputerCost { get => computerCost; set => computerCost = value; }
        public string VideoCard { get => videoCard; set => videoCard = value; }
        public int VideoCapacity { get => videoCapacity; set => videoCapacity = value; }
        public int PowerUnit { get => powerUnit; set => powerUnit = value; }
        public string ComputerID { get => computerID; set => computerID = value; }
    }
}
