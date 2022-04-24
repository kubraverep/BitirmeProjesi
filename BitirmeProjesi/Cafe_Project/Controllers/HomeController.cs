using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cafe_Project.Entity;

namespace Cafe_Project.Controllers
{
    
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        public PartialViewResult _FeaturedCafeList()//her sayfada olacağından partial
        {
            return PartialView(db.Cafes.Where(i => i.IsFeatured).Take(5).ToList());//popüler olan ilk beş caafeyi getirir
        }

        public ActionResult Search(string q)//search için dışardan bbir ifade girileceği için bir parametre verdik
        {

            var p = db.Cafes.Where(i => i.IsHome == true);//sayfada olan ürünlerde arama yapacaktır
            if (!string.IsNullOrEmpty(q))//dışardan gelen q null değilse arama yap
            {
                p = p.Where(i => i.Cafe_Name.Contains(q) || i.Cafe_Description.Contains(q));
            }
            return View(p.ToList());
        }

        public PartialViewResult Slider()//her sayfada olacağından partial; popüler ve slider olan ilk beş ürünü getirir
        {
            return PartialView(db.Cafes.Where(i => i.IsFeatured&&i.Slider).Take(5).ToList());//popüler olan ilk beş caafeyi getirir
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Cafes.Where(i=>i.IsHome).ToList());
        }
        public ActionResult CafeDetails(int id)//dışardan bir id beklesin ve buraya gelen id ile sorgulama yapsın
        {
            return View(db.Cafes.Where(i=>i.Cafe_ID==id).FirstOrDefault());// firstOrDefoult yazmamızın nedeni geriye dönecek değer bir tane olduğu için
        }
        public ActionResult Cafes()//bu sayfaya tüm cafeler gelecek
        {
            return View(db.Cafes.ToList());
        }
        public ActionResult CafeList(int id)//o kategori IDsine ait cafeleri listele
        {
            return View(db.Cafes.Where(i=>i.Category_ID==id).ToList());
        }
    }
}