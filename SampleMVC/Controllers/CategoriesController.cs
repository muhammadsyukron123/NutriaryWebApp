using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutriaryWebApp.BLL.BLL;
using NutriaryWebApp.BLL.DTOs;
using NutriaryWebApp.BLL.Interfaces;
using NutriaryWebMVC.Models;

namespace NutriaryWebMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IConsumedFoodsBLL _consumedFoodsBLL;

        public CategoriesController()
        {
            _consumedFoodsBLL = new ConsumedFoodsBLL();
        }


        private static List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Beverages" },
            new Category { Id = 2, Name = "Condiments" },
            new Category { Id = 3, Name = "Confections" }
        };
        public IActionResult Index()
        {
            List<User> users = new List<User>
            {
                new User { UserId = 1, Username = "sonywakwaw", Password = "password1" },
                new User { UserId = 2, Username = "bambangpacul", Password = "password2" },
                new User { UserId = 3, Username = "alfiansyahkomeng", Password = "password3" }
            };

            ViewData["Users"] = users;
            var models = _consumedFoodsBLL.GetFoodNutritionByID(10);

            return View(models);
        }

        // [Route("Categories/{Name}")]
        public IActionResult Detail(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            var models = _consumedFoodsBLL.GetFoodDetailsByLogId(id);
            return View(models);
        }


        public IActionResult Create()
        {
            var models = _consumedFoodsBLL.foodNameLists();

            return View(models);
        }

        [HttpPost]

        public IActionResult Create(string food_name, decimal quantity)
        {
            try
            {
                _consumedFoodsBLL.AddFoodConsumption(10, food_name, quantity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            //var category = _categories.FirstOrDefault(c => c.Id == id);
            var models = _consumedFoodsBLL.GetFoodInformationByLogID(id);
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

            //var editCategory = _categories.FirstOrDefault(c => c.Id == category.Id);

            _consumedFoodsBLL.UpdateFoodQuantity(foodInformation.log_id, foodInformation.quantity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return View("Index", _categories);
            }
            else
            {
                var categories = _categories.Where(c => c.Name.Contains(search));
                return View("Index", categories);
            }

        }

        public IActionResult Delete(int id)
        {
            _consumedFoodsBLL.DeleteFoodLog(id);
            return RedirectToAction("Index");
        }

    }
}