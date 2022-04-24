using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cafe_Project.Entity;

namespace Cafe_Project.Controllers
{
    public class CafeController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Cafe
        public ActionResult Index()
        {
            var cafes = db.Cafes.Include(c => c.Category);
            return View(cafes.ToList());
        }

        // GET: Cafe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cafe cafe = db.Cafes.Find(id);
            if (cafe == null)
            {
                return HttpNotFound();
            }
            return View(cafe);
        }

        // GET: Cafe/Create
        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.Categories, "Category_ID", "Name");
            return View();
        }

        // POST: Cafe/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Cafe cafe, HttpPostedFileBase File) //Cafe Create viewindeki resim inputundaki name=File
        {
            //resmi nereye kaydetmek istiyorsak ona bir yol tanımlamalıyız

            string path = Path.Combine("/Content/images/" + File.FileName);
            File.SaveAs(Server.MapPath(path));
            cafe.Image = File.FileName.ToString();
            db.Cafes.Add(cafe);
            db.SaveChanges();
            //veritabanına kaydet, kaydettikten sonra index sayfasına gir
            return RedirectToAction("Index");
        }

        // GET: Cafe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cafe cafe = db.Cafes.Find(id);
            if (cafe == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_ID = new SelectList(db.Categories, "Category_ID", "Name", cafe.Category_ID);
            return View(cafe);
        }

        // POST: Cafe/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cafe_ID,Cafe_Name,Cafe_Information,Cafe_Description,Cafe_Menu,Image,Slider,IsHome,IsFeatured,Category_ID")] Cafe cafe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cafe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_ID = new SelectList(db.Categories, "Category_ID", "Name", cafe.Category_ID);
            return View(cafe);
        }

        // GET: Cafe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cafe cafe = db.Cafes.Find(id);
            if (cafe == null)
            {
                return HttpNotFound();
            }
            return View(cafe);
        }

        // POST: Cafe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cafe cafe = db.Cafes.Find(id);
            db.Cafes.Remove(cafe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
