using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatternsASP.Models.ViewModels;
using System;

namespace DesignPatternsASP.Strategies
{
    public class BeerWithBrandStrategy : IBeerStrategy
    {
        public void Add(FormBeerViewModel formBeerViewModel, IUnitOfWork unitOfWork)
        {
            var beer = new Beer();
            beer.Name = formBeerViewModel.Name;
            beer.Style = formBeerViewModel.Style;

            var brand = new Brand();
            brand.Name = formBeerViewModel.OtherBrand;
            brand.Id = Guid.NewGuid();

            beer.BrandId = brand.Id;

            unitOfWork.Brands.Add(brand);
            unitOfWork.Beers.Add(beer);
            unitOfWork.Save();
        }
    }
}
