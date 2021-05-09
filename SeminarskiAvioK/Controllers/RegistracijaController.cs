using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeminarskiAvio_K;
using SeminarskiAvio_K.Models;
using SeminarskiAvioK.Models;

namespace SeminarskiAvioK.Controllers
{
    public class RegistracijaController : Controller
    {
        public IActionResult Index()
        {
            MyContext db = new MyContext();

            RegistracijaIndexVM model = new RegistracijaIndexVM
            {
               
                KorisnickiNalog = new KorisnickiNalog(),
                Kupac = new Kupac()
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public IActionResult Snimi(RegistracijaIndexVM model)
        {
            MyContext db = new MyContext();

            KorisnickiNalog noviNalog = model.KorisnickiNalog;
            db.KorisnickiNalog.Add(noviNalog);
            db.SaveChanges();

            List<int> nalozi = db.KorisnickiNalog.Select(x => x.KorisnickiNalogID).ToList();

            Kupac noviKupac = model.Kupac;
            noviKupac.KorisnickiNalogID = nalozi.LastOrDefault();
            db.Kupac.Add(noviKupac);
            db.SaveChanges();

            return Redirect("/Login/Index");
        }
    }
}