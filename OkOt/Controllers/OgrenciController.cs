using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkOt.Models.Context;
using OkOt.Models.Entities;

namespace OkOt.Controllers
{
    public class OgrenciController : Controller
    {
        private OkOtContext dbContext = new OkOtContext();

        // GET: Ogrenci

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult OgrEkle()
        {
            ViewBag.Bolumler = new SelectList(dbContext.Bolums.ToList(), "BolumKod", "BolumAdi");
            return View();
        }
        [HttpPost]
        public ActionResult OgrEkle(Ogrenci eklenenOgr)
        {
            try
            {
                dbContext.Ogrencis.Add(eklenenOgr);
                dbContext.SaveChanges();
                TempData["SMessage"] = "Kayıt işlemi başarılı.";
            }
            catch
            {
                TempData["FMessage"] = "Kayıt işlemi başarısız";
            }
            return RedirectToAction("Index");
        }

        public ActionResult KaytListele()
        {
            List<Ogrenci> ogrenciler = dbContext.Ogrencis.ToList();
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult OgrGuncelle(int id)
        {
            var secilenOgr = dbContext.Ogrencis.Find(id);
            if (secilenOgr == null)
            {
                TempData["FMessage"] = "Aranan kayıt bulunamadı.";
            }
            ViewBag.Bolumler = new SelectList(dbContext.Bolums.ToList(), "BolumKod", "BolumAdi");
            return View(secilenOgr);
        }

        [HttpPost]
        public ActionResult OgrGuncelle(Ogrenci secilenOgr)
        {
            if (secilenOgr.OgrenciId == 0)
            {
                TempData["FMessage"] = "secilenOgr.OgrenciNo değişkeninin id'si bulunamadı.";
            }
            else if (secilenOgr != null)
            {
                TempData["SMessage"] = "Güncelleme başarılı.";
            }
            dbContext.Entry(secilenOgr).State = System.Data.Entity.EntityState.Modified; 
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult OgrSil(int id)
        {
            dbContext.Ogrencis.Remove(dbContext.Ogrencis.Find(id));
            dbContext.SaveChanges();
            if (dbContext.Ogrencis.Find(id) == null)
            {
                TempData["SMessage"] = "Silme başarılı.";
            }
            return RedirectToAction("Index");
        }
    }
}