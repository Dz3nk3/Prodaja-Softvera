using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Web.Helper;
using Prodaja_Softvera_ver3.Web.Areas.AdministratorModul.ViewModels;
using cloudscribe.Pagination.Models;
using Prodaja_Softvera_ver3.Data.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Prodaja_Softvera_ver3.Web.Areas.AdministratorModul.Controllers
{
    [Area("AdministratorModul")]
    [Autorizacija(admin: true, zaposlenik: false, klijent: false)]

    public class AdminSoftverController : Controller
    {
        private MyContext _context;
        public AdminSoftverController(MyContext context)
        {
            _context = context;
        }

        //Kontroler: Index(prikazi pageing)
        public IActionResult Index(int pageNumber = 1, int pageSize = 5, string pretragaString = null)
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            var model = new SoftverIndexVM();
            var result = new PagedResult<SoftverIndexVM.Row>();
            if (string.IsNullOrEmpty(pretragaString))
            {
                model.rows = _context.Softver
              .Select(x => new SoftverIndexVM.Row
              {
                  SoftverID = x.SoftverID,
                  Naziv = x.Naziv,
                  Verzija = x.Verzija,
                  Cijena = x.Cijena,
                  Specifikacija = x.Specifikacije.Naziv,
                  TipSoftvera = x.TipSoftvera.Naziv

              }).OrderBy(x => x.SoftverID).Skip(ExcludeRecords).Take(pageSize).ToList();

                 result = new PagedResult<SoftverIndexVM.Row>
                {
                    Data = model.rows.ToList(),
                    TotalItems = _context.Softver.Count(),
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
                
            }
            else
            {
                model.rows = _context.Softver
            .Select(x => new SoftverIndexVM.Row
            {
                SoftverID = x.SoftverID,
                Naziv = x.Naziv,
                Verzija = x.Verzija,
                Cijena = x.Cijena,
                Specifikacija = x.Specifikacije.Naziv,
                TipSoftvera = x.TipSoftvera.Naziv

            }).Where(x => x.Naziv.Contains(pretragaString)).OrderBy(x => x.SoftverID).Skip(ExcludeRecords).Take(pageSize).ToList();

                 result = new PagedResult<SoftverIndexVM.Row>
                {
                    Data = model.rows.ToList(),
                    TotalItems = _context.Softver.Where(x => x.Naziv.Contains(pretragaString)).Count(),
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }

            return View(result);
        }

        //Kontroler: Detalji
        public IActionResult Detalji(int id)
        {
            var trazi = _context.Softver.Where(x => x.SoftverID == id).FirstOrDefault();
            var traziSpecifikaciju = _context.Specifikacije.Find(trazi.SpecifikacijeID);
            var traziTipSoftvera = _context.TipSoftvera.Find(trazi.TipSoftveraID);
            var model = new SoftverDetaljiVM
            {
                SoftverID = trazi.SoftverID,
                Naziv = trazi.Naziv,
                Verzija = trazi.Verzija,
                Cijena = trazi.Cijena,

                TipSoftvera = traziTipSoftvera.Naziv,

                Specifikacija = traziSpecifikaciju.Naziv
            };

            return View(model);
        }

        //Kontroler: Obrisi
        public IActionResult Obrisi(int id)
        {
            var z = _context.Softver.Find(id);
            if (z == null)
            {
                TempData["porukaError"] = "Greška pri brisanju zaposlenika!!!";
            }
            else
            {
                _context.Remove(z);
                _context.SaveChanges();
                TempData["porukaSuccess"] = "Uspjesno ste obrisali zaposlenika!";
            }

            _context.Dispose();
            return RedirectToAction(nameof(Index));
        }
    }
}