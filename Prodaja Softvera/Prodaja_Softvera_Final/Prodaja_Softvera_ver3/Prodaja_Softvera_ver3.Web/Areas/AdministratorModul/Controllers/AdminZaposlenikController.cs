using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Data.EntityModels;
using Prodaja_Softvera_ver3.Web.Areas.AdministratorModul.ViewModels;
using Prodaja_Softvera_ver3.Web.Controllers;
using Prodaja_Softvera_ver3.Web.Helper;

namespace Prodaja_Softvera_ver3.Web.Areas.AdministratorModul.Controllers
{
    [Area("AdministratorModul")]
    [Autorizacija(admin: true, zaposlenik: false, klijent: false)]

    public class AdminZaposlenikController : Controller
    {
        //Kontroler
        private MyContext _context;
        public AdminZaposlenikController(MyContext context)
        {
            _context = context;
        }

        //Akcija:Index
        public IActionResult Index()
        {
            var model = new IndexVM
            {
                rows = _context.Zaposlenik
                .Select(x => new IndexVM.Row
                {
                    ZaposlenikID = x.ZaposlenikID,
                    Naziv = x.Ime + " " + x.Prezime,
                    Email = x.Email,
                    Kontakt_br = x.Kontakt_br,
                    Datum_rodjenja = x.Datum_rodjenja,
                    Grad = x.Grad.Naziv,
                    Fakultet = x.Fakultet.Naziv,
                    TipZaposlenika = x.TipZaposlenika.Naziv,
                    KorisnickiNalog = x.KorisnickiNalog.TipKorisnickogNaloga

                }).ToList()
            };
            return View(model);
        }

        //Akcija: Dodaj novog zaposlenika
        public IActionResult Dodaj()
        {
            var model = new AdminZaposlenikDodajVM();

            model.Grad = _context.Grad.Select(x => new SelectListItem
            {
                Value = x.GradID.ToString(),
                Text = x.Naziv
            }).ToList();


            model.Fakultet = _context.Fakultet.Select(x => new SelectListItem
            {
                Value = x.FakultetID.ToString(),
                Text = x.Naziv
            }).ToList();

            model.TipZaposlenika = _context.TipZaposlenika.Select(x => new SelectListItem
            {
                Value = x.TipZaposlenikaID.ToString(),
                Text = x.Naziv
            }).ToList();

            return View(model);
        }

        //Akcija: Uredi zaposlenika
        public IActionResult Uredi(int id)
        {
            var pronadji = _context.Zaposlenik.Find(id);
            var model = new AdminZaposlenikUrediVM
            {
                ZaposlenikID = id,
                Ime = pronadji.Ime,
                Prezime = pronadji.Prezime,
                Email = pronadji.Email,

                Kontakt_br = pronadji.Kontakt_br,
                Datum_rodjenja = pronadji.Datum_rodjenja,

                Grad = _context.Grad.Select(x => new SelectListItem
                {
                    Value = x.GradID.ToString(),
                    Text = x.Naziv
                }).ToList(),

                Fakultet = _context.Fakultet.Select(x => new SelectListItem
                {
                    Value = x.FakultetID.ToString(),
                    Text = x.Naziv
                }).ToList(),

                TipZaposlenika = _context.TipZaposlenika.Select(x => new SelectListItem
                {
                    Value = x.TipZaposlenikaID.ToString(),
                    Text = x.Naziv
                }).ToList(),
            };

            return View(model);
        }

        //Akcija: Snimi
        public IActionResult Snimi(AdminZaposlenikDodajVM input) 
        {
            Zaposlenik zaposlenik;
            if (input.ZaposlenikID == 0)
            {
                zaposlenik = new Zaposlenik();
                _context.Add(zaposlenik);
            }
            else
            {
                zaposlenik = _context.Zaposlenik.Find(input.ZaposlenikID);
            }
            zaposlenik.Ime = input.Ime;
            zaposlenik.Prezime = input.Prezime;
            zaposlenik.Email = input.Email;
            zaposlenik.Kontakt_br = input.Kontakt_br;
            zaposlenik.Datum_rodjenja = input.Datum_rodjenja;
            zaposlenik.GradID = input.GradID;
            zaposlenik.TipZaposlenikaID = input.TipZaposlenikaID;
            zaposlenik.FakultetID = input.FakultetID;

            _context.SaveChanges();


            KorisnickiNalog kn = new KorisnickiNalog();
            if (zaposlenik.KorisnickiNalogID == null)
            {
                kn.KorisnickoIme = zaposlenik.Ime;
                kn.Lozinka = zaposlenik.Ime;
                kn.TipKorisnickogNaloga = "Zaposlenik";
               
                _context.KorisnickiNalog.Add(kn);
                _context.SaveChanges();

                zaposlenik.KorisnickiNalogID = kn.ID;

                _context.Zaposlenik.Update(zaposlenik);
                _context.SaveChanges();
            }

            _context.Dispose();

            TempData["porukaSuccess"] = "Zaposlenik uspjesno dodat!!!";
            return RedirectToAction("Index");

        }
        //Akcija: Obrisi zaposlenika
        public IActionResult Obrisi(int id)
        {
            var z = _context.Zaposlenik.Find(id);
            var kn = _context.KorisnickiNalog.Where(x => x.ID == z.KorisnickiNalogID).FirstOrDefault();
            if (z == null)
            {
                TempData["porukaError"] = "Greška pri brisanju zaposlenika!!!";
            }
            else
            {
                _context.Remove(z);
                _context.Remove(kn);
                _context.SaveChanges();
                TempData["porukaSuccess"] = "Uspjesno ste obrisali zaposlenika!";
            }

            _context.Dispose();
            return RedirectToAction(nameof(Index));
        }

    }
}

