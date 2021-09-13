using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {

        // GET: Kategori
        KUTUPHANEEntities db = new KUTUPHANEEntities();//oluşturduğum nesne ile tablolara ulaşacağım.
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORI.ToList();//kategoride ki verileri tablo seklinde listeleyecek.
            return View(degerler);
        }
        [HttpGet] //sayfa yüklendiğinde bu çalışsın.
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost] //butona tıklandığında bu çalışsın.
        public ActionResult KategoriEkle(TBLKATEGORI p)
        {
            db.TBLKATEGORI.Add(p); //tblkategori ye ekleme yapmak için yazılan satır.
            db.SaveChanges();    //değişikliklerin kaydedilmesi için yazılan satır.
            return View(); // en son sayfayı geri dönüdren satır. 
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGuncelle(TBLKATEGORI p) 
        {
            var ktg = db.TBLKATEGORI.Find(p.ID);
            ktg.AD= p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}