using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        KUTUPHANEEntities db = new KUTUPHANEEntities();
        // GET: Yazar
        public ActionResult Index()
        {
            var degerler = db.TBLYAZAR.ToList();//Yazardaki ki verileri tablo seklinde listeleyecek.
            return View(degerler);
           
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();

        }
        [HttpPost]
        public ActionResult YazarEkle(TBLYAZAR p)
        {
            db.TBLYAZAR.Add(p);//databasede TBLYAZAR ı bulup oluşturduğumuz p değişkeni ile veritabanına yeni yazar ekliyor.
            db.SaveChanges();    
            return View(); 
        }
        public ActionResult YazarSil(int id)
        {
            var yzr = db.TBLYAZAR.Find(id); //oluşturduğum id değişkeni ile TBLYAZAR içinde aranan elemanı bulup silmesini sağlıyor.
            db.TBLYAZAR.Remove(yzr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TBLYAZAR.Find(id);
            return View("YazarGetir", yzr);
        }
        public ActionResult YazarGuncelle(TBLYAZAR p)
        {
            var yzr = db.TBLYAZAR.Find(p.ID);
            yzr.AD = p.AD;
            yzr.SOYAD = p.SOYAD;
            yzr.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}