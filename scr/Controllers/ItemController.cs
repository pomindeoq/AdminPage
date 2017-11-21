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
        public ActionResult CreateItems(List<int> items)
        {

            
            foreach (var item in items)
            {
                Debug.WriteLine(item);
            }
            return Ok();
        }

       
    }
}