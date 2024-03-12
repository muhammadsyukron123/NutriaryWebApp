
using Dapper;
using NutriaryWebApp.BO.BO;
using NutriaryWebApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace NutriaryWebApp.DAL.DAL
{
    public class NutriaryDAL : IConsumedFoods
    {

        private string GetConnectionString()
        {
            //return @"Data Source=BSINB23L011\BSISQLEXPRESS;Initial Catalog=NutriaryDatabase;Integrated Security=True;TrustServerCertificate=True";
            //return ConfigurationManager.ConnectionStrings["NutriaryDatabaseConnectionString"].ConnectionString;
            return Helper.GetConnectionString();
        }
        public void Create(ConsumedFoods obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteFoodLog(int log_id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"usp_DeleteFoodLog";
                var param = new { log_id = log_id };
                conn.Execute(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsumedFoods> GetAll()
        {
            throw new NotImplementedException();
        }

        public ConsumedFoods GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConsumedFoods> GetFoodNutritionByID(int userID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"GetConsumedFoodsToday";
                var param = new { user_id = userID };
                var results = conn.Query<ConsumedFoods>(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public IEnumerable<ConsumedFoods> GetFoodNutritionByIDandName(int userID, string foodName)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"GetConsumedFoodsToday";
                var param = new { user_id = userID, food_name = foodName };
                var results = conn.Query<ConsumedFoods>(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public void Update(ConsumedFoods obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateFoodQuantity(int log_id, decimal quantity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"usp_UpdateFoodQuantity";
                var param = new { log_id = log_id, new_quantity = quantity };
                conn.Execute(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void AddFoodConsumption(int userID, string foodName, decimal quantity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"usp_AddFoodConsumptionByName";
                var param = new { user_id = userID, food_name = foodName, quantity = quantity };
                conn.Execute(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<GetAllFood> GetAllFood()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"usp_GetAllFood";
                var results = conn.Query<GetAllFood>(sqlSP, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public IEnumerable<GetFoodInformationByLogID> GetFoodInformationByLogID(int log_id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"GetFoodInformationByLogId";
                var param = new { log_id = log_id };
                var results = conn.Query<GetFoodInformationByLogID>(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public IEnumerable<FoodDetails> GetFoodDetailsByLogId(int log_id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"usp_GetFoodDetailsByLogId";
                var param = new { log_id = log_id };
                var results = conn.Query<FoodDetails>(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public DailyTotalNutritionInfo GetDailyTotalNutrition(int userID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"usp_GetTotalNutritionPerDay";
                var param = new { user_id = userID };
                var results = conn.QueryFirstOrDefault<DailyTotalNutritionInfo>(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public IEnumerable<DailyFoodMenu> GetDailyFoodMenuOnDate(int userID, DateTime date)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"usp_GetDailyFoodMenu";
                var param = new { user_id = userID, log_date = date };
                var results = conn.Query<DailyFoodMenu>(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public DailyTotalNutrition GetDailyTotalNutritionByDate(int userID, DateTime date)
        {
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"usp_GetTotalNutritionByDate";
                var param = new { user_id = userID, log_date = date };
                var results = conn.QueryFirstOrDefault<DailyTotalNutrition>(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public CalorieSummary GetCalorieSummaryToday(int userID)
        {
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"usp_GetCalorieSummary";
                var param = new { user_id = userID };
                var results = conn.QueryFirstOrDefault<CalorieSummary>(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }
    }
}
