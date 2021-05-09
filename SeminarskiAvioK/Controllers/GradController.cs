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
    public class GradController : Controller
    {
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();
            GradPrikaziVM model = new GradPrikaziVM()
            {
                gradovi = db.Grad.Select(i => new GradPrikaziVM.row()
                {
                    Naziv = i.Naziv,
                    id = i.GradID
                }).ToList()

            };
            db.Dispose();
            return View(model);

        }
        public IActionResult Dodaj()
        {

            GradDodajVM model = new GradDodajVM()
            {
                Grad = new Grad()

            };
            return View(model);
        }
        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            //Grad gr = db.Grad.Find(id);
            List<Kupac> kupci = db.Kupac/*.Where(x => x.GradID == gr.GradID)*/.ToList();

            foreach (var y in kupci)
            {
                var kni = y.KupacID;
                List<KupacNagradnaIgra> kupacigre = db.KupacNagradnaIgra.Where(x => x.KupacID == kni).ToList();
                foreach (var n in kupacigre)
                {
                    db.KupacNagradnaIgra.Remove(n);
                }
                List<PutovanjeKupac> pkList = db.PutovanjeKupac.Where(x => x.KupacID == kni).ToList();
                foreach (var pk in pkList)
                {
                    db.PutovanjeKupac.Remove(pk);
                }
                List<Rezervacija> rList = db.Rezervacija.Where(x => x.KupacID == kni).ToList();
                foreach (var r in rList)
                {
                    var rez = r.RezervacijaID;
                    List<Karta> k = db.Karta.Where(x => x.RezervacijaID == rez).ToList();
                    foreach (var yz in k)
                    {
                        db.Karta.Remove(yz);
                    }
                    db.Rezervacija.Remove(r);
                }
                List<Recenzija> komList = db.Recenzija.Where(x => x.KupacID == kni).ToList();
                foreach (var k in komList)
                {
                    db.Recenzija.Remove(k);
                }
                db.Kupac.Remove(y);




            }
            List<Let> lLista = db.Let.Where(x => x.GradID == id).ToList();
            foreach (var l in lLista)
            {
                var let = l.LetID;
                List<Let> k = db.Let.Where(x => x.LetID == let).ToList();
                foreach (var yz in k)
                {
                    db.Let.Remove(yz);
                }
                db.Let.Remove(l);
            }
            //db.Grad.Remove(gr);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
        public IActionResult Snimi(GradDodajVM model)
        {
            if (ModelState.IsValid)
            {
                MyContext db = new MyContext();
                Grad gr = model.Grad;
                db.Grad.Add(gr);
                db.SaveChanges();
                db.Dispose();
                return Redirect("Prikazi");
            }
            return View("Dodaj");
        }
        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();
            Grad gr = db.Grad.Where(i => i.GradID == id).FirstOrDefault();
            db.Dispose();
            return View(gr);
        }
        public IActionResult UrediSnimi(Grad model)
        {
            if (ModelState.IsValid)
            {
                MyContext db = new MyContext();
                Grad gr = db.Grad.Where(i => i.GradID == model.GradID).FirstOrDefault();
                gr.Naziv = model.Naziv;
                gr.GradID = model.GradID;
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Prikazi");
            }
            return View("Uredi");
        }
    }
}