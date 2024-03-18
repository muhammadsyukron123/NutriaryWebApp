using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutriaryWebApp.BLL.DTOs;
using NutriaryWebApp.BLL.Interfaces;

namespace NutriaryWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private IConsumedFoodsBLL _consumedFoodsBLL;

        public HomeController(IConsumedFoodsBLL consumedFoodsBLL)
        {
            _consumedFoodsBLL = consumedFoodsBLL;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var user = JsonSerializer.Deserialize<UserLoginDTO>(HttpContext.Session.GetString("User"));
            var userID = user.user_id;

            var nutrition = _consumedFoodsBLL.GetDailyTotalNutrition(userID);
            var summary = _consumedFoodsBLL.GetCalorieSummaryToday(userID);

            var serializedSummary = JsonSerializer.Serialize(summary);
            var serializedNutrition = JsonSerializer.Serialize(nutrition);
            TempData["Title"] = "Nutriary Dashboard";

            HttpContext.Session.SetString("CaloriesSummary", serializedSummary);
            HttpContext.Session.SetString("Nutrition", serializedNutrition);

            return View();
        }

        public IActionResult About()
        {
            return Content("Hello from About Controller");
        }

        public IActionResult Contact()
        {

            return Content("Hello from Contact Controller");

        }
    }
}