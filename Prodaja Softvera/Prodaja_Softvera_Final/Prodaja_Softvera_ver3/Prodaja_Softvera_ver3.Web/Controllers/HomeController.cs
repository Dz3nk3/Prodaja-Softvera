using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Data.EntityModels;
using Prodaja_Softvera_ver3.Web.Helper;
using Prodaja_Softvera_ver3.Web.ViewModels;

namespace Prodaja_Softvera_ver3.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.GetLogiraniKorisnik()?.TipKorisnickogNaloga == "Administrator")
            {
                return RedirectToAction("Index", "AdminZaposlenik", new { area = "AdministratorModul" });
            }

            if (HttpContext.GetLogiraniKorisnik()?.TipKorisnickogNaloga == "Zaposlenik")
            {
                return RedirectToAction("Index", "KlijentController2", new { area = "ZaposlenikModul" });
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Data.EntityModels.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
