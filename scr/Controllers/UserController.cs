using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using AdminPage.Api;
using Newtonsoft.Json;
using AdminPage.Models;

namespace AdminPage.Controllers
{
    public class UserController : Controller
    {
        HttpClient client;
        string url = "http://localhost:54443";

        public UserController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: User

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetUsers()
        {
            HttpResponseMessage response = await client.GetAsync("api/User/getUsers");

            if (response.IsSuccessStatusCode)
            {
                var UsersResponse = response.Content.ReadAsStringAsync().Result;

                var usersResponse = JsonConvert.DeserializeObject<UsersResponse>(UsersResponse);

                return Json(new { data = usersResponse.Users });
            }

            return View("Error");
        }

       
       
        // GET: User/Edit/5
        [HttpGet]
        public async Task<ActionResult> EditUser(int id)
        {
            HttpResponseMessage response = await ApiClient.GetAsync("/User/GetUser");
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;

                var Employee = JsonConvert.DeserializeObject<User>(responseData);

                return View(new User());
            }
            return View("Error");
        }

        // POST: User/Edit/5
        [HttpPost]        
        public async Task<ActionResult> EditUser(int id, IFormCollection collection)
        {
            HttpResponseMessage responseMesssage = await ApiClient.PostAsync("/Item/createItemCategory", id.ToString());

            responseMesssage.EnsureSuccessStatusCode();

            return View();
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}