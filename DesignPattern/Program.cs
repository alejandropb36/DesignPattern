using DesignPattern.FactoryPattern;
using DesignPattern.Models;
using DesignPattern.RepositoryPattern;
using DesignPattern.UnitOfWorkPattern;
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

            //using(var context = new DesignPatternsContext())
            //{
            //    var beerRepository = new BeerRepository(context);
            //    var beer = new Beer();
            //    beer.Name = "Victoria";
            //    beer.Style = "Pilsner";
            //    beerRepository.Add(beer);
            //    beerRepository.Save();
            //}

            using (var context = new DesignPatternsContext())
            {
                //var beerRepository = new Repository<Beer>(context);
                //var beer = new Beer();
                //beer.Name = "Pacifico";
                //beer.Style = "SESE";
                //beerRepository.Add(beer);
                //beerRepository.Save();

                //foreach(var b in beerRepository.Get())
                //{
                //    Console.WriteLine($"{b.Name} {b.Style}");
                //}

                //Aqui se puede implementar otro modelo

                // UnitOfWork

                var unitOfWork = new UnitOfWork(context);
                var beers = unitOfWork.Beers;

                var beer = new Beer
                {
                    Name = "Fuller2",
                    Style = "Style2"
                };

                beers.Add(beer);

                var brands = unitOfWork.Brands;
                var brand = new Brand
                {
                    Name = "Una brand mas"
                };

                brands.Add(brand);

                unitOfWork.Save();
            }
        }
    }
}
