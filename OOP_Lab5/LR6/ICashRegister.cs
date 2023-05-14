using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2.LR6
{
    interface ICashRegister
    {
        void AddMoney(long amount);

        void ReleaseMoney(long amount);

        long GetMoneyAmount();
    }
}
