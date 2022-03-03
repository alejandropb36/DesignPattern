using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.StatePattern
{
    public class DebtorState : IState
    {
        public void Action(CustomerContext customerContext, decimal amount)
        {
            Console.WriteLine("No puedes comprar");
        }
    }
}