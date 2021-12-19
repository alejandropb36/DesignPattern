using DesignPattern.FactoryPattern;
using DesignPattern.Models;
using DesignPattern.RepositoryPattern;
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
                var beerRepository = new BeerRepository(context);
                var beer = new Beer();
                beer.Name = "Victoria";
                beer.Style = "Pilsner";
                beerRepository.Add(beer);
                beerRepository.Save();
            }
        }
    }
}
