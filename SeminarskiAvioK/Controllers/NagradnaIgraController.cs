using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiAvio_K;
using SeminarskiAvio_K.Models;
using SeminarskiAvioK.Helper;
using SeminarskiAvioK.Models;
using SeminarskiAvio_K.Models;

namespace SeminarskiAvioK.Controllers
{
    public class NagradnaIgraController : Controller
    {
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();
            NagradnaIgraPrikazVM model = new NagradnaIgraPrikazVM()
            {
                nagrade = db.NagradnaIgra.Select(x => new NagradnaIgraPrikazVM.row()
                {
                    Naziv = x.Naziv,
                    id = x.NagradnaIgraID,
                    Opis = x.Opis,
                    Kraj = x.Kraj,
                    Pocetak = x.Pocetak
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();

            NagradnaIgraDodajVM model = new NagradnaIgraDodajVM()
            {
                NagradnaIgra = new NagradnaIgra()
            };
            return View(model);
        }

        public IActionResult Snimi(NagradnaIgraDodajVM model)
        {
            KorisnickiNalog admin = HttpContext.GetLogiraniKorisnik();
            MyContext db = new MyContext();
            NagradnaIgra n = new NagradnaIgra
            {
                Naziv = model.NagradnaIgra.Naziv,
                Opis = model.NagradnaIgra.Opis,
                Pocetak = model.NagradnaIgra.Pocetak,
                Kraj = model.NagradnaIgra.Kraj,
                AdminID = admin.KorisnickiNalogID,
                Admin = db.Admin.Where(x => x.KorisnickiNalogID == admin.KorisnickiNalogID).FirstOrDefault(),
            };
            db.NagradnaIgra.Add(n);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");

        }

        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            NagradnaIgra n = db.NagradnaIgra.Find(id);

            List<KupacNagradnaIgra> kniList = db.KupacNagradnaIgra.Where(x => x.NagradnaIgraID == id).ToList();
            foreach (var kni in kniList)
            {
                db.KupacNagradnaIgra.Remove(kni);
            }

            db.NagradnaIgra.Remove(n);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            NagradnaIgra n = db.NagradnaIgra.Where(x => x.NagradnaIgraID == id).FirstOrDefault();

            NagradnaIgraUrediVM model = new NagradnaIgraUrediVM()
            {
                id = n.NagradnaIgraID,
                Naziv = n.Naziv,
                Pocetak = n.Pocetak,
                Kraj = n.Kraj,
                Opis = n.Opis
            };

            db.Dispose();
            return View(model);
        }

        public IActionResult UrediSnimi(NagradnaIgraUrediVM model)
        {
            MyContext db = new MyContext();
            NagradnaIgra igra = db.NagradnaIgra.Where(x => x.NagradnaIgraID == model.id).FirstOrDefault();

            igra.NagradnaIgraID = model.id;
            igra.Naziv = model.Naziv;
            igra.Opis = model.Opis;
            igra.Pocetak = model.Pocetak;
            igra.Kraj = model.Kraj;

            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi/" + model.id);
        }


        public IActionResult DodijeliNagradu(int id)
        {
            MyContext db = new MyContext();

            NagradnaIgra n = db.NagradnaIgra.Where(x => x.NagradnaIgraID == id).FirstOrDefault();

            Random random = new Random();

            var list = db.Kupac.ToList();
            int brojKupaca = list.Count;
            int[] nizKupci = new int[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                nizKupci[i] = list[i].KupacID;
            }

            int _kupac = random.Next(0, brojKupaca);

            KupacNagradnaIgraDodajVM model = new KupacNagradnaIgraDodajVM()
            {
                KupacNagradnaIgra = new KupacNagradnaIgra(),
                kupacId = nizKupci[_kupac],
                nagradnaIgraId = n.NagradnaIgraID,
                Kupac = db.Kupac.Select(x => new SelectListItem()
                {
                    Value = x.KupacID.ToString(),
                    Text = x.Ime + " " + x.Prezime
                }).ToList(),
                NagradnaIgra = db.NagradnaIgra.Select(x => new SelectListItem()
                {
                    Value = x.NagradnaIgraID.ToString(),
                    Text = x.Naziv
                }).ToList(),
            };




            //Kupac x = await _apiServiceKupac.GetById<Kupac>(req.KupacId);
            //int brojTokenaZaPoklon = random.Next(5, 20);
            //x.BrojTokena += brojTokenaZaPoklon;
            //await _apiServiceKupac.Update<Kupac>(req.KupacId, x);

            //KupacNagradnaIgra kn = model.KupacNagradnaIgra;
            //db.KupacNagradnaIgra.Add(kn);
            //db.SaveChanges();
            db.Dispose();
            return View(model);
        }

        public IActionResult NagradnaIgraSnimi(KupacNagradnaIgraDodajVM model)
        {
            MyContext db = new MyContext();
            KupacNagradnaIgra kn = model.KupacNagradnaIgra;

            kn.KupacID = model.kupacId;
            List<SelectListItem> kupac = db.Kupac.Select(x => new SelectListItem()
            {
                Value = x.KupacID.ToString(),
                Text = x.Ime
            }).ToList();
            kupac = model.Kupac;

            kn.NagradnaIgraID = model.nagradnaIgraId;
            List<SelectListItem> igra = db.NagradnaIgra.Select(x => new SelectListItem()
            {
                Value = x.NagradnaIgraID.ToString(),
                Text = x.Naziv
            }).ToList();
            igra = model.NagradnaIgra;

            db.KupacNagradnaIgra.Add(kn);

            Random random = new Random();

            Kupac k = db.Kupac.Find(model.kupacId);
            int brojTokenaZaPoklon = random.Next(5, 20);
            k.BrojTokena += brojTokenaZaPoklon;
            db.Kupac.Update(k);

            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi/" + model.KupacNagradnaIgra.KupacNagradnaIgraID);
        }



        public IActionResult PrikaziKupceINagrade()
        {
            MyContext db = new MyContext();
            NagradnaIgraKupacPrikazVM model = new NagradnaIgraKupacPrikazVM()
            {
                lista = db.KupacNagradnaIgra.Select(x => new NagradnaIgraKupacPrikazVM.Row()
                {
                    Id = x.KupacNagradnaIgraID,
                    KupacId = x.KupacID,
                    NagradnaIgraId = x.NagradnaIgraID,
                    Kupac = x.Kupac.Ime + " " + x.Kupac.Prezime,
                    Nagrada = x.NagradnaIgra.Naziv
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }
    }
}