using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdminPage.Models;
using AdminPage.Api;
using System.Net.Http;
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

            var UserInfoResponse = JsonConvert.DeserializeObject<UserResponse>(userResponse);

            if (UserInfoResponse.User == null)
            {
                return RedirectToAction("Index", "User");
            }

            manageViewModel.Username = UserInfoResponse.User.Name;

            manageViewModel.Email = UserInfoResponse.User.Email;        

            return View(manageViewModel);
        }

        // GET: Manage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Manage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Manage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manage/Delete/5
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