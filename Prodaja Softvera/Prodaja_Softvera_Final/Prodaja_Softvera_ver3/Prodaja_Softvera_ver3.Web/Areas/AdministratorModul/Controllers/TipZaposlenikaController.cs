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

    public class TipZaposlenikaController : Controller
    {

        private MyContext _context;
        public TipZaposlenikaController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new TipZaposlenikaVM
            {
                ID = _context.TipZaposlenika.Select(x=>x.TipZaposlenikaID).FirstOrDefault(),
                rows = _context.TipZaposlenika
                .Select(x => new TipZaposlenikaVM.Row
                {
                    TipZaposlenikaID = x.TipZaposlenikaID,
                    Naziv = x.Naziv,
                    Opis = x.Opis

                })
                .ToList()
            };

            return View(model);
        }



        public IActionResult Dodaj(int id)
        {
            var model = new TipZaposlenikaDodajVM
            {
                TipZaposlenikaID = id,
                TipZaposlenika = _context.TipZaposlenika
                .Select(x => new SelectListItem
                {
                    Value = x.TipZaposlenikaID.ToString(),
                    Text = x.Naziv
                })
                .ToList(),
                Grad = _context.Grad
                .Select(x=>new SelectListItem
                {
                    Value = x.GradID.ToString(),
                    Text = x.Naziv
                })
                .ToList(),
                Drzava = _context.Drzava
                .Select(x => new SelectListItem
                {
                    Value = x.DrzavaID.ToString(),
                    Text = x.Naziv
                })
                .ToList(),
                Fakultet = _context.Fakultet
                .Select(x => new SelectListItem
                {
                    Value = x.FakultetID.ToString(),
                    Text = x.Naziv
                })
                .ToList(),
            };

            return View(model);
        }

        //public IActionResult Uredi()
        //{

        // MISLIM DA NAM NE TREBA OVO IMAMO DODAJ ISTI KLINAC

        //    return View();
        //}

        public IActionResult Snimi(TipZaposlenikaDodajVM input)
        {

            var spasi = new TipZaposlenika
            {
                TipZaposlenikaID = input.TipZaposlenikaID
            };

            _context.TipZaposlenika.Add(spasi);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        public IActionResult Brisi(int id)
        {
            var trazi = _context.TipZaposlenika.Find(id);
            _context.Remove(trazi);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
