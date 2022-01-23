using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Prodaja_Softvera_ver3.Data.EF;
using Prodaja_Softvera_ver3.Data.EntityModels;
using Prodaja_Softvera_ver3.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Helper
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool admin, bool zaposlenik, bool klijent) 
            : base (typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { admin, zaposlenik, klijent };

        }
    }

    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        public MyAuthorizeImpl(bool admin, bool zaposlenik, bool klijent)
        {
            _admin = admin;
            _zaposlenik = zaposlenik;
            _klijent = klijent;
        }
        private readonly bool _admin;
        private readonly bool _zaposlenik;
        private readonly bool _klijent;

        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {

            KorisnickiNalog k = filterContext.HttpContext.GetLogiraniKorisnik();
            if (k == null)
            {
                if (filterContext.Controller is Controller controller)
                {
                    controller.TempData["error_poruka"] = "Niste logirani!";
                }

                filterContext.Result = new RedirectToActionResult("Index", "Autentifikacija", new { @area = "" });
                return;
            }

            //Preuzimamo DbContext preko app servisa
            MyContext _db = filterContext.HttpContext.RequestServices.GetService<MyContext>();

            //klijenti mogu pristupiti
            if (_klijent && _db.Klijent.Any(s => s.KorisnickiNalogID == k.ID))
            {
                await next(); // ok - ima pravo pristupa
                return;
            }

            //zaposlenici mogu pristupiti
            if (_zaposlenik && _db.Zaposlenik.Any(s => s.KorisnickiNalogID == k.ID))
            {
                await next(); // ok - ima pravo pristupa
                return;
            }

            //admin mogu pristupiti
            if (_admin && _db.Zaposlenik.Any(s => s.KorisnickiNalogID == k.ID))
            {
                await next(); // ok - ima pravo pristupa
                return;

            }

            if (filterContext.Controller is Controller c1)
            {
                c1.TempData["error-poruka"] = "Nemate pravo pristupa!";
            }
            filterContext.Result = new RedirectToActionResult("Index", "Home", new { @area = "" });
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new NotImplementedException();
        }
    }
}


