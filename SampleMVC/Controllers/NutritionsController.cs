using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutriaryWebApp.BLL.BLL;
using NutriaryWebApp.BLL.DTOs;
using NutriaryWebApp.BLL.Interfaces;
using NutriaryWebMVC.Models;
using NutriaryWebMVC.ViewModels;

namespace NutriaryWebMVC.Controllers
{
    public class NutritionsController : Controller
    {
        private readonly IConsumedFoodsBLL _consumedFoodsBLL;

        public NutritionsController()
        {
            _consumedFoodsBLL = new ConsumedFoodsBLL();
        }


        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var user = JsonSerializer.Deserialize<UserLoginDTO>(HttpContext.Session.GetString("User"));
            var userID = user.user_id;
            var models = _consumedFoodsBLL.GetFoodNutritionByID(userID);

            TempData["Title"] = "Nutrition Log";

            return View(models);
        }

        public IActionResult Detail(int id)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var models = _consumedFoodsBLL.GetFoodDetailsByLogId(id);
            TempData["Title"] = "Nutrition Detail";
            return View(models);
        }


        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var models = _consumedFoodsBLL.foodNameLists();
            TempData["Title"] = "Add Nutrition Log";
            return View(models);
        }

        [HttpPost]

        public IActionResult Create(string food_name, decimal quantity)
        {
            try
            {
                var user = JsonSerializer.Deserialize<UserLoginDTO>(HttpContext.Session.GetString("User"));
                var userID = user.user_id;
                _consumedFoodsBLL.AddFoodConsumption(userID, food_name, quantity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var models = _consumedFoodsBLL.GetFoodInformationByLogID(id);
            TempData["Title"] = "Edit Nutrition Log";
            if (models == null)
            {
                return NotFound();
            }
            return View(models);
        }

        [HttpPost]
        public IActionResult Edit(GetFoodInformationByLogIDTO foodInformation)
        {
            if (foodInformation == null)
            {
                return BadRequest();
            }

            _consumedFoodsBLL.UpdateFoodQuantity(foodInformation.log_id, foodInformation.quantity);

            return RedirectToAction("Index");
        }

        public IActionResult DailyReport() {             
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var user = JsonSerializer.Deserialize<UserLoginDTO>(HttpContext.Session.GetString("User"));
            var userID = user.user_id;
            var nutritionReport = _consumedFoodsBLL.GetDailyTotalNutritionByDate(userID, DateTime.Now);
            var foodList = _consumedFoodsBLL.GetDailyFoodMenuOnDate(userID, DateTime.Now);
            var models = new DailyReportViewModel
            {
               dailyTotalNutritionDTO = nutritionReport,
               dailyFoodMenuDTO = foodList
            };

            TempData["Title"] = "Daily Nutrition Report";
            return View(models);
        }

        [HttpPost]
        public IActionResult DailyReport(DateTime date)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var user = JsonSerializer.Deserialize<UserLoginDTO>(HttpContext.Session.GetString("User"));
            var userID = user.user_id;
            var nutritionReport = _consumedFoodsBLL.GetDailyTotalNutritionByDate(userID, date);
            var foodList = _consumedFoodsBLL.GetDailyFoodMenuOnDate(userID, date);
            var models = new DailyReportViewModel
            {
                dailyTotalNutritionDTO = nutritionReport,
                dailyFoodMenuDTO = foodList
            };

            TempData["Title"] = "Daily Nutrition Report";
            return View(models);
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            throw new NotImplementedException();

        }

        public IActionResult Delete(int id)
        {
            _consumedFoodsBLL.DeleteFoodLog(id);
            return RedirectToAction("Index");
        }

    }
}