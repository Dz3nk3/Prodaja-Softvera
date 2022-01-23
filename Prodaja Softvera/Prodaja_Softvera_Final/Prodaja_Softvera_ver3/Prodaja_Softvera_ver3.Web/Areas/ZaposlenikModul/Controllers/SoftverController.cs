using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Data.EntityModels;
using Prodaja_Softvera_ver3.Web.ViewModels;

namespace Prodaja_Softvera_ver3.Web.Controllers
{
    [Area("ZaposlenikModul")]
    public class SoftverController : Controller
    {
        //MyContext db = new MyContext();

        private MyContext _context;
        public SoftverController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Prikazi(int pageNumber = 1, int pageSize = 5, string pretragaString = null)
        {

            var path = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot/Slike",
                      "chrome.jpg");

            byte[] imageArray = System.IO.File.ReadAllBytes(path);
            string imageBase64 = Convert.ToBase64String(imageArray);

            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            var model = new SoftverPrikaziViewModel();
            var result = new PagedResult<SoftverPrikaziViewModel.Row>();
            if (string.IsNullOrEmpty(pretragaString))
            {
                model.rows = _context.Softver
              .Select(x => new SoftverPrikaziViewModel.Row
              {
                  SoftverID = x.SoftverID,
                  imgfilename = x.imgurl,
                  Naziv = x.Naziv,
                  Verzija = x.Verzija,
                  cijena = x.Cijena,
                  Specifikacije = x.Specifikacije.Naziv,
                  TipSoftvera = x.TipSoftvera.Naziv

              }).OrderBy(x => x.SoftverID).Skip(ExcludeRecords).Take(pageSize).ToList();

                result = new PagedResult<SoftverPrikaziViewModel.Row>
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
            .Select(x => new SoftverPrikaziViewModel.Row
            {
                SoftverID = x.SoftverID,
                imgfilename = x.imgurl,
                Naziv = x.Naziv,
                Verzija = x.Verzija,
                cijena = x.Cijena,
                Specifikacije = x.Specifikacije.Naziv,
                TipSoftvera = x.TipSoftvera.Naziv

            }).Where(x => x.Naziv.Contains(pretragaString)).OrderBy(x => x.SoftverID).Skip(ExcludeRecords).Take(pageSize).ToList();

                result = new PagedResult<SoftverPrikaziViewModel.Row>
                {
                    Data = model.rows.ToList(),
                    TotalItems = _context.Softver.Where(x => x.Naziv.Contains(pretragaString)).Count(),
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }

            return View(result);
        }

        public IActionResult DodajForm()
        {

            var model = new SoftverUrediViewModel
            {
                TipSoftvera = _context.TipSoftvera
                .Select(x => new SelectListItem
                {
                    Value = x.TipSoftveraID.ToString(),
                    Text = x.Naziv
                })
                .ToList(),

                Specifikacije = _context.Specifikacije
                .Select(x => new SelectListItem
                {
                    Value = x.SpecifikacijeID.ToString(),
                    Text = x.Naziv
                })
                .ToList()
            };


            return View(model);
        }

        public IActionResult UrediForm(int id)
        {
            var trazi = _context.Softver.Find(id);

            var model = new SoftverUrediViewModel
            {

                SoftverID = trazi.SoftverID,
                Naziv = trazi.Naziv,
                Verzija = trazi.Verzija,
                cijena = trazi.Cijena,
                //file.FileName = trazi.imgurl,

                TipSoftvera = _context.TipSoftvera
                .Select(x => new SelectListItem
                {
                    Value = x.TipSoftveraID.ToString(),
                    Text = x.Naziv
                })
                .ToList(),

                Specifikacije = _context.Specifikacije
                .Select(x => new SelectListItem
                {
                    Value = x.SpecifikacijeID.ToString(),
                    Text = x.Naziv
                })
                .ToList()
            };

            return View(model);
        }
        public IActionResult Obrisi(int SoftverID)
        {
            Softver s = _context.Softver.Find(SoftverID);
            if (s == null)
            {
                TempData["porukaError"] = "Greška pri brisanju softvera!!!";
            }
            else
            {
                _context.Remove(s);
                _context.SaveChanges();
                TempData["porukaSuccess"] = "Softver uspješno obrisan!!!";
            }

            _context.Dispose();
            return RedirectToAction(nameof(Prikazi));
        }


        public async Task<IActionResult> SnimiAsync(SoftverUrediViewModel input)
        {
            if (input.file == null || input.file.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Slike",
                        input.file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await input.file.CopyToAsync(stream);
            }

            var spasi = new Softver
            {
                SoftverID = input.SoftverID,
                imgurl = input.file.FileName,
                Naziv = input.Naziv,
                Verzija = input.Verzija,
                Cijena = input.cijena,

                SpecifikacijeID = input.SpecifikacijeID,
                TipSoftveraID = input.TipSoftveraID
            };
            if (input.SoftverID == 0)
            {
                _context.Softver.Add(spasi);

            }
            else
            {
                _context.Softver.Update(spasi); //za uredi

            }
            _context.SaveChanges();

            TempData["porukaSuccess"] = "Softver uspjesno dodat!!!";
            return RedirectToAction("Prikazi");
        }

    }
}