using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.StrategyPattern
{
    public class BicycleStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy una bicicleta y pedalean para correr");
        }
    }
}
