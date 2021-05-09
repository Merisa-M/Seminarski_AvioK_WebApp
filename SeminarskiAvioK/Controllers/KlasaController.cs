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
    public class KlasaController : Controller
    {
        public IActionResult Prikazi(int TrenutnaStranica = 1, int VelicinaStranice = 6)
        {
            MyContext db = new MyContext();
            KlasaPrikaziVM model = new KlasaPrikaziVM
            {
                klase = db.Klasa.Select(i => new KlasaPrikaziVM.row
                {
                    Naziv = i.Naziv,
                    ID = i.KlasaID
                }).ToList()

            };
            return View(model);
        }
        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();
            KlasaDodajVM model = new KlasaDodajVM
            {
                Klasa = new Klasa()
            };
            return View(model);
        }
        public IActionResult Snimi(KlasaDodajVM model)
        {
            MyContext db = new MyContext();
            Klasa klasa = model.Klasa;
            db.Klasa.Add(klasa);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Klasa k = db.Klasa.Where(i => i.KlasaID == id).FirstOrDefault();
            db.Klasa.Remove(k);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();
            Klasa k = db.Klasa.Where(i => i.KlasaID == id).FirstOrDefault();
            KlasaUrediVM model = new KlasaUrediVM()
            {
                KlasaID = id,
                Naziv = k.Naziv
            };
            db.SaveChanges();
            db.Dispose();
            return View(model);
        }
        public IActionResult UrediSnimi(Klasa model)
        {
            MyContext db = new MyContext();
            Klasa k = db.Klasa.Where(i => i.KlasaID == model.KlasaID).FirstOrDefault();
            k.KlasaID = model.KlasaID;
            k.Naziv = model.Naziv;
            db.SaveChanges();
            db.Dispose();

            return RedirectToAction("Prikazi");

        }
    }
}