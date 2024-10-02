using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class AyarlarController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // GET: Ayarlar       
        public ActionResult Index2()
        {
            var degerler = db.TBLADMIN.ToList();
            return View(degerler);
        }
    }
}