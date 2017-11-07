using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AdminPage.Api;
using AdminPage.Models.Account;
using AdminPage.Models.Account.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdminPage.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            string jsonString = JsonConvert.SerializeObject(loginViewModel);
            HttpResponseMessage httpResponseMessage = await ApiClient.PostAsync("/Account/login", jsonString);
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Restricted()
        {
            HttpResponseMessage httpResponseMessage = await ApiClient.GetAsync("/Account/Restricted");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            HttpResponseMessage httpResponseMessage = await ApiClient.GetAsync("/Account/signOut");

            return RedirectToAction("Login");
        }
    }
}