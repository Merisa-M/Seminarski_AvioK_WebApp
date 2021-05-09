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
    public class LetoviController : Controller
    {
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();
            LetPrikaziVM model = new LetPrikaziVM
            {
                letovi = db.Let.Select(x => new LetPrikaziVM.row
                {
                    letid = x.LetID,
                    VrijemePolaska = x.VrijemePolaska,
                    grad = x.Grad.Naziv,
                    klasa = x.Klasa.Naziv
                }).ToList()


            };
            return View(model);
        }
        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();
            LetDodajVM model = new LetDodajVM
            {
                Let = new SeminarskiAvio_K.Models.Let(),
                gradovi = db.Grad.Select(x => new SelectListItem()
                {
                    Text = x.Naziv,
                    Value = x.GradID.ToString()
                }).ToList(),
                klase = db.Klasa.Select(x => new SelectListItem()
                {
                    Text = x.Naziv,
                    Value = x.KlasaID.ToString()
                }).ToList()
            };

            return View(model);
        }
        public IActionResult Snimi(LetDodajVM model)
        {
            MyContext db = new MyContext();
            Let l = model.Let;
            l.GradID = model.Let.GradID;
            l.KlasaID = model.Let.KlasaID;
            db.Let.Add(l);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Let l = db.Let.Where(x => x.LetID == id).FirstOrDefault();
            db.Let.Remove(l);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();
            Let l = db.Let.Where(x => x.LetID == id).Include(x => x.Grad).Include(x => x.Klasa).FirstOrDefault();
            LetUrediVM model = new LetUrediVM
            {
                id = id,
                klase = db.Klasa.Select(x => new SelectListItem
                {
                    Value = x.KlasaID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                gradovi = db.Grad.Select(x => new SelectListItem
                {
                    Value = x.GradID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                VrijemePolaska = l.VrijemePolaska,
                Cijena = l.Cijena
            };
            db.SaveChanges();
            db.Dispose();
            return View(model);
        }
        public IActionResult UrediSnimi(LetUrediVM model)
        {
            MyContext db = new MyContext();
            Let l = db.Let.Where(x => x.LetID == model.id).Include(x => x.Grad).Include(x => x.Klasa).FirstOrDefault();
            l.LetID = model.id;
            l.KlasaID = model.klasaid;
            l.GradID = model.gradid;
            List<SelectListItem> klase = db.Klasa.Select(x => new SelectListItem
            {
                Value = x.KlasaID.ToString(),
                Text = x.Naziv
            }).ToList();
            List<SelectListItem> gradovi = db.Grad.Select(x => new SelectListItem
            {
                Value = x.GradID.ToString(),
                Text = x.Naziv
            }).ToList();
            l.VrijemePolaska = model.VrijemePolaska;
            l.Cijena = model.Cijena;
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
    }
}