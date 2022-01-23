using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Data.EntityModels;
using Prodaja_Softvera_ver3.Web.Areas.ZaposlenikModul.ViewModels;
using Prodaja_Softvera_ver3.Web.ViewModels;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace Prodaja_Softvera_ver3.Web.Controllers
{
    [Area("ZaposlenikModul")]
    public class AnalizaController : Controller
    {
        private MyContext _context;
        public AnalizaController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Prikazi()
        {
            List<AnalizaPrikaziViewModel> analiza = _context.Analiza
                .Select(a => new AnalizaPrikaziViewModel
                {
                    AnalizaID = a.AnalizaID,
                    Naziv = a.Naziv,
                    Datum_analize = a.Datum_analize,
                    Klijent = a.Klijent.Ime + " " + a.Klijent.Prezime,
                    Zaposlenik = a.Zaposlenik.Ime + " " + a.Zaposlenik.Prezime,
                    Softver = a.Softver.Naziv
                })
                .ToList();

            AnalizaPrikaziVM model = new AnalizaPrikaziVM
            {
                podaciZaHtmlTabelu = analiza
            };

            _context.Dispose();
            return View("Prikazi", model);
        }

        public IActionResult Dodaj()
        {
            var model = new AnalizaDodajVM();

            model.Naziv = "";
            model.Datum_analize = DateTime.Now;


            //model.KlijentID = _context.Klijent.Select(x=>x.KlijentID);
            model.Klijent = _context.Klijent
                .Select(x => new SelectListItem
                {
                    Value = x.KlijentID.ToString(),
                    Text = x.Ime + " " + x.Prezime
                })
                .ToList();
            //model.ZaposlenikID = trazi.ZaposlenikID;
            model.Zaposlenik = _context.Zaposlenik
                .Select(x => new SelectListItem
                {
                    Value = x.ZaposlenikID.ToString(),
                    Text = x.Ime + " " + x.Prezime
                })
                .ToList();
            //model.SoftverID = trazi.SoftverID;
            model.Softver = _context.Softver
                .Select(x => new SelectListItem
                {
                    Value = x.SoftverID.ToString(),
                    Text = x.Naziv
                })
                .ToList();

            return View(nameof(Dodaj), model);
        }
        public IActionResult UrediForm(int id)
        {
            var trazi = _context.Analiza.Find(id);
            var model = new AnalizaUrediViewModel();

            model.AnalizaID = trazi.AnalizaID;
            model.Naziv = trazi.Naziv;
            model.Datum_analize = trazi.Datum_analize;

            model.KlijentID = trazi.KlijentID;
            model.Klijent = _context.Klijent
                .Select(x => new SelectListItem
                {
                    Value = x.KlijentID.ToString(),
                    Text = x.Ime + " " + x.Prezime
                })
                .ToList();
            model.ZaposlenikID = trazi.ZaposlenikID;
            model.Zaposlenik = _context.Zaposlenik
                .Select(x => new SelectListItem
                {
                    Value = x.ZaposlenikID.ToString(),
                    Text = x.Ime + " " + x.Prezime
                })
                .ToList();
            model.SoftverID = trazi.SoftverID;
            model.Softver = _context.Softver
                .Select(x => new SelectListItem
                {
                    Value = x.SoftverID.ToString(),
                    Text = x.Naziv
                })
                .ToList();


            return View(nameof(UrediForm), model);
        }


        public IActionResult SnimiDodaj(AnalizaUrediViewModel input)
        {

            var x = new Analiza();
            //x.AnalizaID = input.AnalizaID;
            x.Naziv = input.Naziv;
            x.Datum_analize = input.Datum_analize;
            x.KlijentID = input.KlijentID;
            x.ZaposlenikID = input.ZaposlenikID;
            x.SoftverID = input.SoftverID;

            _context.Analiza.Update(x);
            _context.SaveChanges();
            _context.Dispose();
            TempData["porukaSuccess"] = "Analiza uspjesno dodana!!!";

            return RedirectToAction("Prikazi");
        }


        public IActionResult Obrisi(int id)
        {
            Analiza a = _context.Analiza.Find(id);
            if (a == null)
            {
                TempData["porukaError"] = "Greška pri brisanju analize!!!";
            }
            else
            {
                _context.Remove(a);
                _context.SaveChanges();
                TempData["porukaSuccess"] = "Uspješno ste obrisali analizu!!!";
            }

            _context.Dispose();
            return RedirectToAction(nameof(Prikazi));
        }

        public IActionResult Snimi(AnalizaUrediViewModel input)
        {

            var x = new Analiza();
            x.AnalizaID = input.AnalizaID;
            x.Naziv = input.Naziv;
            x.Datum_analize = input.Datum_analize;
            x.KlijentID = input.KlijentID;
            x.ZaposlenikID = input.ZaposlenikID;
            x.SoftverID = input.SoftverID;

            _context.Analiza.Update(x);
            _context.SaveChanges();
            _context.Dispose();
            TempData["porukaSuccess"] = "Analiza uspjesno dodana!!!";

            return RedirectToAction("UrediForm", new { id = input.AnalizaID });
        }

        public IActionResult ConvertToPDF()
        {


            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();
            //Add a page.
            PdfPage page = doc.Pages.Add();
            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            //Add values to list

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);


            //List<Analiza> OAnaliza = new List<Analiza>();
            //for (int i = 1; i <= _context.Zaposlenik.Count(); i++)
            //{
            //    Analiza oanaliza = new Analiza();
            //    var trazi = _context.Analiza.Where(x => x.ZaposlenikID == i).FirstOrDefault();
            //    if (trazi != null)
            //    {
            //        oanaliza.ZaposlenikID = i;
            //        if (trazi.Naziv != null)
            //            oanaliza.Naziv = trazi.Naziv;
            //        if (trazi.Datum_analize != null)
            //            oanaliza.Datum_analize = trazi.Datum_analize;
            //        if (trazi.Klijent != null)
            //            oanaliza.KlijentID = trazi.KlijentID;
            //        if (trazi.Zaposlenik != null)
            //            oanaliza.ZaposlenikID = trazi.ZaposlenikID;
            //        if (trazi.Softver != null)
            //            oanaliza.SoftverID = trazi.SoftverID;
            //        OAnaliza.Add(oanaliza);
            //    }

            //}

            List<AnalizaPDF> OAnaliza = new List<AnalizaPDF>();
            for (int i = 1; i < _context.Analiza.Count(); i++)
            {
                var trazi = _context.Analiza.Where(x => x.AnalizaID == i).FirstOrDefault();
                var traziZaposlenika = _context.Zaposlenik.Where(x => x.ZaposlenikID == trazi.ZaposlenikID).FirstOrDefault();
                var traziKlijenta = _context.Klijent.Where(x => x.KlijentID == trazi.KlijentID).FirstOrDefault();
                var traziSoftver = _context.Softver.Where(x => x.SoftverID == trazi.SoftverID).FirstOrDefault();

                AnalizaPDF oanaliza = new AnalizaPDF();

                oanaliza.AnalizaID = trazi.AnalizaID.ToString();
                oanaliza.Naziv = trazi.Naziv;

                oanaliza.KlijentID= trazi.KlijentID.ToString();
                oanaliza.Ime= traziKlijenta.Ime;
                oanaliza.Prezime= traziKlijenta.Prezime;

                oanaliza.ZaposlenikID = trazi.ZaposlenikID.ToString();
                oanaliza.ImeZaposlenika = traziZaposlenika.Ime;
                oanaliza.PrezimeZaposlenika = traziZaposlenika.Prezime;

                oanaliza.SoftverID = trazi.SoftverID.ToString();
                oanaliza.Softver = traziSoftver.Naziv;


                OAnaliza.Add(oanaliza);
            }


            //Add list to IEnumerable
            IEnumerable<object> dataTable = OAnaliza;
            //Assign data source.
            pdfGrid.DataSource = dataTable;
            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 10));
            //Save the PDF document to stream
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;
            //Close the document.
            doc.Close(true);
            ////Defining the ContentType for pdf file.


            //Download the PDF document in the browser
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");

            fileStreamResult.FileDownloadName = "Sample.pdf";

            return fileStreamResult;
        }


    }
}
