using Microsoft.AspNetCore.Mvc;
using MVCLoginPage.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace MVCLoginPage.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private SqlDataReader dr;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        /* public List<UserModel> PutValue()
         {
             var users = new List<UserModel>
             {
                 new UserModel{Name="naveen",Password="kumar"},
                 new UserModel{Name="mnaveen",Password="kumar"},
             };
             return users;
         }*/
        void connectionString()
        {
            con.ConnectionString = @"data source=DESKTOP-U3DPIO7\SQLEXPRESS; database=StudentLogin;user=sa;pwd=Sql@123$;";
        }
        [HttpPost]
        public IActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tbl_login where username='" + acc.Name + "' and password='" + acc.Password + "'";
            dr = com.ExecuteReader();
            //var u = PutValue();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }

        }
    }
}
