using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminPage.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Identity;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace AdminPage.Controllers
{
    public class HomeController : Controller
    {
        
       
       
        //get users
        public IActionResult Index() { 
                  

            return View();
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    

    }
}
