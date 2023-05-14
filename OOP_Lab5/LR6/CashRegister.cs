using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2.LR6
{
    class CashRegister : ICashRegister
    {
        private long _serialNumber;
        private long _moneyAmount;

        public void AddMoney(long amount)
        {
            _moneyAmount += amount;
        }

        public void ReleaseMoney(long amount)
        {
            _moneyAmount -= amount;
        }

        public long GetMoneyAmount()
        {
            return _moneyAmount;
        }

        public long GetSerialNumber()
        {
            return _serialNumber;
        }

    }
}
