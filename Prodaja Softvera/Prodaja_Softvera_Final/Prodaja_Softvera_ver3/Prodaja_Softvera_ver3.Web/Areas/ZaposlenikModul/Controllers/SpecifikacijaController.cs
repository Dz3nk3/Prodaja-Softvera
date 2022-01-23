using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Data.EntityModels;
using Prodaja_Softvera_ver3.Web.Areas.ZaposlenikModul.ViewModels;

namespace Prodaja_Softvera_ver3.Web.Areas.ZaposlenikModul.Controllers
{
    [Area("ZaposlenikModul")]

    public class SpecifikacijaController : Controller
    {
        public MyContext _context;
        public SpecifikacijaController(MyContext conext)
        {
            _context = conext;
        } 

        public IActionResult Index()
        {
            var model = new SpecifikacijaIndexVM
            {
                rows = _context.Specifikacije
                .Select(x=>new SpecifikacijaIndexVM.Row
                { 
                    SpecifikacijeID = x.SpecifikacijeID,
                    Naziv = x.Naziv,
                    CPU = x.CPU,
                    GPU = x.GPU,
                    HDD = x.HDD,
                    RAM = x.RAM
                })
                .ToList()
            };

            return View(model);
        }


        //public IActionResult Dodaj(int id)
        //{
        //    var model = new SpecifikacijaDodajVM
        //    {
        //        SpecifikacijeID = id,
        //        Naziv = _context.Specifikacije.Select(x=>x.Naziv).FirstOrDefault(),
        //        CPU = _context.Specifikacije
        //        .Select(x=>new SelectListItem 
        //        {
        //            Value = x.SpecifikacijeID.ToString(),
        //            Text = x.CPU
        //        })
        //        .ToList()
        //    };
        //    return View(model);
        //}
        public IActionResult Uredi(int id)
        {
            var model = new SpecifikacijUrediVM
            {
                SpecifikacijeID = id,
                Naziv = _context.Specifikacije.Select(x => x.Naziv).FirstOrDefault(),
                CPU = _context.Specifikacije.Select(x => x.CPU).FirstOrDefault(),
                GPU = _context.Specifikacije.Select(x => x.GPU).FirstOrDefault(),
                HDD = _context.Specifikacije.Select(x => x.HDD).FirstOrDefault(),
                RAM = _context.Specifikacije.Select(x => x.RAM).FirstOrDefault(),
            };
            return View();
        }

        public IActionResult Snimi(SpecifikacijaDodajVM input)
        {
            var snimi = new Specifikacije
            {
                SpecifikacijeID = input.SpecifikacijeID
            };
            _context.Specifikacije.Add(snimi);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Obrisi(int id)
        {
            var trazi = _context.Specifikacije.Find(id);
            _context.Specifikacije.Remove(trazi);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
