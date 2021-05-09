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
    public class PutovanjaController : Controller
    {
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();

            PutovanjaPrikaziVM model = new PutovanjaPrikaziVM
            {
                putovanja = db.Putovanja.Select(x => new PutovanjaPrikaziVM.row
                {
                    Naziv = x.Naziv,
                    NazivGrada = x.Grad.Naziv,
                    Opis = x.Opis,
                    prosjecnaOcjena = x.ProsjecnaOcjena
                }).ToList()

            };
            return View(model);
        }
        public IActionResult Dodaj()
        {

            MyContext db = new MyContext();
            PutovanjaDodajVM model = new PutovanjaDodajVM
            {
                Putovanja = new Putovanja(),
                gradovi = db.Grad.Select(x => new SelectListItem()
                {
                    Text = x.Naziv,
                    Value = x.GradID.ToString()
                }).ToList()


            };

            return View(model);
        }
        public IActionResult Snimi(PutovanjaDodajVM model)
        {

            MyContext db = new MyContext();
            Putovanja p = model.Putovanja;
            p.GradID = model.Putovanja.GradID;

            db.Putovanja.Add(p);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");

        }
        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Putovanja p = db.Putovanja.Where(x => x.PutovanjaID == id).FirstOrDefault();
            db.Putovanja.Remove(p);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();
            Putovanja p = db.Putovanja.Where(x => x.PutovanjaID == id).Include(x => x.Grad).FirstOrDefault();
            PutovanjaUrediVM model = new PutovanjaUrediVM
            {
                putovanjeid = id,
                gradovi = db.Grad.Select(x => new SelectListItem
                {
                    Value = x.GradID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                ocjena = p.ProsjecnaOcjena,
                opis = p.Opis
            };
            db.SaveChanges();
            db.Dispose();
            return View(model);
        }
        public IActionResult UrediSnimi(PutovanjaUrediVM model)
        {
            MyContext db = new MyContext();
            Putovanja p = db.Putovanja.Where(x => x.PutovanjaID == model.putovanjeid).Include(x => x.Grad).FirstOrDefault();
            p.PutovanjaID = model.putovanjeid;
            p.GradID = model.GradID;
            List<SelectListItem> gradovi = db.Grad.Select(x => new SelectListItem
            {
                Value = x.GradID.ToString(),
                Text = x.Naziv
            }).ToList();
            p.ProsjecnaOcjena = model.ocjena;
            p.Opis = model.opis;
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
    }
}