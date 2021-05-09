using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeminarskiAvio_K;
using SeminarskiAvio_K.Models;
using SeminarskiAvioK.Models;

namespace SeminarskiAvioK.Controllers
{
    public class AvionController : Controller
    {
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();
            AvionPrikaziVM model = new AvionPrikaziVM()
            {
                avioni = db.Avion.Select(i => new AvionPrikaziVM.row
                {
                    Naziv = i.Naziv,
                    Klasa = i.Klasa.Naziv,
                    kapacitet = i.Kapacitet,
                    AvionID = i.AvionID
                }).ToList()

            };
            db.Dispose();
            return View(model);
        }
        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();

            AvionDodajVM model = new AvionDodajVM()
            {
                Avion = new Avion(),
                klase = db.Klasa.Select(x => new SelectListItem()
                {
                    Value = x.KlasaID.ToString(),
                    Text = x.Naziv
                }).ToList()
            };
            return View(model);
        }
        public IActionResult Snimi(AvionDodajVM model)
        {
            //MyContext db = new MyContext();
            //    Avion avion = model.Avion;
            //    avion.KlasaID = model.Avion.KlasaID;
            //    db.Avion.Add(avion);
            //    db.SaveChanges();
            //    db.Dispose();
            //    return RedirectToAction("Prikazi");
            MyContext db = new MyContext();
            Avion p = model.Avion;
            p.KlasaID = model.Avion.KlasaID;
            db.Avion.Add(p);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");

        }
        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Avion a = db.Avion.Where(i => i.AvionID == id).FirstOrDefault();
            db.Avion.Remove(a);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");

        }
        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();
            Avion a = db.Avion.Where(i => i.AvionID == id).Include(i => i.Klasa).FirstOrDefault();
            AvionUrediVM model = new AvionUrediVM()
            {
                id = id,
                klase = db.Klasa.Select(x => new SelectListItem
                {
                    Value = x.KlasaID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                Naziv = a.Naziv,
                Kapacitet = a.Kapacitet
            };
            db.SaveChanges();
            db.Dispose();
            return View(model);
        }
        public IActionResult UrediSnimi(AvionUrediVM model)
        {
            MyContext db = new MyContext();
            Avion a = db.Avion.Where(i => i.AvionID == model.id).Include(i => i.Klasa).FirstOrDefault();
            a.Naziv = model.Naziv;
            a.Kapacitet = model.Kapacitet;
            a.AvionID = model.id;
            List<SelectListItem> klase = db.Klasa.Select(x => new SelectListItem
            {
                Value = x.KlasaID.ToString(),
                Text = x.Naziv
            }).ToList();
            a.KlasaID = model.klaseID;
            db.SaveChanges();
            db.Dispose();

            return RedirectToAction("Prikazi");
        }
    }
}