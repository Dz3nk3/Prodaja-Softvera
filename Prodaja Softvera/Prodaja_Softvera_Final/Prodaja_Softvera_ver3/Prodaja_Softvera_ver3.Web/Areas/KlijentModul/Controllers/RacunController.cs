using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Data.EntityModels;
using Prodaja_Softvera_ver3.Web.Areas.KlijentModul.ViewModels;
using Prodaja_Softvera_ver3.Web.Helper;

namespace Prodaja_Softvera_ver3.Web.Areas.KlijentModul.Controllers
{
    [Area("KlijentModul")]

    public class RacunController : Controller
    {
        public MyContext _context;
        public RacunController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            KorisnickiNalog user = HttpContext.GetLogiraniKorisnik();
            var traziKorisnika = _context.Klijent.Where(x => x.KorisnickiNalogID == user.ID).FirstOrDefault();
            //var traziRacun = _context.Narudzba.Include(x=>x.Racun).Where(z=>z.RacunID==)
            //var traziNarudzbu = _context.Narudzba.Where(x=>x.KlijentID==traziKorisnika.KlijentID && x.RacunID!=null).FirstOrDefault();
            var ListaRacuna = _context.Narudzba.Where(x => x.KlijentID == traziKorisnika.KlijentID && x.RacunID != null).Select(x=>x.Racun).ToList();
            //var traziRacun = _context.Racun.Where(x => x.RacunID == traziNarudzbu.RacunID).ToList();


            //var model = new RacunIndexVM()
            //{
            //    rows = _context.Racun
            //    .Select(x => new RacunIndexVM.Row
            //    {
            //        RacunID = x.RacunID,
            //        Cijena = x.Cijena,
            //        Datum = x.Datum,

            //    })
            //    .ToList()
            //};

            var model = new RacunIndexVM()
            {
                rows = ListaRacuna
              .Select(x => new RacunIndexVM.Row
              {
                  RacunID = x.RacunID,
                  Cijena = x.Cijena,
                  Datum = x.Datum,

              })
              .ToList()
            };


            //if (traziNarudzbu == null)
            //{
            //    TempData["porukaError"] = "Nemate Racuna!";
            //    return View("Index");
            //}


            //if (traziRacun != null)
            //{
            //    model.rows = traziRacun
            //        .Select(x => new RacunIndexVM.Row
            //        {
            //            RacunID = x.RacunID,
            //            Cijena = x.Cijena,
            //            Datum = x.Datum,

            //        }).ToList();
            //}


            TempData["porukaSuccess"] = "Uspjesno ste kupili softver!";
            return View(model);
        }

        public IActionResult OcjeniKomentarisi(int id)
        {
            var traziNarudzbu = _context.Narudzba.Where(x => x.RacunID == id).FirstOrDefault();
            var traziSoftverNarudzba = _context.SoftverNarudzba.Where(x=>x.NarudzbaID == traziNarudzbu.NarudzbaID && x.Komentar == "" && x.Ocjena == 0).FirstOrDefault();

            var model = new RacunDodajVM();

            model.SoftverID = traziSoftverNarudzba.SoftverID;
            model.Datum = traziSoftverNarudzba.Datum.ToString();
            model.NarudzbaID = traziSoftverNarudzba.NarudzbaID;
            model.SoftverNarudzbaID = traziSoftverNarudzba.SoftverNarudzbaID;
            model.ID = id;
            model.Ocjena = traziSoftverNarudzba.Ocjena;
            model.Komentar = traziSoftverNarudzba.Komentar;


            
            return View(model);
        }



        public IActionResult Snimi(RacunDodajVM input)
        {
            var trazi = _context.SoftverNarudzba.Find(input.SoftverNarudzbaID);

            trazi.Ocjena = input.Ocjena;
            trazi.Komentar = input.Komentar;

            _context.SoftverNarudzba.Update(trazi);
            _context.SaveChanges();

            TempData["porukaSuccess"] = "Uspjesno ste kupili softver!";

            return RedirectToAction("Index", new { id = input.NarudzbaID });
        }


    }
}
