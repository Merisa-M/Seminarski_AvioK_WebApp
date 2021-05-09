using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeminarskiAvio_K;
using SeminarskiAvio_K.Models;
using SeminarskiAvioK.Helper;
using SeminarskiAvioK.Models;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace SeminarskiAvioK.Controllers
{
    public class KlijentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Novosti()
        {
            MyContext db = new MyContext();
            NovostiPrikaziVM model = new NovostiPrikaziVM()
            {

                novosti = db.Novosti.Select(x => new NovostiPrikaziVM.row()
                {
                    id = x.NovostiID,
                    Naziv = x.Naziv,
                    DatumObjave = x.DatumVrijemeObjave,
                    AdresaSlike = x.AdresaSlike,
                    Sadrzaj = x.KratkiSadrzaj
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult NovostiOpsirnije(int id)
        {
            MyContext db = new MyContext();
            NovostiPrikaziVM model = new NovostiPrikaziVM()
            {
                novosti = db.Novosti.Where(x => x.NovostiID == id).Select(x => new NovostiPrikaziVM.row()
                {
                    id = x.NovostiID,
                    Naziv = x.Naziv,
                    DatumObjave = x.DatumVrijemeObjave,
                    AdresaSlike = x.AdresaSlike,
                    Sadrzaj = x.KratkiSadrzaj
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }
        public IActionResult NagradneIgre()
        {
            MyContext db = new MyContext();
            NagradnaIgraPrikazVM model = new NagradnaIgraPrikazVM()
            {
                nagrade = db.NagradnaIgra.Select(x => new NagradnaIgraPrikazVM.row()
                {
                    id = x.NagradnaIgraID,
                    Naziv = x.Naziv,
                    Pocetak = x.Pocetak,
                    Kraj = x.Kraj
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult NagradneIgreOpsirnije(int id)
        {
            MyContext db = new MyContext();
            NagradnaIgraPrikazVM model = new NagradnaIgraPrikazVM()
            {
                nagrade = db.NagradnaIgra.Where(x => x.NagradnaIgraID == id).Select(x => new NagradnaIgraPrikazVM.row()
                {
                    id = x.NagradnaIgraID,
                    Naziv = x.Naziv,
                    Opis = x.Opis,
                    Pocetak = x.Pocetak,
                    Kraj = x.Kraj,
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }


        public IActionResult ONama()
        {
            return View();
        }

        public IActionResult Galerija()
        {
            return View();
        }


        public IActionResult MojeRezervacije(int id)
        {
            MyContext db = new MyContext();

            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            RezervacijaPrikaziVM model = new RezervacijaPrikaziVM()
            {
                kupacid = id,
                rezervacije = db.Rezervacija.Where(x => x.Kupac.KorisnickiNalog.KorisnickoIme == korisnik.KorisnickoIme).Select(x => new RezervacijaPrikaziVM.row()
                {
                    DatumIsteka = x.DatumIsteka,
                    DatumRezervacije = x.DatumRezervacije,
                    id = x.RezervacijaID,
                    ImePrezime = x.Kupac.Ime + x.Kupac.Prezime,
                    Odobren = x.Odobrena
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult MojeKarte(int id)
        {
            MyContext db = new MyContext();

            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            KartePrikaziVM model = new KartePrikaziVM()
            {
                KupacID = id,

                karte = db.Karta.Where(x => x.Kupac.KorisnickiNalog.KorisnickoIme == korisnik.KorisnickoIme).Select(x => new KartePrikaziVM.row()
                {

                    karteiD = x.KartaID,
                    let = x.Let.Grad.Naziv,
                    ImePrezime = x.Kupac.Ime + x.Kupac.Prezime,
                    sjedista = "Red: " + x.Sjediste.Red + "; Kolona: " + x.Sjediste.Kolona,
                    //putovanje = db.Rezervacija.Where(y => y.RezervacijaID == x.RezervacijaID).Include(y => y.Let).ThenInclude(y => y.Klasa).Select(y => y.Let.Grad.Naziv + " / " + y.Let.VrijemePolaska).FirstOrDefault(),
                    Cijena = db.Rezervacija.Where(y => y.RezervacijaID == x.RezervacijaID).Include(y => y.Let).Select(y => y.Let.Cijena).FirstOrDefault()

                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult KarteDetalji(int id)
        {
            MyContext db = new MyContext();

            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            KartePrikaziVM model = new KartePrikaziVM()
            {

                KupacID = id,

                karte = db.Karta.Where(x => x.KartaID == id).Select(x => new KartePrikaziVM.row()
                {
                    karteiD = x.KartaID,
                    ImePrezime = x.Kupac.Ime + " " + x.Kupac.Prezime,
                    sjedista = "Red: " + x.Sjediste.Red + "; Kolona: " + x.Sjediste.Kolona,
                    let = db.Rezervacija.Where(y => y.RezervacijaID == x.RezervacijaID).Include(y => y.Let).ThenInclude(y => y.Klasa).Select(y => y.Let.Grad.Naziv + " / " + y.Let.VrijemePolaska).FirstOrDefault(),
                    Cijena = db.Rezervacija.Where(y => y.RezervacijaID == x.RezervacijaID).Include(y => y.Let).Select(y => y.Let.Cijena).FirstOrDefault()
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult Putovanja()
        {
            MyContext db = new MyContext();
            PutovanjaPrikaziVM model = new PutovanjaPrikaziVM()
            {
                putovanja = db.Putovanja.Select(x => new PutovanjaPrikaziVM.row()
                {
                    id = x.PutovanjaID,
                    Naziv = x.Naziv,
                    Opis = x.Opis,
                    NazivGrada = x.Grad.Naziv,
                    prosjecnaOcjena = x.ProsjecnaOcjena
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }


        public IActionResult OcijeniPutovanje(int id)
        {
            MyContext db = new MyContext();

            PutovanjeKupacVM model = new PutovanjeKupacVM()
            {
                putovanjeid = id,
                putovanje = db.Putovanja.Where(x => x.PutovanjaID == id).Select(x => x.Naziv).FirstOrDefault(),
                PutovanjeKupac = new PutovanjeKupac()
                {
                    PutovanjeID = id
                }
            };
            return View(model);
        }

        public IActionResult SnimiOcjenu(PutovanjeKupacVM model)
        {
            if (ModelState.IsValid)
            {
                KorisnickiNalog kupac = HttpContext.GetLogiraniKorisnik();
                MyContext db = new MyContext();

                PutovanjeKupac n = new PutovanjeKupac
                {
                    KupacID = kupac.KorisnickiNalogID,
                    Kupac = db.Kupac.Where(x => x.KorisnickiNalogID == kupac.KorisnickiNalogID).FirstOrDefault(),
                    Ocjena = model.PutovanjeKupac.Ocjena,
                    PutovanjeID = model.PutovanjeKupac.PutovanjeID
                };

                db.PutovanjeKupac.Add(n);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Putovanja");
            }

            return View("OcijeniPredstavu", model);
        }

        public IActionResult DodajRecenziju(int id)
        {
            MyContext db = new MyContext();

            RecenzijaDodajVM model = new RecenzijaDodajVM()
            {
                id = id,
                putovanje = db.Putovanja.Where(x => x.PutovanjaID == id).Select(x => x.Naziv).FirstOrDefault(),
                Recenzija = new Recenzija()
                {
                    PutovanjaID = id
                }

            };
            return View(model);
        }

        public IActionResult SnimiRecenziju(RecenzijaDodajVM model)
        {

            KorisnickiNalog kupac = HttpContext.GetLogiraniKorisnik();
            MyContext db = new MyContext();

            Recenzija k = new Recenzija
            {
                KupacID = kupac.KorisnickiNalogID,
                Kupac = db.Kupac.Where(x => x.KorisnickiNalogID == kupac.KorisnickiNalogID).FirstOrDefault(),
                PutovanjaID = model.Recenzija.PutovanjaID,
                Odobren = false,
                Sadrzaj = model.Recenzija.Sadrzaj,
                VrijemeKreiranja = DateTime.Now
            };
            db.Recenzija.Add(k);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Putovanja");

        }

        public IActionResult PrikazRecenzija(int id)
        {
            MyContext db = new MyContext();
            RecenzijePrikaziVM model = new RecenzijePrikaziVM()
            {
                putovanjeid = id,
                putovanje = db.Putovanja.Where(x => x.PutovanjaID == id).Select(x => x.Naziv).FirstOrDefault(),
                recenzije = db.Recenzija.Where(x => x.PutovanjaID == id).Select(x => new RecenzijePrikaziVM.row()
                {
                    putovanja = db.Putovanja.Where(y => y.PutovanjaID == id).Select(y => y.Naziv).FirstOrDefault(),
                    kupac = x.Kupac.Ime + " " + x.Kupac.Prezime,
                    VrijemeKreiranja = x.VrijemeKreiranja,
                    id = x.RecenzijaID,
                    sadrzaj = x.Sadrzaj,
                    Odobren = x.Odobren
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }





        public IActionResult Rezervacija(int id)
        {
            MyContext db = new MyContext();

            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();

            //int klijentid = korisnik.KorisnickiNalogID;
            Kupac k = db.Kupac.Where(x => x.KorisnickiNalog.KorisnickoIme == korisnik.KorisnickoIme).FirstOrDefault();
            Rezervacija r = new Rezervacija()
            {
                DatumRezervacije = DateTime.Now,
                DatumIsteka = db.Let.Where(x => x.LetID == id).FirstOrDefault().VrijemePolaska,
                Odobrena = false,
                KupacID = korisnik.KorisnickiNalogID,
                Kupac = db.Kupac.Where(x => x.KorisnickiNalogID == korisnik.KorisnickiNalogID).FirstOrDefault(),
                LetID = id,
                Let = db.Let.Find(id)
            };

            db.Rezervacija.Add(r);
            string kupac = db.Kupac.Where(x => x.KupacID == r.KupacID).Select(x => x.Ime + " " + x.Prezime).FirstOrDefault();
            string let = db.Let.Where(x => x.LetID == r.LetID).Select(x => x.Grad.Naziv + "/" + x.VrijemePolaska).FirstOrDefault();

            db.SaveChanges();
            {
                var message = new MimeMessage();
                message.To.Add(new MailboxAddress("avio_k.1234@outlook.com"));
                message.From.Add(new MailboxAddress("avio_k.1234@outlook.com"));

                message.Subject = "Zahtjev za rezervaciju";
                message.Body = new TextPart("plain")
                {
                    Text = "Dobili ste novi zahtjev za odobrenje rezervacije od kupca: " + kupac + ", za let: " + let
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.outlook.com", 587, false);

                    client.Authenticate("avio_k.1234@outlook.com", "avio_k");
                    client.Send(message);

                    client.Disconnect(true);
                }

                return RedirectToAction("MojeRezervacije");
            }
        }


        public IActionResult OdaberiSjediste(int id)
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            MyContext db = new MyContext();
            SjedisteKupacPrikaziVM model = new SjedisteKupacPrikaziVM()
            {
                lista = db.Sjediste.Select(x => new SjedisteKupacPrikaziVM.Row()
                {
                    SjedisteID = x.SjedisteID,
                    Kolona = x.Kolona,
                    Red = x.Red,
                    NazivKlase = x.Klasa.Naziv
                }).ToList()
            };
            db.Dispose();
            return View(model);

        }

        public decimal ProsjecnaOcjena(int id)
        {
            MyContext db = new MyContext();
            Putovanja p = db.Putovanja.Where(x => x.PutovanjaID == id).FirstOrDefault();
            p.ProsjecnaOcjena = db.PutovanjeKupac
                .Where(x => x.PutovanjeID == p.PutovanjaID)
                .Average(x => (decimal?)x.Ocjena) ?? new decimal();

            return p.ProsjecnaOcjena;
        }
        public IActionResult KupiKartu(int id)
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            MyContext db = new MyContext();

            Rezervacija r = db.Rezervacija.Where(x => x.RezervacijaID == id).FirstOrDefault();
            Let p = db.Let.Where(x => x.LetID == r.LetID).FirstOrDefault();
            List<Karta> ul = db.Karta.Where(x => x.LetID == p.LetID).Include(x => x.Sjediste).Include(x => x.Let)/*.Select(x=>x.SjedisteID)*/.ToList();
            Karta u = db.Karta.Where(x => x.LetID == p.LetID).FirstOrDefault();
            List<Sjediste> sjed = db.Sjediste.ToList();
            List<Sjediste> sjed2 = ul.Select(x => x.Sjediste).ToList();

            var lista = sjed.Except(sjed2);

            KarteDodajVM model = new KarteDodajVM()
            {
                Karta = new Karta()
                {
                    RezervacijaID = id
                },
                KupacID = korisnik.KorisnickiNalogID,
                Kupac = db.Kupac.Where(x => x.KorisnickiNalogID == korisnik.KorisnickiNalogID).Select(x => x.Ime + " " + x.Prezime).FirstOrDefault(),
                let = db.Rezervacija.Where(y => y.RezervacijaID == id).Include(y => y.Let).ThenInclude(y => y.Klasa).Select(y => y.Let.Klasa.Naziv + " / " + y.Let.VrijemePolaska).FirstOrDefault(),
                Cijena = db.Rezervacija.Where(y => y.RezervacijaID == id).Include(y => y.Let).Select(y => y.Let.Cijena).FirstOrDefault(),
                sjedista = lista.Select(m => new SelectListItem()
                {
                    Value = m.SjedisteID.ToString(),
                    Text =/*m.Sala.Naziv + ";*/ "Red: " + m.Red + " ; Kolona: " + m.Kolona
                }).ToList()

            };
            return View(model);
        }


        public IActionResult SnimiKartu(KarteDodajVM model)
        {
            KorisnickiNalog kupac = HttpContext.GetLogiraniKorisnik();
            MyContext db = new MyContext();

            Kupac k = db.Kupac.Where(x => x.KorisnickiNalogID == kupac.KorisnickiNalogID).FirstOrDefault();
            Rezervacija r = db.Rezervacija.Where(x => x.RezervacijaID == model.Karta.RezervacijaID).FirstOrDefault();
            Let p = db.Let.Where(x => x.LetID == r.LetID).FirstOrDefault();

            Karta karta = model.Karta;
            karta.KupacID = kupac.KorisnickiNalogID;
            karta.Kupac = db.Kupac.Where(x => x.KorisnickiNalogID == kupac.KorisnickiNalogID).FirstOrDefault();
            karta.RezervacijaID = model.Karta.RezervacijaID;
            karta.LetID = p.LetID;

            db.Karta.Add(karta);

            int cijena = Convert.ToInt32(p.Cijena);


            db.Kupac.Update(k);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("MojeKarte");


        }

        public IActionResult OtkaziRezervaciju(int id)
        {
            MyContext db = new MyContext();
            Rezervacija r = db.Rezervacija.Find(id);
            Let p = db.Let.Where(x => x.LetID == r.LetID).FirstOrDefault();
            if ((p.VrijemePolaska - DateTime.Now).TotalDays < 2)
            {
                TempData["error_poruka2"] = "Greška! Rezervaciju je moguće otkazati 2 dana prije prikazivanja!";
                return RedirectToAction("MojeRezervacije");
            }
            else
            {
                db.Rezervacija.Remove(r);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("MojeRezervacije");
            }

        }

        ////public IActionResult Detalji(int id)
        ////{
        ////    MyContext db = new MyContext();
        ////    Predstava s = db.Predstava.Where(x => x.PredstavaID == id).FirstOrDefault();
        ////    return View(s);
        ////}

        public IActionResult UrediProfil(int id)
        {
            MyContext db = new MyContext();

            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Kupac k = db.Kupac.Where(x => x.KorisnickiNalog.KorisnickoIme == korisnik.KorisnickoIme).FirstOrDefault();
            KorisnickiProfilVM model = new KorisnickiProfilVM()
            {
                KupacID = id,
                BrojTelefona = k.BrojTelefona,
                Ime = k.Ime,
                Prezime = k.Prezime,
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult SnimiProfil(KorisnickiProfilVM model)
        {

            MyContext db = new MyContext();
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Kupac k = db.Kupac.Where(x => x.KorisnickiNalog.Lozinka == korisnik.Lozinka).FirstOrDefault();

            k.Prezime = model.Prezime;
            k.Ime = model.Ime;
            k.BrojTelefona = model.BrojTelefona;

            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("ONama");
        }

        public IActionResult PromijeniLozinku(int id)
        {
            MyContext db = new MyContext();

            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Kupac k = db.Kupac.Where(x => x.KorisnickiNalog.KorisnickoIme == korisnik.KorisnickoIme).Include(x => x.KorisnickiNalog).FirstOrDefault();
            LoginVM model = new LoginVM()
            {

                Username = k.KorisnickiNalog.KorisnickoIme,
                Password = k.KorisnickiNalog.Lozinka
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult PromijeniLozinkuSnimi(LoginVM model)
        {

            MyContext db = new MyContext();
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Kupac k = db.Kupac.Where(x => x.KorisnickiNalog.KorisnickoIme == korisnik.KorisnickoIme).Include(x => x.KorisnickiNalog).FirstOrDefault();
            k.KorisnickiNalog.KorisnickoIme = model.Username;

            k.KorisnickiNalog.Lozinka = model.Password;

            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("ONama");
        }
    }
}