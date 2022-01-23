using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Data.EntityModels;
using Prodaja_Softvera_ver3.Web.Areas.KlijentModul.ViewModels;
using Prodaja_Softvera_ver3.Web.Helper;

namespace Prodaja_Softvera_ver3.Web.Areas.KlijentModul.Controllers
{
    [Area("KlijentModul")]

    public class NarudzbeController : Controller
    {
        public MyContext _context;

        public NarudzbeController(MyContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {

            KorisnickiNalog user = HttpContext.GetLogiraniKorisnik();
            var traziKorisnika = _context.Klijent.Where(x => x.KorisnickiNalogID == user.ID).FirstOrDefault();
            var traziNarudzbu = _context.Narudzba.Where(x => x.Racun == null && x.Klijent.KorisnickiNalogID == user.ID).FirstOrDefault();
            var model = new SoftverNarudzbaKartIndexVM();

            if (traziKorisnika != null)
            {
                if (traziNarudzbu == null)
                {
                    TempData["porukaError"] = "Vaša korpa je prazna!";
                    return View("Index");
                }

                var traziSoftverNarudzbu = _context.SoftverNarudzba.Where(x => x.NarudzbaID == traziNarudzbu.NarudzbaID);

                model.ID = traziSoftverNarudzbu.Select(x => x.NarudzbaID).FirstOrDefault();
                model.rows = traziSoftverNarudzbu
                    .Select(x => new SoftverNarudzbaKartIndexVM.Row
                    {
                        NazivSoftvera = x.NazivSoftvera,
                        CijenaSoftvera = x.CijenaSoftvera,
                        SoftverNarudzbaID = x.SoftverNarudzbaID,
                        NarudzbaID = x.NarudzbaID,
                        SoftverID = x.SoftverID,
                        Datum = x.Datum,
                        Ocjena = x.Ocjena,
                        Komentar = x.Komentar

                    }).ToList();
            }


            return View(model);
        }

        public IActionResult DodajUKorpu(int id)
        {
            KorisnickiNalog user = HttpContext.GetLogiraniKorisnik();
            var traziKlijenta = _context.Klijent.Where(x => x.KorisnickiNalogID == user.ID).FirstOrDefault();
            var traziNarudzbu = _context.Narudzba.Where(x => x.Racun == null && x.KlijentID == traziKlijenta.KlijentID).FirstOrDefault();
            var traziSoftver = _context.Softver.Find(id);

            var narudzba = new Narudzba();

            if (traziKlijenta != null)
            {
                if (traziNarudzbu == null)
                {
                    narudzba = new Narudzba()
                    {
                        Datum_narudzbe = DateTime.Now,
                        KlijentID = traziKlijenta.KlijentID,
                        Racun = null
                    };

                    _context.Narudzba.Add(narudzba);
                    _context.SaveChanges();

                    traziNarudzbu = narudzba;
                }

                var softver = new SoftverNarudzba()
                {
                    NazivSoftvera = traziSoftver.Naziv,
                    CijenaSoftvera = traziSoftver.Cijena,
                    Datum = traziNarudzbu.Datum_narudzbe,
                    SoftverID = traziSoftver.SoftverID,
                    NarudzbaID = traziNarudzbu.NarudzbaID,
                    Ocjena = 0,
                    Komentar = ""
                };

                _context.SoftverNarudzba.Add(softver);
                _context.SaveChanges();
            }


            return RedirectToAction("Index");
        }


        public IActionResult Kupi(int id)
        {

            KorisnickiNalog user = HttpContext.GetLogiraniKorisnik();
            var traziKlijenta = _context.Klijent.Where(x => x.KorisnickiNalogID == user.ID).FirstOrDefault();
            var traziNarudzbu = _context.Narudzba.Where(x => x.Racun == null
                                                     && x.KlijentID == traziKlijenta.KlijentID
                                                     && x.NarudzbaID == id).FirstOrDefault();
            if (traziNarudzbu != null)
            {
                var racun = new Racun()
                {
                    Datum = traziNarudzbu.Datum_narudzbe,
                    Cijena = _context.SoftverNarudzba.Where(x => x.NarudzbaID == traziNarudzbu.NarudzbaID).Select(x => x.CijenaSoftvera).Sum(),
                    Kolicina = _context.SoftverNarudzba.Where(x => x.NarudzbaID == traziNarudzbu.NarudzbaID).Count(),
                };
                _context.Racun.Add(racun);
                _context.SaveChanges();

                traziNarudzbu.RacunID = racun.RacunID;

                _context.Narudzba.Update(traziNarudzbu);
                _context.SaveChanges();
            }

            //return RedirectToAction("Index");
            return RedirectToAction("Index", "Racun", new { Area = "KlijentModul" });
        }



        public IActionResult UkloniIzKorpe(int id)
        {
            KorisnickiNalog user = HttpContext.GetLogiraniKorisnik();
            var traziKlijenta = _context.Klijent.Where(x => x.KorisnickiNalogID == user.ID).FirstOrDefault();
            var traziNarudzbu = _context.Narudzba.Where(x => x.Racun == null && x.KlijentID == traziKlijenta.KlijentID).FirstOrDefault();
            var traziSoftver = _context.SoftverNarudzba.Where(x => x.SoftverID == id && x.NarudzbaID == traziNarudzbu.NarudzbaID).FirstOrDefault();
            int brojiSoftver = _context.SoftverNarudzba.Where(x => x.NarudzbaID == traziNarudzbu.NarudzbaID).Count();

            if (traziKlijenta.KlijentID == traziNarudzbu.KlijentID && traziNarudzbu.NarudzbaID == traziSoftver.NarudzbaID)
            {
                _context.SoftverNarudzba.Remove(traziSoftver);
                _context.SaveChanges();
                brojiSoftver -= 1;
            }
            if (brojiSoftver < 1)
            {
                _context.Narudzba.Remove(traziNarudzbu);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
