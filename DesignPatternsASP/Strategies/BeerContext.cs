using DesignPatterns.Repository;
using DesignPatternsASP.Models.ViewModels;

namespace DesignPatternsASP.Strategies
{
    public class BeerContext
    {
        private IBeerStrategy _beerStrategy;

        public IBeerStrategy BeerStrategy
        {
            set
            {
                _beerStrategy = value;
            }
        }

        public BeerContext(IBeerStrategy beerStrategy)
        {
            _beerStrategy = beerStrategy;
        }

        public void Add(FormBeerViewModel formBeerViewModel, IUnitOfWork unitOfWork)
        {
            _beerStrategy.Add(formBeerViewModel, unitOfWork);
        }

    }
}
