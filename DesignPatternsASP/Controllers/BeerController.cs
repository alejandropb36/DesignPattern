using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatternsASP.Models.ViewModels;
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
            var brands = _unitOfWork.Brands.Get();
            ViewBag.Brands = new SelectList(brands, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Add(FormBeerViewModel formBeerViewModel)
        {
            if (!ModelState.IsValid)
            {
                var brands = _unitOfWork.Brands.Get();
                ViewBag.Brands = new SelectList(brands, "Id", "Name");
                return View("Add", formBeerViewModel);
            }

            var beer = new Beer();
            beer.Name = formBeerViewModel.Name;
            beer.Style = formBeerViewModel.Style;

            if (!string.IsNullOrEmpty(formBeerViewModel.OtherBrand) && (formBeerViewModel.BrandId == null || formBeerViewModel.BrandId == Guid.Empty))
            {
                var brand = new Brand();
                brand.Name = formBeerViewModel.OtherBrand;
                brand.Id = Guid.NewGuid();

                beer.BrandId = brand.Id;
                _unitOfWork.Brands.Add(brand);
            }
            else
            {
                beer.BrandId = formBeerViewModel.BrandId;
            }

            _unitOfWork.Beers.Add(beer);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
