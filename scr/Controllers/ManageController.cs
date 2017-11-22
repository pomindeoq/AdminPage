using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdminPage.Models;
using AdminPage.Api;
using System.Net.Http;
using AdminPage.Models.Items;
using AdminPage.Models.Manage;
using AdminPage.Models.Points;
using Newtonsoft.Json;

namespace AdminPage.Controllers
{
    public class ManageController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "User");
        }

        // GET: Manage
        [HttpGet, Route("manage/id={id}")]
        public async Task<ActionResult> Index(string id, ManageViewModel manageViewModel)
        {
            HttpResponseMessage httpResponseMessage = await ApiClient.GetAsync("/User/getUser/id=" + id);

            httpResponseMessage.EnsureSuccessStatusCode();

            var userResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;

            var userInfoResponse = JsonConvert.DeserializeObject<UserResponse>(userResponse);

            if (userInfoResponse.User == null)
            {
                return RedirectToAction("Index", "User");
            }

            manageViewModel.Username = userInfoResponse.User.Name;
            manageViewModel.Email = userInfoResponse.User.Email;
            manageViewModel.UserPoints = userInfoResponse.User.Points;


            TempData["UserId"] = id;

            return View(manageViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> CreateExchange(ItemExchangeModel itemExchangeModel)
        {
            string userId = (string)TempData["UserId"];

            itemExchangeModel.NewOwnerAccountId = userId;
            string jsonString = JsonConvert.SerializeObject(itemExchangeModel);

            HttpResponseMessage httpResponseMessage = await ApiClient.PostAsync("/Item/exchangeItem", jsonString);
            httpResponseMessage.EnsureSuccessStatusCode();
            string responseResult = httpResponseMessage.Content.ReadAsStringAsync().Result;
            var itemExchangeResponse = JsonConvert.DeserializeObject<ItemExchangeResponse>(responseResult);

            TempData["ExchangeErrors"] = itemExchangeResponse.Errors;

            return RedirectToAction("Index", new {id = userId});
        }

        [HttpPost]
        public async Task<ActionResult> GivePoints(ManagePointsModel managePointsModel)
        {
            string userId = (string)TempData["UserId"];

            AddPointsModel addPointsModel = new AddPointsModel();

            addPointsModel.UserId = userId;
            addPointsModel.Value = managePointsModel.Points;

            string jsonString = JsonConvert.SerializeObject(addPointsModel);

            HttpResponseMessage responseMessage = await ApiClient.PostAsync("/Point/addPoints", jsonString);

            string responseResult = responseMessage.Content.ReadAsStringAsync().Result;
            AddPointsResponse addPointsResponse = JsonConvert.DeserializeObject<AddPointsResponse>(responseResult);

            if (addPointsResponse.Succeeded)
            {
                string[] message = { "Points added to account" };

                TempData["ManagePointMessage"] = message;
            }
            else
            {
                TempData["ManagePointMessage"] = addPointsResponse.Errors;
            }

            return RedirectToAction("Index", new { id = userId });
        }

        [HttpPost]
        public async Task<ActionResult> BuyPoints(ManagePointsModel managePointsModel)
        {
            string userId = (string)TempData["UserId"];

            BuyPointsModel buyPointsModel = new BuyPointsModel
            {
                UserId = userId,
                Value = managePointsModel.Points,
                Price = managePointsModel.Price
            };

            string jsonString = JsonConvert.SerializeObject(buyPointsModel);

            HttpResponseMessage responseMessage = await ApiClient.PostAsync("/Point/buyPoints", jsonString);

            string responseResult = responseMessage.Content.ReadAsStringAsync().Result;
            AddPointsResponse addPointsResponse = JsonConvert.DeserializeObject<AddPointsResponse>(responseResult);

            if (addPointsResponse.Succeeded)
            {
                string[] message = { "Points purchased successfully." };

                TempData["ManagePointMessage"] = message;
            }
            else
            {
                TempData["ManagePointMessage"] = addPointsResponse.Errors;
            }

            return RedirectToAction("Index", new { id = userId });
        }

        [HttpPost]
        public async Task<ActionResult> RemovePoints(ManagePointsModel managePointsModel)
        {
            string userId = (string)TempData["UserId"];

            AddPointsModel addPointsModel = new AddPointsModel();

            addPointsModel.UserId = userId;
            addPointsModel.Value = managePointsModel.Points;

            string jsonString = JsonConvert.SerializeObject(addPointsModel);

            HttpResponseMessage responseMessage = await ApiClient.PostAsync("/Point/removePoints", jsonString);

            string responseResult = responseMessage.Content.ReadAsStringAsync().Result;
            AddPointsResponse addPointsResponse = JsonConvert.DeserializeObject<AddPointsResponse>(responseResult);

            if (addPointsResponse.Succeeded)
            {
                string[] message = { "Points removed from the account" };

                TempData["ManagePointMessage"] = message;
            }
            else
            {
                TempData["ManagePointMessage"] = addPointsResponse.Errors;
            }


            return RedirectToAction("Index", new { id = userId });
        }

        
    }
}