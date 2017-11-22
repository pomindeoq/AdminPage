using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AdminPage.Models.Items;
using Newtonsoft.Json;
using System.Net.Http;
using AdminPage.Api;

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
        public async Task<ActionResult> CreateItems([FromBody] ItemsInput itemsInput)
        {
            string userId = (string)TempData["UserId"];

            CreateItemsModel createItemsModel = new CreateItemsModel();

            createItemsModel.CategoryId = 1;
            createItemsModel.UserId = userId;
            createItemsModel.PointValues = itemsInput.Items;
            
            string jsonString = JsonConvert.SerializeObject(createItemsModel);
             
            HttpResponseMessage responseMessage = await ApiClient.PostAsync("/Item/createItems", jsonString);

            var responseResult = responseMessage.Content.ReadAsStringAsync().Result;

            var response = JsonConvert.DeserializeObject<CreateItemsResponse>(responseResult);

            TempData["UserId"] = userId;

            return Ok();
        }

       
    }
    
}