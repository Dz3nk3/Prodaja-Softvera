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

    public class KlijentController : Controller
    {
        //Konstruktor
        private MyContext _context;
        public KlijentController(MyContext context)
        {
            _context = context;
        }

        //Akcija: Index
        public IActionResult Index()
        {
            var klijent = new KlijentIndexVM
            {
                rows = _context.Klijent
                .Select(k => new KlijentIndexVM.Row
                {
                    KlijentID = k.KlijentID,
                    Naziv = k.Ime + " " + k.Prezime,
                    Email = k.Email,
                    Kontakt_broj = k.Kontakt_broj,
                    Datum_rodjenja = k.Datum_rodjenja,
                    Grad = k.Grad.Naziv,
                    BrojKartice = k.Kartica.BrojKartice,
                    BrojSoftvera = _context.Narudzba.Where(q => q.KlijentID == k.KlijentID && q.RacunID != null).Count()
                }).ToList()
            };
            return View(klijent);
        }

        //Akcija: Detalji
        public IActionResult Detalji(int id)
        {
            var trazi = _context.Klijent.Find(id);
            var traziGrad = _context.Grad.Find(trazi.GradID);
            var traziKarticu = _context.Kartica.Find(trazi.KarticaID);
            var model = new KlijentDetaljiVM();

            model.KlijentID = trazi.KlijentID;
            model.Naziv = trazi.Ime + " " + trazi.Prezime;
            model.Email = trazi.Email;
            model.Kontakt_broj = trazi.Kontakt_broj;
            model.Datum_rodjenja = trazi.Datum_rodjenja;
            model.Grad = traziGrad.Naziv;
            model.BrojKartice = traziKarticu.BrojKartice;


            return View(model);
        }


        //Akcija: Obrisi
        public IActionResult Obrisi(int id)
        {
            var trazi = _context.Klijent.Find(id);
            if (trazi == null)
            {
                TempData["porukaError"] = "Greška pri brisanju Klijenta!!!";
            }
            else
            {
                _context.Klijent.Remove(trazi);
                _context.SaveChanges();
                TempData["porukaSuccess"] = "Uspjesno ste obrisali Klijenta!";
            }

            _context.Dispose();
            return RedirectToAction("Index");

        }

    }
}

