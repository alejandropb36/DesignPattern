﻿using DesignPattern.DependencyInjection;
using DesignPattern.FactoryPattern;
using DesignPattern.Models;
using System;
using System.Linq;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //SaleFactory storeSaleFactory = new StoreSaleFactory(10);
            //SaleFactory internetSaleFactory = new InternetSaleFactory(2);

            //ISale sale1 = storeSaleFactory.GetSale();
            //sale1.Sell(15);

            //ISale sale2 = internetSaleFactory.GetSale();
            //sale2.Sell(20);

            //var beer = new Beer("Stout", "Minerva");
            //var drinkWithBeer = new DrinkWithBeer(10, 10, beer);
            //drinkWithBeer.Build();

            using(var context = new DesignPatternsContext())
            {
                var beers = context.Beer.ToList();
                foreach(var beer in beers)
                {
                    Console.WriteLine(beer.Name);
                }
            }
        }
    }
}
