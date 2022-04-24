using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Cafe_Project.App_Start.Startup1))]

namespace Cafe_Project.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            
            // Uygulamanızı nasıl yapılandıracağınız hakkında daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=316888 adresini ziyaret edin
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                //UseCookieAuthentication asp.net identity freamworke bunun cookie bazlı bir autontication olduğunu belirtir
                AuthenticationType = "ApplicationCookie",     // hangi tip cookie ile işlem yapacağımızı belirtiyoruz
                LoginPath = new PathString("/Account/Login") //kullanıcı yetkisi olmayan bir alana erişmek istediğinde giriş yapması için yönlendirilmesini istediğimiz default login sayfası
            });
        }
    }
}
