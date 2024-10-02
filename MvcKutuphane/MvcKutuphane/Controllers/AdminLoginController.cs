using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TBLADMIN a)
        {
            var bilgiler = db.TBLADMIN.FirstOrDefault(x => x.KULLANICI == a.KULLANICI && x.SIFRE == a.SIFRE);  
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICI, false);  // Bu, ASP.NET Forms Authentication kullanarak kullanıcıyı kimliklendirir. Kullanıcı adını (burada bilgiler.KULLANICI) ve bir süre (burada false olarak belirtilmiş, oturumun kalıcı olmadığını gösterir) alarak bir kimlik doğrulama çerezi oluşturur.
                Session["Kullanici"] = bilgiler.KULLANICI.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return View();
            }           
        }
    }
}