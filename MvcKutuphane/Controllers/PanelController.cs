using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
     
   
    public class PanelController : Controller
    {
        KUTUPHANEEntities db = new KUTUPHANEEntities();
        // GET: Panel
       [HttpGet]
    //[Authorize]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(TBLPERSONEL p)
        {
            var kullanici = (string)Session["Maıl"];
            var uye = db.TBLPERSONEL.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            db.SaveChanges();
            return View();
        }
    }
}