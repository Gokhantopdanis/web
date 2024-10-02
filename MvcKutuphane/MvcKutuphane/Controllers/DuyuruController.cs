using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // GET: Duyuru
        public ActionResult Index()
        {
            var degerler = db.TBLDUYURULAR.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniDuyuru()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDuyuru(TBLDUYURULAR t)
        {
            db.TBLDUYURULAR.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TBLDUYURULAR.Find(id);
            db.TBLDUYURULAR.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruDetay(TBLDUYURULAR p)
        {
            var duyuru = db.TBLDUYURULAR.Find(p.ID);
            return View("DuyuruDetay", duyuru);
        }

        public ActionResult DuyuruGuncelle(TBLDUYURULAR p)
        {
            var duyuru = db.TBLDUYURULAR.Find(p.ID);
            duyuru.KATEGORI = p.KATEGORI;
            duyuru.ICERIK = p.ICERIK;
            duyuru.TARIH = p.TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}