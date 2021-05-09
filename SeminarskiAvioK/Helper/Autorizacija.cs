using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SeminarskiAvio_K;
using SeminarskiAvio_K.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SeminarskiAvioK.Helper
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool Admin, bool Klijent) : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { Admin, Klijent };
        }
    }

    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        public MyAuthorizeImpl(bool Admin, bool Klijent)
        {
            _klijent = Klijent;
            _admin = Admin;
        }
        private readonly bool _admin;
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

            MyContext db = filterContext.HttpContext.RequestServices.GetService<MyContext>();

            if (_admin && db.Admin.Any(x => x.KorisnickiNalogID == k.KorisnickiNalogID))
            {
                await next(); //ima pravo pristupa
                return;
            }

            if (_klijent && db.Kupac.Any(x => x.KorisnickiNalogID == k.KorisnickiNalogID))
            {
                await next(); //ima pravo pristupa
                return;
            }

            if (db.Kupac.All(x => x.KorisnickiNalogID != k.KorisnickiNalogID) && db.Admin.Any(x => x.KorisnickiNalogID != k.KorisnickiNalogID))
            {
                filterContext.Result = new RedirectToActionResult("Index", "Login", new { area = "" });
                return;
            }

            if (filterContext.Controller is Controller c1)
            {
                c1.TempData["error_poruka"] = "Nemate pravo pristupa!";
            }
            filterContext.Result = new RedirectToActionResult("Index", "Home", new { @area = "" });
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException;
        }
    }
}
