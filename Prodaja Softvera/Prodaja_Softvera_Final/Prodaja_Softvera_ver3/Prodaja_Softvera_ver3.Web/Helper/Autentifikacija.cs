using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Helper
{
    public static class Autentifikacija
    {
        private const string LogiraniKorisnik = "logirani_korisnik";

        public static void SetLogiraniKorisnik(this HttpContext context, KorisnickiNalog korisnik, bool snimiUCookie = false)
        {
            context.Session.Set(LogiraniKorisnik, korisnik);

            if (snimiUCookie)
            {
                //Preuzimamo DbContext preko app services
                MyContext _db = context.RequestServices.GetService<MyContext>();

                string token = Guid.NewGuid().ToString();
                _db.AutorizacijskiToken.Add(new AutorizacijskiToken
                {
                    Vrijednost = token,
                    KorisnickiNalogId = korisnik.ID,
                    VrijemeEvidentiranja = DateTime.Now
                });
                _db.SaveChanges();
                context.Response.SetCookieJson(LogiraniKorisnik, token);
            }
            else
            {
                context.Response.RemoveCookie(LogiraniKorisnik);
            }
        }

        public static KorisnickiNalog GetLogiraniKorisnik(this HttpContext context)
        {
            KorisnickiNalog korisnik = context.Session.Get<KorisnickiNalog>(LogiraniKorisnik);

            if (korisnik == null)
            {
                MyContext _db = context.RequestServices.GetService<MyContext>();

                string token = context.Request.GetCookieJson<string>(LogiraniKorisnik);
                if (token == null)
                    return null;

                korisnik = _db.AutorizacijskiToken
                    .Where(x => x.Vrijednost == token)
                    .Select(s => s.KorisnickiNalog)
                    .SingleOrDefault();

                if (korisnik != null)
                {
                    context.Session.Set(LogiraniKorisnik, korisnik);
                }

            }
            return korisnik;
        }

        public static void DeleteLogiraniKorisnik(this HttpContext context)
        {
            context.Session.Remove(LogiraniKorisnik);

            context.Response.RemoveCookie(LogiraniKorisnik);
        }
    }
}
