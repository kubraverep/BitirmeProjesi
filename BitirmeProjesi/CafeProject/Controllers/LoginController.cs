using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeProject.Models;
using System.Data.SqlClient;
using System.Data;

namespace CafeProject.Controllers
{

    public class LoginController : Controller
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
            con.ConnectionString = "data source=DESKTOP-ERMPMNU; database=CafeProject; integrated security= SSPI;";
        }

        [HttpPost]

        public IActionResult Verify(Customer customer)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Customer where Customer_Email='" + customer.Email + "'and Customer_Password='" + customer.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View();
                 

            }
            else
            {
                con.Close();
                return View();

            }



        }
    }
}
