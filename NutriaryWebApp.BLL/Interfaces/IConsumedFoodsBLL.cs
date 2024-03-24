using NutriaryWebApp.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.Interfaces
{
    public interface IConsumedFoodsBLL
    {
        IEnumerable<ConsumedFoodsDTO> GetFoodNutritionByID(int userID);

        IEnumerable<ConsumedFoodsDTO> GetFoodNutritionByIDandName(int userID, string foodName);
        void UpdateFoodQuantity(int log_id, decimal quantity);

        void DeleteFoodLog(int log_id);

        void AddFoodConsumption(AddFoodConsumptionDTO addFoodConsumptionDTO);

        IEnumerable<FoodNameListDTO> foodNameLists();

        IEnumerable<GetFoodInformationByLogIDTO> GetFoodInformationByLogID(int log_id);

        IEnumerable<FoodDetailsDTO> GetFoodDetailsByLogId(int log_id); 

        DailyTotalNutritionInfoDTO GetDailyTotalNutrition(int userID);

        DailyTotalNutritionDTO GetDailyTotalNutritionByDate(int userID, DateTime date);

        IEnumerable<DailyFoodMenuDTO> GetDailyFoodMenuOnDate(int userID, DateTime date);

        CalorieSummaryDTO GetCalorieSummaryToday(int userID);



        //IEnumerable<GetAllFoodDTO> GetAllFood();



        //IEnumerable<ConsumedFoodsOnDateDTO> consumedFoodsOnDates(int userID, DateTime date);

    }
}
