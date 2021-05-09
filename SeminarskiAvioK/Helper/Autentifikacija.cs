using Microsoft.AspNetCore.Http;
using SeminarskiAvio_K;
using SeminarskiAvio_K.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SeminarskiAvioK.Helper
{
    public static class Autentifikacija
    {
        public static readonly string LogiraniKorisnik = "logirani_korisnik";

        public static void SetLogiraniKorisnik(this HttpContext context, KorisnickiNalog korisnik)
        {

            context.Session.Set(LogiraniKorisnik, korisnik);

            MyContext db = context.RequestServices.GetService<MyContext>();

            //string stariToken = context.Request.GetCookieJson<string>(LogiraniKorisnik);
            //if (stariToken != null)
            //{
            //    AutorizacijskiToken obrisati = db.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == stariToken);
            //    if (obrisati != null)
            //    {
            //        db.AutorizacijskiToken.Remove(obrisati);
            //        db.SaveChanges();
            //    }
            //}

            //if (korisnik != null)
            //{
            //    string token = Guid.NewGuid().ToString();
            //    db.AutorizacijskiToken.Add(new AutorizacijskiToken()
            //    {
            //        Vrijednost = token,
            //        KorisnickiNalogID = korisnik.KorisnickiNalogID,
            //        VrijemeEvidentiranja = DateTime.Now,
            //       // KorisnickiNalog = db.KorisnickiNalog.Where(x => x.KorisnickiNalogID == korisnik.KorisnickiNalogID).FirstOrDefault()
            //    });
            //    db.SaveChanges();
            //    context.Response.SetCookieJson(LogiraniKorisnik, token);
            //  }
        }

        public static string GetTrenutniToken(this HttpContext context)
        {
            return context.Request.GetCookieJson<string>(LogiraniKorisnik);
        }

        public static KorisnickiNalog GetLogiraniKorisnik(this HttpContext context)
        {
            return context.Session.Get<KorisnickiNalog>(LogiraniKorisnik);

            //MyContext db = context.RequestServices.GetService<MyContext>();

            //string token = context.Request.GetCookieJson<string>(LogiraniKorisnik);
            //if (token == null)
            //    return null;

            //return db.AutorizacijskiToken
            //    .Where(x => x.Vrijednost == token)
            //    .Select(s => s.KorisnickiNalog)
            //    .SingleOrDefault();
        }
    }
}
