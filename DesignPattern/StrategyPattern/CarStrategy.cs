using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.StrategyPattern
{
    public class CarStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy un carro y me muevo con 4 llantas");
        }
    }
}
