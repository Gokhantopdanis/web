using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcKutuphane.Models.Entity;
using System.Web.Security;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // GET: Login
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TBLUYELER p)
        {
            var bilgiler = db.TBLUYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
        }
    }
}