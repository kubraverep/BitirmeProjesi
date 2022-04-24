using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Cafe_Project.Entity
{
    public class Cafe
    {
        [Key]
        public int Cafe_ID { get; set; }
        public string Cafe_Name { get; set; }
        public string Cafe_Information { get; set; }
        public string Cafe_Description { get; set; }
        public string Cafe_Menu { get; set; }
        public string Image { get; set; }
        public bool Slider { get; set; }
        public bool IsHome { get; set; } /*sliderdaki resim anasayfada olacak mı *IsHome*/
        public bool IsFeatured { get; set; } /*öne çıkan cafe*/
        public string  Kapasite { get; set; }
        public int BosMasa { get; set; }
        public int DoluMasa { get; set; }
        public string YogunlukDurumu  { get; set; }
        public int Category_ID { get; set; } // category tablosuyla ilişki kurduk foreign key
        public Category Category{ get; set; } // HEr bir ürünn kategori sınıfından bir kategorisi olacak


    }
}