using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Data.EntityModels;
using Prodaja_Softvera_ver3.Web.ViewModels;
using Prodaja_Softvera_ver3.Web.Helper;
using Nexmo.Api;
using Google.Authenticator;

namespace Prodaja_Softvera_ver3.Web.Controllers
{
    public class Autentifikacija : Controller
    {
        private readonly MyContext _db;

        public Autentifikacija(MyContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(new LoginVM()
            {
                ZapamtiPassword = true,
            });
        }

        public IActionResult Login(LoginVM input)
        {
            KorisnickiNalog korisnik = _db.KorisnickiNalog
                .Where(x => x.KorisnickoIme == input.username && x.Lozinka == input.password).SingleOrDefault();
          
            TabelaGreska g = new TabelaGreska();

            if (korisnik == null)
            {
                g.greska = "pogrešan username ili password";
                g.vrijemeGreske = DateTime.Now;

                _db.TabelaGreska.Add(g);
                _db.SaveChanges();

                TempData["error_poruka"] = "pogrešan username ili password";
                return RedirectToAction("Index", input);
            }

            HttpContext.SetLogiraniKorisnik(korisnik, input.ZapamtiPassword);


            bool isAdministrator = false, isZaposlenik = false, isKlijent = false;

            KorisnickiNalog k = _db.KorisnickiNalog.Where(x => x.ID == korisnik.ID).FirstOrDefault();

            if (k.TipKorisnickogNaloga == "Administrator")
            {
                isAdministrator = true;
                return RedirectToAction("Index", "AdminZaposlenik", new { area = "AdministratorModul" });
            }

            if (k.TipKorisnickogNaloga == "Zaposlenik")
            { 
                isZaposlenik = true;
                return RedirectToAction("Index", "KlijentController2", new { area = "ZaposlenikModul" });
            }


            if (k.TipKorisnickogNaloga == "Klijent")
            {
                //var klijent = _db.Klijent.Where(x => x.KorisnickiNalogID == k.ID).SingleOrDefault();

                //Random generator = new Random();
                //int r = generator.Next(100000, 1000000);
                //Kod kod = new Kod
                //{
                //    kod = r,
                //    IsValid = true,
                //    VrijemeSlanja = DateTime.Now
                //};

                //var client = new Client(creds: new Nexmo.Api.Request.Credentials
                //{
                //    ApiKey = "f372b717",
                //    ApiSecret = "gJ6bpKeFXbr5xqIJ"
                //});
                //var results = client.SMS.Send(request: new SMS.SMSRequest
                //{
                //    from = "Prodaja softvera",
                //    to = "38761843304" /*+klijent.Kontakt_broj*/,
                //    text = "Vas aktivacijski kod: " + r.ToString()
                //});

                isKlijent = true;
                return RedirectToAction("Index", "SoftvareKlijent", new { area = "KlijentModul" });

                //return RedirectToAction("PotvrdiIndex");
            }

            return RedirectToAction("Index", "Home");
        }

      

        public IActionResult PotvrdiIndex(int kod)
        {
            return View();
        }

        public IActionResult Potvrdi(int kod)
        {
            List<int> kodovi = _db.Kod.Where(t => t.kod == kod).Select(n => n.ID).ToList();

            foreach (var item in kodovi)
            {
                Kod k = _db.Kod.Find(item);
                if (k.IsValid != true && k.VrijemeSlanja.Hour - DateTime.Now.Hour > 5 && k.kod != kod)
                {
                    TempData["act_poruka"] = ("Kod nije aktiviran. Pokušajte ponovo.");
                    return RedirectToAction("Login");
                }

                k.IsValid = false;
            }

            return RedirectToAction("Index", "SoftvareKlijent", new { area = "KlijentModul" });
        }

        public IActionResult Logout()
        {

            HttpContext.DeleteLogiraniKorisnik();
            return RedirectToAction("Index");
        }
    }
}
