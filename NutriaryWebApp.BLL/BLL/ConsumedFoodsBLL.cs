using NutriaryWebApp.BLL.DTOs;
using NutriaryWebApp.BLL.Interfaces;
using NutriaryWebApp.DAL.DAL;
using NutriaryWebApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.BLL
{
    public class ConsumedFoodsBLL : IConsumedFoodsBLL
    {
        private readonly IConsumedFoods _consumedFoods;

        public ConsumedFoodsBLL()
        {
            _consumedFoods = new NutriaryDAL();
        }

        public void AddFoodConsumption(int userID, string foodName, decimal quantity)
        {
            try
            {
                _consumedFoods.AddFoodConsumption(userID, foodName, quantity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteFoodLog(int log_id)
        {
            try
            {
                _consumedFoods.DeleteFoodLog(log_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<FoodNameListDTO> foodNameLists()
        {
            List<FoodNameListDTO> foodNameLists = new List<FoodNameListDTO>();
            var foodNames = _consumedFoods.GetAllFood();
            foreach (var item in foodNames)
            {
                foodNameLists.Add(new FoodNameListDTO
                {
                    food_id = item.food_id,
                    food_name = item.food_name
                });
            }
            return foodNameLists;
        }

        public IEnumerable<GetFoodInformationByLogIDTO> GetFoodInformationByLogID(int log_id)
        {
            List<GetFoodInformationByLogIDTO> getFoodInformationByLogIDTOs = new List<GetFoodInformationByLogIDTO>();
            var foodInformation = _consumedFoods.GetFoodInformationByLogID(log_id);
            foreach (var item in foodInformation)
            {
                getFoodInformationByLogIDTOs.Add(new GetFoodInformationByLogIDTO
                {
                    log_id = item.log_id,
                    food_name = item.food_name,
                    quantity = item.quantity
                });
            }
            return getFoodInformationByLogIDTOs;
        }

        public IEnumerable<ConsumedFoodsDTO> GetFoodNutritionByID(int userID)
        {
            List<ConsumedFoodsDTO> consumedFoodsDTOs = new List<ConsumedFoodsDTO>();
            var consumedFoods = _consumedFoods.GetFoodNutritionByID(userID);
            foreach (var item in consumedFoods)
            {
                consumedFoodsDTOs.Add(new ConsumedFoodsDTO
                {
                    log_id = item.log_id,
                    user_id = item.user_id,
                    food_id = item.food_id,
                    quantity = item.quantity,
                    log_date = item.log_date,
                    food_name = item.food_name,
                    total_energy_kcal = item.total_energy_kcal
                });
            }
            return consumedFoodsDTOs;
        }

        public IEnumerable<ConsumedFoodsDTO> GetFoodNutritionByIDandName(int userID, string foodName)
        {
            List<ConsumedFoodsDTO> consumedFoodsDTOs = new List<ConsumedFoodsDTO>();
            var consumedFoods = _consumedFoods.GetFoodNutritionByIDandName(userID, foodName);
            foreach (var item in consumedFoods)
            {
                consumedFoodsDTOs.Add(new ConsumedFoodsDTO
                {
                    log_id = item.log_id,
                    user_id = item.user_id,
                    food_id = item.food_id,
                    quantity = item.quantity,
                    log_date = item.log_date,
                    food_name = item.food_name,
                    total_energy_kcal = item.total_energy_kcal
                });
            }
            return consumedFoodsDTOs;
        }

        public void UpdateFoodQuantity(int log_id, decimal quantity)
        {
            try
            {
                _consumedFoods.UpdateFoodQuantity(log_id, quantity);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
