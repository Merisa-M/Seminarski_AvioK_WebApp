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
    public class KupacController : Controller
    {
        public IActionResult Prikazi(int TrenutnaStranica = 1, int VelicinaStranice = 6)
        {
            MyContext db = new MyContext();
            KupacPrikaziVM model = new KupacPrikaziVM
            {
                kupci = db.Kupac.Select(x => new KupacPrikaziVM.row
                {
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    BrojTelefona = x.BrojTelefona,
                    BrojTokena = x.BrojTokena,
                    KupacID = x.KupacID,
                    Email = x.Email,
                    
                })
            .ToList()

            };
            TempData["trenutna"] = TrenutnaStranica;
            var items = model.kupci.OrderBy(x => x.Ime).Skip((TrenutnaStranica - 1) * VelicinaStranice).Take(VelicinaStranice).ToList();
            //   db.Dispose();
            return PartialView(items);
        }

        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();
            KupacDodajVM model = new KupacDodajVM
            {
                Kupac = new Kupac(),
                BrojTokena = 50
                //gradovi = db.Grad.Select(x => new SelectListItem
                //{
                //    Text = x.Naziv,
                //    Value = x.GradID.ToString()
                //}).ToList()

            };

            return View(model);
        }
        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Kupac k = db.Kupac.Where(i => i.KupacID == id).FirstOrDefault();
            List<Recenzija> komList = db.Recenzija.Where(x => x.KupacID == id).ToList();
            foreach (var kom in komList)
            {
                db.Recenzija.Remove(kom);
            }
            db.Kupac.Remove(k);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
        public IActionResult Snimi(KupacDodajVM model)
        {
            MyContext db = new MyContext();

            KorisnickiNalog korisnickiNalog = new KorisnickiNalog();
            db.KorisnickiNalog.Add(korisnickiNalog);
            db.SaveChanges();

            Kupac kupac = model.Kupac;
            kupac.BrojTokena = 50;
            List<int> nalozi = db.KorisnickiNalog.Select(x => x.KorisnickiNalogID).ToList();
            kupac.KorisnickiNalogID = nalozi.LastOrDefault();
            db.Kupac.Add(kupac);

            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");

        }
        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Kupac k = db.Kupac.Where(x => x.KupacID == id).FirstOrDefault();
            KupacUrediVM model = new KupacUrediVM()
            {
                kupacid = id,
                //gradovi = db.Grad.Select(x => new SelectListItem()
                //{
                //    Value = x.GradID.ToString(),
                //    Text = x.Naziv
                //}).ToList(),
                BrojTelefona = k.BrojTelefona,
                Ime = k.Ime,
                Prezime = k.Prezime,
                Email = k.Email
            };
            db.Dispose();
            return View(model);
        }
        public IActionResult SnimiUredi(KupacUrediVM model)
        {

            MyContext db = new MyContext();
            Kupac kupac = db.Kupac.Where(i => i.KupacID == model.kupacid).FirstOrDefault();

            kupac.Email = model.Email;
            kupac.BrojTelefona = model.BrojTelefona;
            kupac.Ime = model.Ime;
            kupac.Prezime = model.Prezime;
            kupac.KupacID = model.kupacid;
            //List<SelectListItem> grad = db.Grad.Select(i => new SelectListItem
            //{
            //    Text = i.Naziv,
            //    Value = i.GradID.ToString()
            //}).ToList();
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");

        }
    }
}