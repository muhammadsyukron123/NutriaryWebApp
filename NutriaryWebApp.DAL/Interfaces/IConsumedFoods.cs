using NutriaryWebApp.BO.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.DAL.Interfaces
{
    public interface IConsumedFoods : ICrud<ConsumedFoods>
    {
        IEnumerable<ConsumedFoods> GetFoodNutritionByID(int userID);

        IEnumerable<ConsumedFoods> GetFoodNutritionByIDandName(int userID, string foodName);

        void UpdateFoodQuantity(int log_id, decimal quantity);

        void DeleteFoodLog(int log_id);

        void AddFoodConsumption(int userID, string foodName, decimal quantity);

        IEnumerable<GetAllFood> GetAllFood();

        IEnumerable<GetFoodInformationByLogID> GetFoodInformationByLogID(int log_id);

        //IEnumerable<GetAllFood> GetAllFood();

        //IEnumerable<ConsumptionDate> consumptionDates(int userID);

        //IEnumerable<ConsumedFoodsOnDate> consumedFoodsOnDates(int userID, DateTime date);


    }
}
