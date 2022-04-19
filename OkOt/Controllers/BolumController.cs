using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkOt.Models.Context;
using OkOt.Models.Entities;

namespace OkOt.Controllers
{
    public class BolumController : Controller
    {
        private OkOtContext dbContext = new OkOtContext();

        // GET: Bolum
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult KaytListele()
        {
            List<Bolum> bolumler = dbContext.Bolums.ToList();
            return View(bolumler);
        }

        [HttpGet]
        public ActionResult BolmEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BolmEkle(Bolum eklenenBolum)
        {
            try
            {
                dbContext.Bolums.Add(eklenenBolum);
                dbContext.SaveChanges();
                TempData["SMessage"] = "Kayıt işlemi başarılı.";
            }
            catch
            {
                TempData["FMessage"] = "Kayıt işlemi başarısız";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult BolmGuncelle(int id)
        {
            var secilenBolm = dbContext.Bolums.Find(id);
            if (secilenBolm == null)
            {
                TempData["FMessage"] = "Aranan kayıt bulunamadı.";
            }
            //ViewBag.Bolumler = new SelectList(dbContext.Bolums.ToList(), "BolumKod", "BolumAdi");
            return View(secilenBolm);
        }

        [HttpPost]
        public ActionResult BolmGuncelle(Bolum secilenBolm)
        {
            if (secilenBolm.BolumKod == 0)
            {
                TempData["FMessage"] = "secilenOgr.OgrenciNo değişkeninin id'si bulunamadı.";
            }
            else if (secilenBolm != null)
            {
                TempData["SMessage"] = "Güncelleme başarılı.";
            }
            //dbContext.Database.ExecuteSqlCommand($"DBCC CHECKIDENT('Bolum', RESEED, {dbContext.Bolums.Count()})");
            dbContext.Entry(secilenBolm).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult BolmSil(int id)
        {
            dbContext.Bolums.Remove(dbContext.Bolums.Find(id));
            dbContext.SaveChanges();
            if (dbContext.Bolums.Find(id) == null)
            {
                TempData["SMessage"] = "Silme başarılı.";
            }
            return RedirectToAction("Index");
        }
    }
}