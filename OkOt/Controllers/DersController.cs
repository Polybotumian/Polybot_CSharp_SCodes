using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkOt.Models.Context;
using OkOt.Models.Entities;

namespace OkOt.Controllers
{
    public class DersController : Controller
    {
        private OkOtContext dbContext = new OkOtContext();

        // GET: Ders
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DersEkle()
        {
            ViewBag.Bolumler = new SelectList(dbContext.Bolums.ToList(), "BolumKod", "BolumAdi");
            return View();
        }
        [HttpPost]
        public ActionResult DersEkle(Dersler eklenenDers)
        {
            try
            {
                dbContext.Derslers.Add(eklenenDers);
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
            List<Dersler> dersler = dbContext.Derslers.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult DersGuncelle(int id)
        {
            var secilenAkadem = dbContext.Derslers.Find(id);
            if (secilenAkadem == null)
            {
                TempData["FMessage"] = "Aranan kayıt bulunamadı.";
            }
            ViewBag.Bolumler = new SelectList(dbContext.Bolums.ToList(), "BolumKod", "BolumAdi");
            return View(secilenAkadem);
        }

        [HttpPost]
        public ActionResult DersGuncelle(Dersler secilenDers)
        {
            if (secilenDers.DersKod == 0)
            {
                TempData["FMessage"] = "secilenDers.OgrenciNo değişkeninin id'si bulunamadı.";
            }
            else if (secilenDers != null)
            {
                TempData["SMessage"] = "Güncelleme başarılı.";
            }
            dbContext.Entry(secilenDers).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DersSil(int id)
        {
            dbContext.Derslers.Remove(dbContext.Derslers.Find(id));
            dbContext.SaveChanges();
            if (dbContext.Ogrencis.Find(id) == null)
            {
                TempData["SMessage"] = "Silme başarılı.";
            }
            return RedirectToAction("Index");
        }
    }
}