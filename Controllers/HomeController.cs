using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonMvc.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace PersonMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (IDbConnection db = new SqlConnection("Data Source = localhost;Initial Catalog = Person;Integrated Security=True;"))
            {
                var li = db.Query<Person>("Select * from Person").ToList();
                return View();
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
