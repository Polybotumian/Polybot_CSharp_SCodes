using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkOt.Models.Context;
using OkOt.Models.Entities;

namespace OkOt.Controllers
{
    public class AkademisyenController : Controller
    {
        private OkOtContext dbContext = new OkOtContext();

        // GET: Akademisyen
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AkademEkle()
        {
            ViewBag.Bolumler = new SelectList(dbContext.Bolums.ToList(), "BolumKod", "BolumAdi");
            return View();
        }
        [HttpPost]
        public ActionResult AkademEkle(Akademisyen eklenenAkadem)
        {
            try
            {
                dbContext.Akademisyens.Add(eklenenAkadem);
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
            List<Akademisyen> Akademisyenler = dbContext.Akademisyens.ToList();
            return View(Akademisyenler);
        }

        [HttpGet]
        public ActionResult AkademGuncelle(int id)
        {
            var secilenAkadem = dbContext.Akademisyens.Find(id);
            if (secilenAkadem == null)
            {
                TempData["FMessage"] = "Aranan kayıt bulunamadı.";
            }
            ViewBag.Bolumler = new SelectList(dbContext.Bolums.ToList(), "BolumKod", "BolumAdi");
            return View(secilenAkadem);
        }

        [HttpPost]
        public ActionResult AkademGuncelle(Akademisyen secilenOgr)
        {
            if (secilenOgr.PersonelKod == 0)
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
        public ActionResult DersEkle()
        {
            ViewBag.dersler = new SelectList(dbContext.Derslers.ToList(), "DersKod", "DersAdi");
            return View();
        }
        [HttpPost]
        public ActionResult DersEkle(AkademisyenDersler eklenenAkademDers)
        {

            dbContext.AkademisyenDerslers.Attach(eklenenAkademDers);
                dbContext.AkademisyenDerslers.Add(eklenenAkademDers);
                dbContext.SaveChanges();
                TempData["SMessage"] = "Kayıt işlemi başarılı.";
            
                TempData["FMessage"] = "Kayıt işlemi başarısız";
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GirdDersler()
        {
            ViewBag.Bolumler = new SelectList(dbContext.Derslers.ToList(), "BolumKod", "BolumAdi");
            var AkademDers = dbContext.AkademisyenDerslers.ToList();
            return View(AkademDers);
        }

        [HttpGet]
        public ActionResult AkademSil(int id)
        {
            dbContext.Akademisyens.Remove(dbContext.Akademisyens.Find(id));
            dbContext.SaveChanges();
            if (dbContext.Ogrencis.Find(id) == null)
            {
                TempData["SMessage"] = "Silme başarılı.";
            }
            return RedirectToAction("Index");
        }
    }
}