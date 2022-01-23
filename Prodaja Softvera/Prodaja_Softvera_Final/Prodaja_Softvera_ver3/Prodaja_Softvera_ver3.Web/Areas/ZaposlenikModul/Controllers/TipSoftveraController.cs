using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Data.EntityModels;
using Prodaja_Softvera_ver3.Web.Areas.ZaposlenikModul.ViewModels;

namespace Prodaja_Softvera_ver3.Web.Areas.ZaposlenikModul.Controllers
{
    [Area("ZaposlenikModul")]

    public class TipSoftveraController : Controller
    {
        public MyContext _context;
        public TipSoftveraController(MyContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var model = new TipSoftveraIndexVM
            {
                rows = _context.TipSoftvera
                .Select(x=>new TipSoftveraIndexVM.Row
                {
                    TipSoftveraID = x.TipSoftveraID,
                    Naziv = x.Naziv,
                    Opis = x.Opis
                })
                .ToList()
            };
            return View(model);
        }


        public IActionResult Dodaj()
        {
            var model = new TipSoftveraDodajVM
            {
                TipSoftveraID = _context.TipSoftvera.Select(x=>x.TipSoftveraID).FirstOrDefault(),
                Naziv = _context.TipSoftvera.Select(x => x.Naziv).FirstOrDefault(),
                Opis = _context.TipSoftvera.Select(x => x.Opis).FirstOrDefault(),
            };
            return View(model);
        }



        public IActionResult Snimi(TipSoftveraDodajVM input)
        {
            var snimi = new TipSoftvera
            {
                TipSoftveraID = input.TipSoftveraID
            };
            _context.TipSoftvera.Add(snimi);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Obrisi(int id)
        {
            var trazi = _context.TipSoftvera.Find(id);
            _context.TipSoftvera.Remove(trazi);
            _context.SaveChanges();
            return View();
        }
    }
}
