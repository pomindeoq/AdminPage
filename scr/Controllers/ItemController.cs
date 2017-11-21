using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdminPage.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        

        [HttpPost]
        public ActionResult CreateItems([FromBody] Data data)
        {

            
            foreach (var item in data.Items)
            {
                Debug.WriteLine(item);
            }
            return Ok();
        }

       
    }
    public class Data
    {
        public List<double> Items { get; set; }

    }
}