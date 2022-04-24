using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cafe_Project.Entity
{
    public class Category
    {
        [Key]
        public int Category_ID{ get; set; }
        public string Name { get; set; }
        public List<Cafe> Cafes { get; set; } // o kategoriye ait kafeleri getirecek

    }
}