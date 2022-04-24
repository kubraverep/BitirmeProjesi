using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cafe_Project.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext> //modelde herhangi bir değişiklik olduğunda veritabanını silip yeniden oluşturur.
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category() {Name="BUTİK KAFELER"},
                new Category() {Name="KONSEPT KAFELER"},        
                new Category() {Name="KABARE"},
                new Category() {Name="ALL-DAY KAFELER"},
                new Category() {Name="GRAB-AND-GO KAFELER"}
            };
            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);// buraya gelen elemanları tek tek ekliyor
            }
            context.SaveChanges(); // bütün kategorileri veritabanına ekler

            var cafeler = new List<Cafe>()
            {
                new Cafe() {Cafe_Name="PEARL GARDEN",
                            Cafe_Description="Serin bir Sakarya gününe PEARL GARDEN'ın sıcak atmosferi ile başlayın",
                            Cafe_Information="Hizmet seçenekleri: İçeride servis · Arabaya servis · Temassız teslimat\n" +
                                             "Saatler:11:00-02:00\n" +
                                             "\nAdres: Kemalpaşa, Sipahi Sk. NO 8, 54200 Serdivan/Sakarya\n" +
                                             "\nTelefon: 0545 454 00 92\n",
                           Cafe_Menu="pearlgarden.dijital.menu",
                           Slider=true,IsHome=true,IsFeatured=true,Category_ID=1,Image="1.jpg"},
                new Cafe() {Cafe_Name="MILK BAR",
                            Cafe_Description="İçinizi ısıtacak türden konsept ve atmosferiyle güzel vakit geçirebilieceğiniz bir cafe",
                            Cafe_Information="Hizmet seçenekleri: İçeride servis\n" +
                                             "Saatler:11:00-02:00\n" +
                                             "\nAdres: İstiklal, Bağlar Cd. No:71/A, 54050 Serdivan/Sakarya\n" +
                                             "\nTelefon: 0545 454 00 92\n",
                            Cafe_Menu=".",
                            Slider=true,IsHome=false,IsFeatured=true,Category_ID=2,Image="2.jpg"},
                new Cafe() {Cafe_Name="COFFEE & STUDY",
                            Cafe_Description="Coffee And Study, Kahve dükkanı olarak hizmet vermektedir",
                            Cafe_Information="Hizmet seçenekleri: İçeride servis · Paket servisi · Temassız teslimat\n" +
                                             "Saatler:09:00-01:00\n" +
                                             "\nAdres: Kemalpaşa, Bağlar Cd. No 108 A, 54050 Serdivan/Sakarya\n" +
                                             "\nTelefon: (0264) 211 19 10\n",
                            Cafe_Menu=".",
                            Slider=true,IsHome=true,IsFeatured=true,Category_ID=5,Image="3.jpg"},
                new Cafe() {Cafe_Name="X COFFEE COMPANY",
                            Cafe_Description="Kaliteli kahveleri, güler yüzlü çalışanlarıyla Sakarya’da fark yaratan mekan.",
                            Cafe_Information="Hizmet seçenekleri: İçeride servis · Paket servisi · Temassız teslimat\n" +
                                             "Saatler:09:00-01:00\n" +
                                             "\nAdres:  Kemalpaşa, Sipahi Sk. No:6, 54050 Serdivan/Sakarya\n" +
                                             "\nTelefon: 0507 814 10 49\n",
                            Cafe_Menu=".",
                            Slider=true,IsHome=true,IsFeatured=true,Category_ID=3,Image="4.jpg"},

            };

            foreach (var cafe in cafeler)
            {
                context.Cafes.Add(cafe);// buraya gelen elemanları tek tek ekliyor
            }
            context.SaveChanges(); // bütün cafeleri veritabanına ekler
            base.Seed(context);
        }
    }
}