using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        KUTUPHANEEntities db = new KUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x=>x.ISLEMDURUM==false).ToList();
            return View(degerler); 
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }
        [HttpPost] //butona tıklandığında bu çalışsın.
        public ActionResult OduncVer(TBLHAREKET p)
        {
            db.TBLHAREKET.Add(p); //tblkategori ye ekleme yapmak için yazılan satır.
            db.SaveChanges();    //değişikliklerin kaydedilmesi için yazılan satır.
            return View(); // en son sayfayı geri dönüdren satır. 
        }
        public ActionResult OduncIade(TBLHAREKET p)
        {
            var odn = db.TBLHAREKET.Find(p.ID);
            return View("OduncIade", odn);
        }
        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var hrkt = db.TBLHAREKET.Find(p.ID);
            hrkt.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hrkt.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}