using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.StrategyPattern
{
    public class MotoStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy una moto y me muevo con 2 llantas");
        }
    }
}
