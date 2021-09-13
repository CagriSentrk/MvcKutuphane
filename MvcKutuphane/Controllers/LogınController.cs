using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class LogınController : Controller
    {
        // GET: Logın
        KUTUPHANEEntities db = new KUTUPHANEEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLPERSONEL p)
        {
            var bilgiler = db.TBLPERSONEL.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgiler != null)
            {
                Session["Ad"] = bilgiler.PERSONEL.ToString();
                Session["Maıl"] = bilgiler.MAIL.ToString();
                Session["Sifre"] = bilgiler.SIFRE.ToString();
                Session["Telefon"] = bilgiler.TELEFON.ToString();
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
        }
    }
}