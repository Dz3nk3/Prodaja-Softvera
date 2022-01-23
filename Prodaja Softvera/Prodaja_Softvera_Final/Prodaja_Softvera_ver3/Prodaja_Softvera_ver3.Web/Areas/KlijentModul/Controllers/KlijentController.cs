using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Data.EntityModels;
using Prodaja_Softvera_ver3.Web.Helper;
using Prodaja_Softvera_ver3.Web.ViewModels;

namespace Prodaja_Softvera_ver3.Web.Controllers
{
    [Area("KlijentModul")]
    [Autorizacija(admin: false, zaposlenik: false, klijent: true)]
    public class KlijentController : Controller
    {

        private MyContext _context;
        public KlijentController(MyContext context)
        {
            _context = context;
        }



        public IActionResult Index(int id)
        {
            KorisnickiNalog user = HttpContext.GetLogiraniKorisnik();
            var pronadji = _context.Klijent.Where(x => x.KorisnickiNalogID == user.ID).FirstOrDefault();


            //var pronadji = _context.Klijent.Where(x => x.KorisnickiNalogID == id).FirstOrDefault();
            var model = new KlijentUrediViewModel();

            model.KlijentID = pronadji.KlijentID;
            model.Ime = pronadji.Ime;
            model.Prezime = pronadji.Prezime;
            model.Datum_rodjenja = pronadji.Datum_rodjenja;
            model.Email = pronadji.Email;
            model.Kontakt_broj = pronadji.Kontakt_broj;

            model.GradID = pronadji.GradID;
            model.Grad = _context.Grad.Select(x => new SelectListItem

            {
                Value = x.GradID.ToString(),
                Text = x.Naziv
            }).ToList();

            model.KarticaID = pronadji.KarticaID;
            model.Kartica = _context.Kartica.Select(x => new SelectListItem
            {
                Value = x.KarticaID.ToString(),
                Text = x.BrojKartice
            }).ToList();

            //model.KorisnickiNalogID = pronadji.KorisnickiNalogID;
            //model.KorisnickiNalog = _context.KorisnickiNalog.Select(x => new SelectListItem
            //{
            //    Value = x.ID.ToString(),
            //    Text = x.TipKorisnickogNaloga
            //}).ToList();



            return View(model);
        }









        public IActionResult Snimi(KlijentUrediViewModel input)
        {
            Klijent klijent = new Klijent();
            klijent = _context.Klijent.Find(input.KlijentID);


            klijent.KlijentID = input.KlijentID;
            klijent.Ime = input.Ime;
            klijent.Prezime = input.Prezime;
            klijent.Datum_rodjenja = input.Datum_rodjenja;
            klijent.Email = input.Email;
            klijent.Kontakt_broj = input.Kontakt_broj;
            klijent.GradID = input.GradID;
            klijent.KarticaID = input.KarticaID;
            //klijent.KorisnickiNalogID = input.KorisnickiNalogID;

            _context.Klijent.Update(klijent);
            _context.SaveChanges();
            //_context.Dispose();

            TempData["porukaSuccess"] = "Uspjesno ste uredili profil!!!";
            return RedirectToAction("Index", new { id = input.KlijentID });
        }



    }

}