using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class VitrinlerController : Controller
    {
        // GET: Vitrinler
        KUTUPHANEEntities db = new KUTUPHANEEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var degerler = db.TBLKITAP.ToList();
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index(TBLILETISIM t)
        {
            db.TBLILETISIM.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}