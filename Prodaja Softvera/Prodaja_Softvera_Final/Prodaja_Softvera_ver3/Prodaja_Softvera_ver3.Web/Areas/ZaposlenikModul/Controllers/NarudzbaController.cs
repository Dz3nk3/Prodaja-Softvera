using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Web.Areas.ZaposlenikModul.ViewModels;

namespace Prodaja_Softvera_ver3.Web.Areas.ZaposlenikModul.Controllers
{
    [Area("ZaposlenikModul")]
    public class NarudzbaController : Controller
    {
        public MyContext _context;
        public NarudzbaController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new NarudzbaIndexVM
            {
                rows = _context.Narudzba
                .Select(x => new NarudzbaIndexVM.Row
                {
                    NarudzbaID = x.NarudzbaID,
                    Datum_narudzbe = x.Datum_narudzbe,
                    Ocjena = _context.Ocjena.Select(z => z.ocjena).FirstOrDefault(),
                    Komentar = _context.Ocjena.Select(z => z.komentar).FirstOrDefault(),
                    Klijent = x.Klijent.Ime + " " + x.Klijent.Prezime,
                    Softver = _context.SoftverNarudzba.Include(z => z.Softver)
                    .Where(z => z.NarudzbaID == x.NarudzbaID)
                    .OrderByDescending(z => z.Softver.Naziv).Select(z => z.Softver.Naziv).SingleOrDefault(),

                })
                .ToList()
            };
            return View(model);
        }
    }
}
