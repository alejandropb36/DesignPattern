using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.StatePattern
{
    public class NoDebtorState : IState
    {
        public void Action(CustomerContext customerContext, decimal amount)
        {
            if (amount <= customerContext.Residue)
            {
                customerContext.Discount(amount);
                Console.WriteLine($"Solicitud permitida, gasta {amount} y le queda {customerContext.Residue}");
                if (customerContext.Residue <= 0)
                    customerContext.SetState(new DebtorState());
            }
            else
            {
                Console.WriteLine($"No ajusta lo solicitado, " +
                    $"ya tienes {customerContext.Residue} " +
                    $"y quieres gastar {amount}");
            }
        }
    }
}
