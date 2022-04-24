using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Identity klosörüne eklediğimiz entity sınıfları olan applicationrole ve applicationuser sınıflarını yönetecek bir datacontext 
namespace Cafe_Project.Identity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext() : base("IdentityConnection")
        {

        }
    }
}