using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cafe_Project.Entity
{
    //Veritabanı ile iletişim sağlayacak context nesnemizi oluşturacak
    public class DataContext:DbContext
    {
        public DataContext():base("dataConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<Cafe> Cafes { get; set; }// Veritabanında oluşturacağımız tabloların ismi
        public DbSet<Category> Categories { get; set; }
    }
}