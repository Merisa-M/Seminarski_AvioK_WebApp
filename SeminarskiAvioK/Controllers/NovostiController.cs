using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeminarskiAvio_K;
using SeminarskiAvio_K.Models;
using SeminarskiAvioK.Helper;
using SeminarskiAvioK.Models;

namespace SeminarskiAvioK.Controllers
{
    public class NovostiController : Controller
    {
        public readonly IHostingEnvironment _hostingEnvironment;
        public NovostiController(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext(); ;
            NovostiPrikaziVM model = new NovostiPrikaziVM()
            {
                novosti = db.Novosti.Select(i => new NovostiPrikaziVM.row
                {
                    id = i.NovostiID,
                    Tekst = i.Tekst,
                    Sadrzaj = i.KratkiSadrzaj,
                    Naziv = i.Naziv,
                    DatumObjave = i.DatumVrijemeObjave,
                    AdresaSlike = i.AdresaSlike
                }).ToList()

            };
            db.Dispose();
            return View(model);
        }
        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();
            NovostiDodajVM model = new NovostiDodajVM
            {
                Novosti = new Novosti()

            };

            return View(model);

        }
        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Novosti novosti = db.Novosti.Find(id);
            db.Novosti.Remove(novosti);
            db.SaveChanges();
            return View("Prikazi");
        }

        public IActionResult Snimi(NovostiDodajVM model)
        {
            KorisnickiNalog nalog = HttpContext.GetLogiraniKorisnik();
            MyContext db = new MyContext();
            string uniqueFileName = null;
            if (model.Slika != null)
            {


                string unqureFIleName = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Slika.FileName;
                string filepath = Path.Combine(unqureFIleName, uniqueFileName);
                model.Slika.CopyTo(new FileStream(filepath, FileMode.Create));
            }
            Novosti novosti = new Novosti
            {
                AdresaSlike = uniqueFileName,
                DatumVrijemeObjave = DateTime.Now,
                Tekst = model.Novosti.Tekst,
                KratkiSadrzaj = model.Novosti.KratkiSadrzaj,
                Naziv = model.Novosti.Naziv,
                AdminID = nalog.KorisnickiNalogID,
                Admin = db.Admin.Where(x => x.KorisnickiNalogID == nalog.KorisnickiNalogID).FirstOrDefault()

            };
            db.Novosti.Add(novosti);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");

        }
        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();
            Novosti n = db.Novosti.Where(x => x.NovostiID == id).FirstOrDefault();
            NovostiUrediVM model = new NovostiUrediVM()
            {
                id = n.NovostiID,
                KratkiSadrzaj = n.KratkiSadrzaj,
                Tekst = n.Tekst,
                DatumVrijemeObjave = n.DatumVrijemeObjave,
                Naziv = n.Naziv,
                adresaaSlike = n.AdresaSlike
            };
            db.Dispose();
            return View(model);

        }
        public IActionResult UrediSnimi(NovostiUrediVM model)
        {
            MyContext db = new MyContext();
            Novosti novosti = db.Novosti.Where(x => x.NovostiID == model.id).FirstOrDefault();
            if (model.adresaaSlike != null)
            {
                novosti.AdresaSlike = model.adresaaSlike;
            }
            string uniqueFileName = null;
            IFormFile slika = model.Photo;

            if (slika != null)
            {


                string unqureFIleName = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filepath = Path.Combine(unqureFIleName, uniqueFileName);

                slika.CopyTo(new FileStream(filepath, FileMode.Create));
                novosti.AdresaSlike = uniqueFileName;
            }
            novosti.NovostiID = model.id;
            novosti.DatumVrijemeObjave = model.DatumVrijemeObjave;
            novosti.Naziv = model.Naziv;
            novosti.Tekst = model.Tekst;
            model.KratkiSadrzaj = model.KratkiSadrzaj;

            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
    }
}