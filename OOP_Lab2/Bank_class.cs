using System;
using System.Collections.Generic;

namespace OOP_Lab2
{
    /// <summary>
    /// Класс, реализующий банк
    /// </summary>
    class Bank
    {
        /* ПОЛЯ */

        /// <summary>
        /// Название банка
        /// </summary>
        public string _bankName;   
        
        /// <summary>
        /// Количество депозитов
        /// </summary>
        private int _countDeposits;

        /// <summary>
        /// Сумма депозитов
        /// </summary>
        private double _amountDeposits; 
        
        /// <summary>
        /// Процентная ставка
        /// </summary>
        private float _interestRate;

        /// <summary>
        /// Количество клиентов
        /// </summary>
        private int _numClients; 
        
        /// <summary>
        /// Год основания
        /// </summary>
        private int _yearFoundation;
        
        /// <summary>
        /// Расположение
        /// </summary>
        private string _location;

        /* МЕТОДЫ */

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Bank()
        {
            _bankName = Functions.randomString();
            _countDeposits = 0;
            _amountDeposits = 0.0;
            _interestRate = 0.0F;
            _numClients = 0;
            _yearFoundation = 1970;
            _location = "Город";
        }

        /// <summary>
        /// Конструктор с 1 параметром
        /// </summary>
        /// <param name="bankName">Название банка</param>
        public Bank(string bankName)
        {
            _bankName = bankName;
            _countDeposits = 0;
            _amountDeposits = 0;
            _interestRate = 0;
            _numClients = 0;
            _yearFoundation = 1970;
            _location = "Город";
        }

        /// <summary>
        /// Конструктор с 2 параметрами
        /// </summary>
        /// <param name="bankName">Название банка</param>
        /// <param name="countDeposits">Количество депозитов</param>
        public Bank(string bankName, int countDeposits)
        {
            _bankName = bankName;
            _countDeposits = countDeposits;
            _amountDeposits = 0;
            _interestRate = 0;
            _numClients = 0;
            _yearFoundation = 1970;
            _location = "Город";
        }

        /// <summary>
        /// Конструктор с 7 параметрами
        /// </summary>
        /// <param name="bankName">Название банка</param>
        /// <param name="countDeposits">Количество депозитов</param>
        /// <param name="amountDeposits">Сумма депозитов</param>
        /// <param name="interestRate">Процентная ставка</param>
        /// <param name="numClients">Количество клиентов</param>
        /// <param name="yearFoundation">Год основания</param>
        /// <param name="location">Расположение</param>
        public Bank(string bankName, int countDeposits, double amountDeposits, float interestRate,
            int numClients, int yearFoundation, string location)
        {
            _bankName = bankName;
            _countDeposits = countDeposits;
            _amountDeposits = amountDeposits;
            _interestRate = interestRate;
            _numClients = numClients;
            _yearFoundation = yearFoundation;
            _location = location;
        }

        /// <summary>
        /// Переопределение метода ToString()
        /// </summary>
        /// <returns>Строку с информацией о банке</returns>
        public override string ToString()
        {
            return $"Название банка: {_bankName}\n" +
                $"Количество депозитов: {_countDeposits}\n" +
                $"Сумма депозитов: {_amountDeposits}$\n" +
                $"Процентная ставка: {_interestRate}%\n" +
                $"Количество клиентов: {_numClients}\n" +
                $"Год основания: {_yearFoundation}\n" +
                $"Расположение: {_location}\n";
        }



        /// <summary>
        /// Геттер количества депозитов
        /// </summary>
        /// <returns>Количество депозитов</returns>
        public int get_countDeposits()
        {
            return _countDeposits;
        }

        /// <summary>
        /// Геттер суммы депозитов
        /// </summary>
        /// <returns>Сумма депозитов</returns>
        public double get_amountDeposits()
        {
            return _amountDeposits;
        }

        /// <summary>
        /// Геттер процентной ставки
        /// </summary>
        /// <returns>Процентная ставка</returns>
        public float get_interestRate()
        {
            return _interestRate;
        }

        /// <summary>
        /// Геттер количества клиентов
        /// </summary>
        /// <returns>Количество клиентов</returns>
        public int get_numClients()
        {
            return _numClients;
        }

        /// <summary>
        /// Геттер года основания
        /// </summary>
        /// <returns>Год основания</returns>
        public int get_yearFoundation()
        {
            return _yearFoundation;
        }

        /// <summary>
        /// Геттер расположения
        /// </summary>
        /// <returns>Расположение</returns>
        public string get_location()
        {
            return _location;
        }



        /// <summary>
        /// Сеттер названия банка
        /// </summary>
        /// <param name="bankName">Название банка</param>
        public void set_bankName(string bankName)
        {
            _bankName = bankName;
        }

        /// <summary>
        /// Сеттер количества депозитов
        /// </summary>
        /// <param name="countDeposits">Количество депозитов</param>
        public void set_countDeposits(int countDeposits)
        {
            _countDeposits = countDeposits;
        }

        /// <summary>
        /// Сеттер суммы депозитов
        /// </summary>
        /// <param name="amountDeposits">Сумма депозитов</param>
        public void set_amountDeposits(double amountDeposits)
        {
            _amountDeposits = amountDeposits;
        }

        /// <summary>
        /// Сеттер процентной ставки
        /// </summary>
        /// <param name="interestRate">Процентная ставка</param>
        public void set_interestRate(float interestRate)
        {
            _interestRate = interestRate;
        }

        /// <summary>
        /// Сеттер количества клиентов
        /// </summary>
        /// <param name="numClients">Количество клиентов</param>
        public void set_numClients(int numClients)
        {
            _numClients = numClients;
        }

        /// <summary>
        /// Сеттер года основания
        /// </summary>
        /// <param name="yearFoundation">Год основания</param>
        public void set_yearFoundation(int yearFoundation)
        {
            _yearFoundation = yearFoundation;
        }

        /// <summary>
        /// Сеттер расположения
        /// </summary>
        /// <param name="location">Расположение</param>
        public void set_location(string location)
        {
            _location = location;
        }
    }
}
