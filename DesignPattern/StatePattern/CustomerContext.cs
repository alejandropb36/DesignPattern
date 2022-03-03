using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.StatePattern
{
    public class CustomerContext
    {
        private IState _state;
        private decimal _residue;

        public decimal Residue
        {
            set
            {
                _residue = value;
            }
            get
            {
                return _residue;
            }
        }

        public CustomerContext()
        {
            _state = new NewState();
        }

        public void SetState(IState state) => _state = state;

        public IState GetState() => _state;

        public void Request(decimal amount) => _state.Action(this, amount);

        public void Discount(decimal amount) => _residue -= amount;
    }
}
