using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeminarskiAvio_K;
using SeminarskiAvio_K.Models;
using SeminarskiAvioK.Helper;
using SeminarskiAvioK.Models;

namespace SeminarskiAvioK.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View(new LoginVM()
            {
                ZapamtiPassword = true
            });
        }

        public ActionResult Logout()
        {
            MyContext db = new MyContext();
            KorisnickiNalog nalog = HttpContext.GetLogiraniKorisnik();

            return RedirectToAction("Index");
        }

        public ActionResult Provjera(LoginVM Input)
        {
            MyContext _db = new MyContext();

            KorisnickiNalog korisnik = _db.KorisnickiNalog.FirstOrDefault(x => x.KorisnickoIme == Input.Username && x.Lozinka == Input.Password);

            if (korisnik == null)
            {
                TempData["error_poruka"] = "pogresan username ili password";
                return View("Index", Input);
            }

            if (korisnik.KorisnickiNalogID <= 1)
            {
                HttpContext.SetLogiraniKorisnik(korisnik);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                HttpContext.SetLogiraniKorisnik(korisnik);

                return RedirectToAction("ONama", "Klijent");

            }
            //HttpContext.SetLogiraniKorisnik(Input.ZapamtiPassword);
            ////HttpContext.SetLogiraniKorisnik(, input.ZapamtiPassword);
            ////return _db.Kupac.Any(s => s.LoginID == korisnik.LoginID) ? RedirectToAction("HomePageUser", "User") : RedirectToAction("HomePageAdmin", "Admin");
        }
    }
}