using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Data.EntityModels;
using Prodaja_Softvera_ver3.Web.ViewModels;

namespace Prodaja_Softvera_ver3.Web.Controllers
{
    public class Registracija : Controller
    {
        private readonly MyContext _context;

        public Registracija(MyContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var model = new RegisterVM
            {
                Grad = _context.Grad
                .Select(x => new SelectListItem
                {
                    Value = x.GradID.ToString(),
                    Text = x.Naziv
                })
                .ToList(),
                Kartica = _context.Kartica
                .Select(x => new SelectListItem
                {
                    Value = x.KarticaID.ToString(),
                    Text = x.BrojKartice
                })
                .ToList()
            };

            return View(model);
        }

        public IActionResult Register(RegisterVM input)
        {

            var klijent = new Klijent()
            {

                Ime = input.Ime,
                Prezime = input.Prezime,
                Email = input.Email,
                Kontakt_broj = input.KontaktBr,
                Datum_rodjenja = input.DatumRodjenja,
                GradID = input.GradID,
                KarticaID = input.KarticaID

            };

            _context.SaveChanges();


            KorisnickiNalog kn = new KorisnickiNalog();
            if (klijent.KorisnickiNalogID == null)
            {
                kn.KorisnickoIme = klijent.Ime;
                kn.Lozinka = klijent.Ime;
                kn.TipKorisnickogNaloga = "Klijent";

                _context.KorisnickiNalog.Add(kn);
                _context.SaveChanges();

                klijent.KorisnickiNalogID = kn.ID;

                _context.Klijent.Update(klijent);
                _context.SaveChanges();
            }

            _context.Dispose();

            TempData["porukaSuccess"] = "Zaposlenik uspjesno dodat!!!";
            return RedirectToAction("Index", "Autentifikacija");
        }
    }
}