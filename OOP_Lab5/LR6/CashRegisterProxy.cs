using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2.LR6
{
    class CashRegisterProxy : ICashRegister
    {
        private CashRegister _cashRegister = new CashRegister();
        public void AddMoney(long amount)
        {
            _cashRegister.AddMoney(amount);
        }

        public void ReleaseMoney(long amount)
        {
            _cashRegister.ReleaseMoney(amount);
        }

        public long GetMoneyAmount()
        {
            return _cashRegister.GetMoneyAmount();
        }
    }
}
