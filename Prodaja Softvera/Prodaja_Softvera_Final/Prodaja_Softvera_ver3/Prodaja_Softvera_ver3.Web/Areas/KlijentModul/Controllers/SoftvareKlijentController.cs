using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Data.EntityModels;
using Prodaja_Softvera_ver3.Web.Areas.KlijentModul.ViewModels;
using Prodaja_Softvera_ver3.Web.Helper;
using Prodaja_Softvera_ver3.Web.ViewModels;

namespace Prodaja_Softvera_ver3.Web.Areas.KlijentModul.Controllers
{
    [Area("KlijentModul")]
    [Autorizacija(admin: false, zaposlenik: false, klijent: true)]

    public class SoftvareKlijentController : Controller
    {
        public MyContext _context;
        public SoftvareKlijentController(MyContext context)
        {
            _context = context;
        }





        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            var path = Path.Combine(
                     Directory.GetCurrentDirectory(), "wwwroot/Slike",
                     "ae.png");


            byte[] imageArray = System.IO.File.ReadAllBytes(path);
            string imageBase64 = Convert.ToBase64String(imageArray);



            List<Softver> softveri = _context.Softver.ToList();
            ViewBag.Softveri = softveri;


            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            var model = new SoftvareKlijentIndexVM();
            var result = new PagedResult<SoftvareKlijentIndexVM.Row>();
            //var ocjenaTrazi = _context.SoftverNarudzba.Where(x=>x.oc)

            model.rows = _context.Softver
          .Select(x => new SoftvareKlijentIndexVM.Row
          {
              SoftverID = x.SoftverID,
              imgfilename = x.imgurl,
              Naziv = x.Naziv,
              Verzija = x.Verzija,
              Cijena = x.Cijena,

              Ocjena = (int)_context.SoftverNarudzba.Where(z => z.SoftverID == x.SoftverID)
              .Select(z => z.Ocjena).Average(),

              Komentar = _context.SoftverNarudzba.OrderByDescending(c => c.Datum)
              .Where(z => z.SoftverID == x.SoftverID)
              .Select(z => z.Komentar).FirstOrDefault(),

              TipSoftvera = x.TipSoftvera.Naziv

          }).OrderBy(x => x.SoftverID).Skip(ExcludeRecords).Take(pageSize).ToList();

            result = new PagedResult<SoftvareKlijentIndexVM.Row>
            {
                Data = model.rows.ToList(),
                TotalItems = _context.Softver.Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(result);
        }

        public IActionResult Detalji(int id)
        {
            var trazi = _context.Softver.Find(id);
            var traziNarudzbu = _context.SoftverNarudzba.Where(z => z.SoftverID == id).FirstOrDefault();
            var traziSpecifikaciju = _context.Specifikacije.Where(z => z.SpecifikacijeID == trazi.SpecifikacijeID).FirstOrDefault();
            var traziTipSoftvera = _context.TipSoftvera.Where(z => z.TipSoftveraID == trazi.TipSoftveraID).FirstOrDefault();
            var model = new SoftvareDodajVM();

            model.SoftverID = trazi.SoftverID;
            model.cijena = trazi.Cijena;
            model.Naziv = trazi.Naziv;
            model.Verzija = trazi.Verzija;
            model.Ocjena = traziNarudzbu.Ocjena;
            model.Komentar = traziNarudzbu.Komentar;
            model.TipSoftvera = traziTipSoftvera.Naziv;
            model.Specifikacije = traziSpecifikaciju.Naziv;



            return View(model);
        }








        public IActionResult Snimi(KupiVM input)
        {
            var spasi = new Racun
            {
                Datum = input.Datum,
                Cijena = input.Cijena
            };
            _context.Racun.Add(spasi);
            _context.SaveChanges();
            TempData["porukaSuccess"] = "Uspjesno ste kupili Proizvod!!!";
            return RedirectToAction("Index");
        }








    }
}
