using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // GET: Mesajlar
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x=>x.ALICI == uyemail.ToString()).ToList();
            return View(mesajlar);
        }

        public ActionResult Gonderilen()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.GONDEREN == uyemail.ToString()).ToList();
            return View(mesajlar);
        }

        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR p)
        {
            var uyemail = (string)Session["Mail"].ToString();
            p.GONDEREN = uyemail.ToString();
            p.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMESAJLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Gonderilen","Mesajlar");
        }

        public PartialViewResult Partial1()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var gelensayi = db.TBLMESAJLAR.Where(x => x.ALICI == uyemail).Count();
            ViewBag.gelensayi = gelensayi;
            var gidensayi = db.TBLMESAJLAR.Where(x => x.GONDEREN == uyemail).Count();
            ViewBag.gidensayi = gidensayi;
            return PartialView();
        }
    }
}