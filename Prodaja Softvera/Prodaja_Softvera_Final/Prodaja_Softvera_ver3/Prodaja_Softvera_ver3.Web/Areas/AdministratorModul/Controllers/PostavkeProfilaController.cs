using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Data.EntityModels;
using Prodaja_Softvera_ver3.Web.Areas.AdministratorModul.ViewModels;
using Prodaja_Softvera_ver3.Web.Helper;

namespace Prodaja_Softvera_ver3.Web.Areas.AdministratorModul.Controllers
{
    [Area("AdministratorModul")]
    [Autorizacija(admin: true, zaposlenik: false, klijent: false)]
    public class PostavkeProfilaController : Controller
    {
        private MyContext _context;
        public PostavkeProfilaController (MyContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var pronadji = _context.Zaposlenik.Where(x => x.KorisnickiNalogID == id).FirstOrDefault();
            var model = new AdminZaposlenikUrediVM();

            model.ZaposlenikID = pronadji.ZaposlenikID;
            model.Ime = pronadji.Ime;
            model.Prezime = pronadji.Prezime;
            model.Datum_rodjenja = pronadji.Datum_rodjenja;
            model.Email = pronadji.Email;
            model.Kontakt_br = pronadji.Kontakt_br;
            model.GradID = pronadji.GradID;
            model.Grad = _context.Grad.Select(x => new SelectListItem

            {
                Value = x.GradID.ToString(),
                Text = x.Naziv
            }).ToList();
            model.FakultetID = pronadji.FakultetID;
            model.Fakultet = _context.Fakultet.Select(x => new SelectListItem
            {
                Value = x.FakultetID.ToString(),
                Text = x.Naziv
            }).ToList();

            model.TipZaposlenikaID = pronadji.TipZaposlenikaID;
            model.TipZaposlenika = _context.TipZaposlenika.Select(x => new SelectListItem
            {
                Value = x.TipZaposlenikaID.ToString(),
                Text = x.Naziv
            }).ToList();

            model.KorisnickiNalogID = pronadji.KorisnickiNalogID;

            return View(model);
        }






        //public IActionResult Snimi(AdminZaposlenikUrediVM input)
        public IActionResult Snimi(AdminZaposlenikUrediVM input)
        {
             Zaposlenik zaposlenik;
             zaposlenik = _context.Zaposlenik.Find(input.ZaposlenikID);
            

            zaposlenik.ZaposlenikID = input.ZaposlenikID;
            zaposlenik.Ime = input.Ime;
            zaposlenik.Prezime = input.Prezime;
            zaposlenik.Datum_rodjenja = input.Datum_rodjenja;
            zaposlenik.Email = input.Email;
            zaposlenik.Kontakt_br = input.Kontakt_br;
            zaposlenik.GradID = input.GradID;
            zaposlenik.FakultetID = input.FakultetID;
            zaposlenik.TipZaposlenikaID = input.TipZaposlenikaID;

            _context.SaveChanges();
            _context.Dispose();

            TempData["porukaSuccess"] = "Softver uspjesno dodat!!!";
            return RedirectToAction("Index", new { id = input.ZaposlenikID });
        }

    }
}