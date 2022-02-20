using DesignPatterns.Repository;
using DesignPatternsASP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsASP.Controllers
{
    public class BeerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BeerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<BeerViewModel> beers = from beer in _unitOfWork.Beers.Get()
                                               select new BeerViewModel
                                               {
                                                   Id = beer.Id,
                                                   Name = beer.Name,
                                                   Style = beer.Style
                                               };

            return View("Index", beers);
        }
    }
}
