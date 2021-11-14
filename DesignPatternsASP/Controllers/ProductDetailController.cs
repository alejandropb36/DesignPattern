using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools.Earn;

namespace DesignPatternsASP.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index(decimal total)
        {
            // Factories
            LocalEarnFactory localEarnFactory = new LocalEarnFactory(0.20m);
            ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.30m, 20);

            // Products de factory
            var localEarn = localEarnFactory.GetEarn();
            var foreignEarn = foreignEarnFactory.GetEarn();

            // Total
            ViewBag.totalLocal = total + localEarn.Earn(total);
            ViewBag.totalForeign = total + foreignEarn.Earn(total);

            return View();
        }
    }
}
