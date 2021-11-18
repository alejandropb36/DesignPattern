using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.DependencyInjection
{
    public class DrinkWithBeer
    {
        private Beer _beer;
        private decimal _wather;
        private decimal _sugar;

        public DrinkWithBeer(decimal wather, decimal sugar, Beer beer)
        {
            _wather = wather;
            _sugar = sugar;
            _beer = beer;
        }

        public void Build()
        {
            Console.WriteLine($"Preparamos la bebida que tiene agua {_wather} azucar {_sugar} y cerveza {_beer.Name}");
        }
    }
}
