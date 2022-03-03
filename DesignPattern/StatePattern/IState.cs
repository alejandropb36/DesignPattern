using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.StatePattern
{
    public interface IState
    {
        public void Action(CustomerContext customerContext, decimal amount);
    }
}
