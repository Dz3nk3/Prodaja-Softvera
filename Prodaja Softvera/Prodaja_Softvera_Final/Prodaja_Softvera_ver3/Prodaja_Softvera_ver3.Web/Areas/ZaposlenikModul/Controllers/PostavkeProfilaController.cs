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

namespace Prodaja_Softvera_ver3.Web.Areas.ZaposlenikModul.Controllers
{
    [Area("ZaposlenikModul")]
    [Autorizacija(admin: false, zaposlenik: true, klijent: false)]
    public class PostavkeProfilaController : Controller
    {
        private MyContext _context;
        public PostavkeProfilaController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {

            var pronadji = _context.Zaposlenik.Where(x => x.KorisnickiNalogID == id).FirstOrDefault();
            var model = new ZaposlenikUrediViewModel
            {
                ZaposlenikID = pronadji.ZaposlenikID,
                Ime = pronadji.Ime,
                Prezime = pronadji.Prezime,
                Datum_rodjenja = pronadji.Datum_rodjenja,
                Email = pronadji.Email,
                Kontakt_br = pronadji.Kontakt_br,
                GradID = pronadji.GradID,
                Grad = _context.Grad.Select(x => new SelectListItem

                {
                    Value = x.GradID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                FakultetID = pronadji.FakultetID,
                Fakultet = _context.Fakultet.Select(x => new SelectListItem
                {
                    Value = x.FakultetID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                TipZaposlenikaID = pronadji.TipZaposlenikaID,

                TipZaposlenika = _context.TipZaposlenika.Select(x => new SelectListItem
                {
                    Value = x.TipZaposlenikaID.ToString(),
                    Text = x.Naziv
                }).ToList(),

                KorisnickiNalogID = pronadji.KorisnickiNalogID,
                KorisnickiNalog = _context.KorisnickiNalog
                .Select(x=>new SelectListItem { 
                    Value = x.ID.ToString(),
                    Text = x.KorisnickoIme
                })
                .ToList()
            };



            return View(model);
        }

        public IActionResult Snimi(ZaposlenikUrediViewModel input)
        {
            var spasi = new Zaposlenik
            {

                ZaposlenikID = input.ZaposlenikID,
                Ime = input.Ime,
                Prezime = input.Prezime,
                Datum_rodjenja = input.Datum_rodjenja,
                Email = input.Email,
                Kontakt_br = input.Kontakt_br,
                GradID = input.GradID,
                FakultetID = input.FakultetID,
                TipZaposlenikaID = input.TipZaposlenikaID,
                KorisnickiNalogID = input.KorisnickiNalogID

            };

            _context.Zaposlenik.Update(spasi);
            _context.SaveChanges();

            TempData["porukaSuccess"] = "Softver uspjesno dodat!!!";


            return RedirectToAction("Index", new { id = input.ZaposlenikID });

        }
    }
}