using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CafeProject.Models;


namespace CafeProject.Controllers
{
    public class CustomerLoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
         void connectionString()
        {
          con.ConnectionString = "data source=(localdb)/MSSQLLocalDB; database=CafeProject; integrated security=SSPI;";
        }
        [HttpPost]
        public ActionResult Verify( CustomerLogin customer)
        {
            
            connectionString();
            con.Open();
            
            com.Connection = con;
            com.CommandText = "select* from Customer where Customer_Email='" + customer.Email + "' and Customer_Password='" + customer.Passsword + "'";
            dr = com.ExecuteReader();
            
            if (dr.Read())
            {
                con.Close();
                return View("Index", "Home");
                
            }
            else
            {
                con.Close();
                return View();
                
            }
            
        }
    }
}
