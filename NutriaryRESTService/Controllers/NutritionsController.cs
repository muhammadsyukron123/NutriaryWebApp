using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriaryWebApp.BLL.DTOs;
using NutriaryWebApp.BLL.Interfaces;

namespace NutriaryRESTService.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionsController : ControllerBase
    {
        private IConsumedFoodsBLL _consumedFoodsBLL;

        public NutritionsController(IConsumedFoodsBLL consumedFoodsBLL)
        {
            _consumedFoodsBLL = consumedFoodsBLL;
            
        }

        [HttpGet]
        public IActionResult Get(int UserID, DateTime date)
        {
            var result = _consumedFoodsBLL.GetDailyFoodMenuOnDate(UserID, date);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddFoodConsumptionDTO consumedFood)
        {
            _consumedFoodsBLL.AddFoodConsumption(consumedFood);
            if (consumedFood != null)
            {
                return Ok(consumedFood);
            }
            return NotFound();
        }

        [HttpPut]
        public IActionResult Put(int log_id, decimal quantity)
        {
            _consumedFoodsBLL.UpdateFoodQuantity(log_id, quantity);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int log_id)
        {
            _consumedFoodsBLL.DeleteFoodLog(log_id);
            return Ok();
        }

        [HttpGet("FoodNutrition")]
        public IActionResult GetFoodNutritionByID(int userID)
        {
            var result = _consumedFoodsBLL.GetFoodNutritionByID(userID);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("FoodNutritionByName")]
        public IActionResult GetFoodNutritionByName(int userID, string foodName)
        {
            var result = _consumedFoodsBLL.GetFoodNutritionByIDandName(userID, foodName);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("FoodNameList")]
        public IActionResult GetFoodNameList()
        {
            var result = _consumedFoodsBLL.foodNameLists();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("FoodInformationByLogID")]
        public IActionResult GetFoodInformation(int log_id)
        {
            var result = _consumedFoodsBLL.GetFoodInformationByLogID(log_id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("FoodDetailsByLogID")]
        public IActionResult GetFoodDetails(int log_id)
        {
            var result = _consumedFoodsBLL.GetFoodDetailsByLogId(log_id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("DailyTotalNutrition")]
        public IActionResult GetDailyTotalNutrition(int userID)
        {
            var result = _consumedFoodsBLL.GetDailyTotalNutrition(userID);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("DailyTotalNutritionByDate")]

        public IActionResult GetDailyTotalNutritionByDate(int userID, DateTime date)
        {
            var result = _consumedFoodsBLL.GetDailyTotalNutritionByDate(userID, date);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("CalorieSummaryToday")]
        public IActionResult GetCalorieSummaryToday(int userID)
        {
            var result = _consumedFoodsBLL.GetCalorieSummaryToday(userID);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
