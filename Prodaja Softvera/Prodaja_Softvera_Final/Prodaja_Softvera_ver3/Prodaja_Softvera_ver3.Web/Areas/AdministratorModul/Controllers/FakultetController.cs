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

    public class FakultetController : Controller
    {
        private MyContext _context;
        public FakultetController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new FakultetIndexVM
            {
                ID = _context.Fakultet.Select(x=>x.FakultetID).FirstOrDefault(),
                row = _context.Fakultet
                .Select(x => new FakultetIndexVM.Row
                {
                    FakultetID = x.FakultetID,
                    Univerzitet = x.Univerzitet,
                    Naziv = x.Naziv

                })
                .ToList()
            };

            return View(model);
        }



        public IActionResult Dodaj(int id)
        {
            var model = new FakultetDodajVM
            {
                FakultetID = id,
                Naziv = _context.Fakultet
                .Select(x => new SelectListItem
                {
                    Value = x.FakultetID.ToString(),
                    Text = x.Naziv
                })
                .ToList(),

                Univerzitet = _context.Fakultet
                .Select(x => new SelectListItem
                {
                    Value = x.FakultetID.ToString(),
                    Text = x.Naziv
                })
                .ToList()
            };

            return View(model);
        }

        //public IActionResult Uredi()
        //{

        // MISLIM DA NAM NE TREBA OVO IMAMO DODAJ ISTI KLINAC

        //    return View();
        //}

        public IActionResult Snimi(FakultetDodajVM input)
        {

            var spasi = new Fakultet
            {
                FakultetID = input.FakultetID

            };

            _context.Fakultet.Add(spasi);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        public IActionResult Brisi(int id)
        {
            var trazi = _context.Fakultet.Find(id);
            _context.Fakultet.Remove(trazi);
            _context.SaveChanges();
            return RedirectToAction("Dodaj");
        }
    }
}
