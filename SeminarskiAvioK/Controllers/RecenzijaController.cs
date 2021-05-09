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
    public class RecenzijaController : Controller
    {
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();
            RecenzijePrikaziVM model = new RecenzijePrikaziVM
            {
                recenzije = db.Recenzija.Select(i => new RecenzijePrikaziVM.row
                {
                    sadrzaj = i.Sadrzaj,
                    VrijemeKreiranja = i.VrijemeKreiranja,
                    Odobren = i.Odobren,
                    kupac = db.Kupac.Where(x => x.KupacID == i.KupacID).Select(x => x.Ime).FirstOrDefault(),
                    putovanja = db.Putovanja.Where(x => x.PutovanjaID == i.PutovanjaID).Select(x => x.Naziv).FirstOrDefault()
                }).ToList()

            };
            db.Dispose();
            return View(model);
        }
        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Recenzija r = db.Recenzija.Find(id);
            db.Recenzija.Remove(r);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");

        }

        public IActionResult Odobri(int id)
        {
            MyContext db = new MyContext();
            Recenzija r = db.Recenzija.Find(id);
            if (r.Odobren == false)
            {
                r.Odobren = true;
            }
            db.SaveChanges();
            return RedirectToAction("Prikazi");

        }
    }
}