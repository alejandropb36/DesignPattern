using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatternsASP.Models.ViewModels;
using DesignPatternsASP.Strategies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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

        [HttpGet]
        public IActionResult Add()
        {
            GetBrandsData();
            return View();
        }

        [HttpPost]
        public IActionResult Add(FormBeerViewModel formBeerViewModel)
        {
            if (!ModelState.IsValid)
            {
                GetBrandsData();
                return View("Add", formBeerViewModel);
            }

            var context = formBeerViewModel.BrandId == null ?
                            new BeerContext(new BeerWithBrandStrategy()) :
                            new BeerContext(new BeerStrategy());

            context.Add(formBeerViewModel, _unitOfWork);

            return RedirectToAction("Index");
        }

        #region HELPERS
        private void GetBrandsData()
        {
            var brands = _unitOfWork.Brands.Get();
            ViewBag.Brands = new SelectList(brands, "Id", "Name");
        }
        #endregion
    }
}
