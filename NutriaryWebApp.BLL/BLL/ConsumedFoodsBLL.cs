using NutriaryWebApp.BLL.DTOs;
using NutriaryWebApp.BLL.Interfaces;
using NutriaryWebApp.BO.BO;
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

        public CalorieSummaryDTO GetCalorieSummaryToday(int userID)
        {
            CalorieSummaryDTO calorieSummaryDTO = new CalorieSummaryDTO();
            var calorieSummary = _consumedFoods.GetCalorieSummaryToday(userID);

            if (calorieSummary == null)
            {
                calorieSummaryDTO.user_id = 0;
                calorieSummaryDTO.log_date = DateTime.Now;
                calorieSummaryDTO.BMR = 0;
                calorieSummaryDTO.consumed_calories = 0;
                calorieSummaryDTO.remaining_calories = 0;
                return calorieSummaryDTO;
            }
            else
            {
                calorieSummaryDTO.user_id = calorieSummary.user_id;
                calorieSummaryDTO.log_date = calorieSummary.log_date;
                calorieSummaryDTO.BMR = calorieSummary.BMR;
                calorieSummaryDTO.consumed_calories = calorieSummary.consumed_calories;
                calorieSummaryDTO.remaining_calories = calorieSummary.remaining_calories;
                return calorieSummaryDTO;
            }
        }

        public IEnumerable<DailyFoodMenuDTO> GetDailyFoodMenuOnDate(int userID, DateTime date)
        {
            List<DailyFoodMenuDTO> dailyFoodMenuDTOs = new List<DailyFoodMenuDTO>();
            var dailyFoodMenu = _consumedFoods.GetDailyFoodMenuOnDate(userID, date);
            foreach (var item in dailyFoodMenu)
            {
                dailyFoodMenuDTOs.Add(new DailyFoodMenuDTO
                {
                    log_id = item.log_id,
                    quantity = item.quantity,
                    log_date = item.log_date,
                    food_name = item.food_name,
                    energy_kal = item.energy_kal,
                    protein_g = item.protein_g,
                    fat_g = item.fat_g,
                    carbs_g = item.carbs_g,
                    fiber_g = item.fiber_g,
                    calcium_mg = item.calcium_mg,
                    fe_mg = item.fe_mg,
                    natrium_mg = item.natrium_mg
                });
            }
            return dailyFoodMenuDTOs;
        }

        public DailyTotalNutritionInfoDTO GetDailyTotalNutrition(int userID)
        {
            DailyTotalNutritionInfoDTO dailyTotalNutritionDTO = new DailyTotalNutritionInfoDTO();
            var dailyTotalNutrition = _consumedFoods.GetDailyTotalNutrition(userID);

            if (dailyTotalNutrition == null)
            {
                dailyTotalNutritionDTO.total_energy_kal = 0;
                dailyTotalNutritionDTO.total_protein_g = 0;
                dailyTotalNutritionDTO.total_fat_g = 0;
                dailyTotalNutritionDTO.total_carbs_g = 0;
                dailyTotalNutritionDTO.total_fiber_g = 0;
                dailyTotalNutritionDTO.total_calcium_mg = 0;
                dailyTotalNutritionDTO.total_energy_kal = 0;
                dailyTotalNutritionDTO.total_natrium_mg = 0;
                dailyTotalNutritionDTO.total_bmr = 0;
                dailyTotalNutritionDTO.total_fe_mg = 0;
                dailyTotalNutritionDTO.remaining_bmr = 0;
                return dailyTotalNutritionDTO;
            }
            else
            {
                dailyTotalNutritionDTO.total_energy_kal = dailyTotalNutrition.total_energy_kal;
                dailyTotalNutritionDTO.total_protein_g = dailyTotalNutrition.total_protein_g;
                dailyTotalNutritionDTO.total_fat_g = dailyTotalNutrition.total_fat_g;
                dailyTotalNutritionDTO.total_carbs_g = dailyTotalNutrition.total_carbs_g;
                dailyTotalNutritionDTO.total_fiber_g = dailyTotalNutrition.total_fiber_g;
                dailyTotalNutritionDTO.total_calcium_mg = dailyTotalNutrition.total_calcium_mg;
                dailyTotalNutritionDTO.total_energy_kal = dailyTotalNutrition.total_energy_kal;
                dailyTotalNutritionDTO.total_natrium_mg = dailyTotalNutrition.total_natrium_mg;
                dailyTotalNutritionDTO.total_bmr = dailyTotalNutrition.total_bmr;
                dailyTotalNutritionDTO.total_fe_mg = dailyTotalNutrition.total_fe_mg;
                dailyTotalNutritionDTO.remaining_bmr = dailyTotalNutrition.remaining_bmr;

                return dailyTotalNutritionDTO;
            }
        }

        public DailyTotalNutritionDTO GetDailyTotalNutritionByDate(int userID, DateTime date)
        {
            DailyTotalNutritionDTO dailyTotalNutritionDTO = new DailyTotalNutritionDTO();
            var dailyTotalNutritionByDate = _consumedFoods.GetDailyTotalNutritionByDate(userID, date);

            if (dailyTotalNutritionByDate == null)
            {
                dailyTotalNutritionDTO.total_energy_kal = 0;
                dailyTotalNutritionDTO.total_protein_g = 0;
                dailyTotalNutritionDTO.total_fat_g = 0;
                dailyTotalNutritionDTO.total_carbs_g = 0;
                dailyTotalNutritionDTO.total_fiber_g = 0;
                dailyTotalNutritionDTO.total_calcium_mg = 0;
                dailyTotalNutritionDTO.total_energy_kal = 0;
                dailyTotalNutritionDTO.total_natrium_mg = 0;
                dailyTotalNutritionDTO.total_bmr = 0;
                dailyTotalNutritionDTO.total_fe_mg = 0;
                dailyTotalNutritionDTO.remaining_bmr = 0;
                return dailyTotalNutritionDTO;
            }
            else
            {
                dailyTotalNutritionDTO.total_energy_kal = dailyTotalNutritionByDate.total_energy_kal;
                dailyTotalNutritionDTO.total_protein_g = dailyTotalNutritionByDate.total_protein_g;
                dailyTotalNutritionDTO.total_fat_g = dailyTotalNutritionByDate.total_fat_g;
                dailyTotalNutritionDTO.total_carbs_g = dailyTotalNutritionByDate.total_carbs_g;
                dailyTotalNutritionDTO.total_fiber_g = dailyTotalNutritionByDate.total_fiber_g;
                dailyTotalNutritionDTO.total_calcium_mg = dailyTotalNutritionByDate.total_calcium_mg;
                dailyTotalNutritionDTO.total_energy_kal = dailyTotalNutritionByDate.total_energy_kal;
                dailyTotalNutritionDTO.total_natrium_mg = dailyTotalNutritionByDate.total_natrium_mg;
                dailyTotalNutritionDTO.total_bmr = dailyTotalNutritionByDate.total_bmr;
                dailyTotalNutritionDTO.total_fe_mg = dailyTotalNutritionByDate.total_fe_mg;
                dailyTotalNutritionDTO.remaining_bmr = dailyTotalNutritionByDate.remaining_bmr;

                return dailyTotalNutritionDTO;
            }
        }

        public IEnumerable<FoodDetailsDTO> GetFoodDetailsByLogId(int log_id)
        {
            List<FoodDetailsDTO> foodDetailsDTOs = new List<FoodDetailsDTO>();
            var foodDetails = _consumedFoods.GetFoodDetailsByLogId(log_id);
            foreach (var item in foodDetails)
            {
                foodDetailsDTOs.Add(new FoodDetailsDTO
                {
                    log_id = item.log_id,
                    food_id = item.food_id,
                    food_name = item.food_name,
                    quantity = item.quantity,
                    total_energy_kcal = item.total_energy_kcal,
                    log_date = item.log_date,
                    total_carbs_g = item.total_carbs_g,
                    total_protein_g = item.total_protein_g,
                    total_fat_g = item.total_fat_g,
                    total_fiber_g = item.total_fiber_g,
                    total_calcium_mg = item.total_calcium_mg,
                    total_iron_mg = item.total_iron_mg,
                    total_natrium_mg = item.total_natrium_mg
                });
            }
            return foodDetailsDTOs;
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
