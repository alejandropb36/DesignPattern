using DesignPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Tools.Generator;

namespace DesignPatternsASP.Controllers
{
    public class GeneratorFileController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private GeneratoConcretBuilder _generatoConcretBuilder;

        public GeneratorFileController(IUnitOfWork unitOfWork, GeneratoConcretBuilder generatoConcretBuilder)
        {
            _unitOfWork = unitOfWork;
            _generatoConcretBuilder = generatoConcretBuilder;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateFile(int optionFile)
        {
            try
            {

                var beers = _unitOfWork.Beers.Get();
                List<string> content = beers.Select(beer => beer.Name).ToList();
                string path = "file" + DateTime.Now.Ticks + new Random().Next(1000) + ".txt";
                var generatorDirector = new GeneratorDirector(_generatoConcretBuilder);

                if(optionFile == 1)
                {
                    generatorDirector.CreateSimpleJsonGenerator(content, path);
                }
                else
                {
                    generatorDirector.CreateSimplePipeGenerator(content, path);
                }

                var generator = _generatoConcretBuilder.GetGenerator();
                generator.Save();

                return Json("Archivo generado");
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
