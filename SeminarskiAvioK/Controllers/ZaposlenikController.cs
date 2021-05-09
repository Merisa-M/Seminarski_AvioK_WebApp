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
using SeminarskiAvioK.Models;

namespace SeminarskiAvioK.Controllers
{
    public class ZaposlenikController : Controller
    {
        public readonly IHostingEnvironment _hostingEnvironment;

        public ZaposlenikController(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();
            ZaposlenikPrikaziVM model = new ZaposlenikPrikaziVM()
            {
                zaposlenici = db.Zaposlenik.Select(i => new ZaposlenikPrikaziVM.row
                {
                    Id = i.ZaposlenikID,
                    Ime = i.Ime,
                    Prezime = i.Prezime,
                    DatumRodjenja = i.DatumRodjenja,
                    adresaaSlike = i.AdresaSlike,
                    BrojUgovora = i.BrojUgovora
                }).ToList()


            };
            return View(model);
        }
        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();
            ZaposenikDodajVM model = new ZaposenikDodajVM()
            {
                Zaposlenik = new Zaposlenik()

            };
            db.Dispose();
            return View(model);
        }
        public IActionResult Snimi(ZaposenikDodajVM model)
        {
            if (ModelState.IsValid)
            {
                MyContext db = new MyContext();
                string uniqueFileName = null;
                if (model.Photo != null)
                {

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Zaposlenik z = new Zaposlenik
                {
                    AdresaSlike = uniqueFileName,
                    BrojUgovora = model.Zaposlenik.BrojUgovora,
                    DatumRodjenja = model.Zaposlenik.DatumRodjenja,
                    Email = model.Zaposlenik.Email,
                    Ime = model.Zaposlenik.Ime,
                    Prezime = model.Zaposlenik.Prezime
                };
                db.Zaposlenik.Add(z);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Prikazi");
            }
            return View("Dodaj");
        }
        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Zaposlenik z = db.Zaposlenik.Find(id);

            List<ZaposlenikPutovanje> zp = db.ZaposlenikPutovanje.Where(x => x.ZaposlenikID == id).ToList();
            foreach (var za in zp)
            {
                db.ZaposlenikPutovanje.Remove(za);
            }

            db.Zaposlenik.Remove(z);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");

        }
        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Zaposlenik z = db.Zaposlenik.Where(x => x.ZaposlenikID == id).FirstOrDefault();

            ZaposlenikUrediVM model = new ZaposlenikUrediVM()
            {
                id = z.ZaposlenikID,
                adresaaSlike = z.AdresaSlike,
                BrojUgovora = z.BrojUgovora,
                DatumRodjenja = z.DatumRodjenja,
                Email = z.Email,
                Ime = z.Ime,
                Prezime = z.Prezime

            };
            db.Dispose();
            return View(model);
        }
        public IActionResult UrediSnimi(ZaposlenikUrediVM model)
        {
            if (ModelState.IsValid)
            {
                MyContext db = new MyContext();
                Zaposlenik z = db.Zaposlenik.Where(x => x.ZaposlenikID == model.id).FirstOrDefault();
                if (model.adresaaSlike != null)
                {
                    z.AdresaSlike = model.adresaaSlike;
                }

                string uniqueFileName = null;
                IFormFile slika = model.Photo;
                if (slika != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    z.AdresaSlike = uniqueFileName;
                }
                z.ZaposlenikID = model.id;
                z.DatumRodjenja = model.DatumRodjenja;
                z.BrojUgovora = model.BrojUgovora;
                z.Email = model.Email;
                z.Ime = model.Ime;
                z.Prezime = model.Prezime;

                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("/Prikazi/" + model.id);
            }
            return View("Uredi");
        }
    }
}