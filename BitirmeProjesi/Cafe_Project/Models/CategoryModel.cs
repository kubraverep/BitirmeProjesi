using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cafe_Project.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Category_Name { get; set; }
        public int Count { get; set; }//kategoriye ait cafe sayısı
        //oluşturduğumuz kategori modeliyle veri tabanındaki kategorileri ilişkilendireceğiz (_CategoryList metodunda)
    }
}