﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // GET: Uye
        public ActionResult Index(int sayfa=1)
        {      
            var degerler = db.TBLUYELER.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }

            db.TBLUYELER.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult UyeSil(int id)
        {
            var uyeler = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(uyeler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(TBLUYELER p)
        {
            var uye = db.TBLUYELER.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KULLNICIADI = p.KULLNICIADI;
            uye.SIFRE = p.SIFRE;
            uye.TELEFON = p.TELEFON;
            uye.OKUL = p.OKUL;
            uye.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeKitapGecmis(int id)
        {
            var kitapgecmis = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            var uyekitap = db.TBLUYELER.Where(y => y.ID == id).Select(z => z.AD + z.SOYAD).FirstOrDefault();
            ViewBag.uyeKitap = uyekitap;
            return View(kitapgecmis);
        }
    }
}