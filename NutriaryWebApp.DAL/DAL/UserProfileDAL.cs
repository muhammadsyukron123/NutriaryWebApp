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
    public class UserProfileDAL : IUserProfile
    {
        private string GetConnectionString()
        {
            //return @"Data Source=BSINB23L011\BSISQLEXPRESS;Initial Catalog=NutriaryDatabase;Integrated Security=True;TrustServerCertificate=True";
            return ConfigurationManager.ConnectionStrings["NutriaryDatabaseConnectionString"].ConnectionString;
        }
        public void AddUserProfile(AddUserProfileBO userProfile)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"usp_InsertUserProfile";
                var param = new { 
                    user_id = userProfile.user_id, 
                    age = userProfile.age, 
                    gender = userProfile.gender,
                    weight = userProfile.weight, 
                    height = userProfile.height, 
                    activity_level_id = userProfile.activity_level_id,
                    target_goal_id = userProfile.target_goal_id
                };
                conn.QueryFirstOrDefault<AddUserProfileBO>(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<UserProfileBO> GetUserProfile(int user_id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"ViewUserProfile";
                var param = new { user_id = user_id };
                return conn.Query<UserProfileBO>(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateUserProfile(UpdateUserProfileBO userProfile)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"usp_UpdateUserProfile";
                var param = new
                {
                    user_id = userProfile.user_id,
                    gender = userProfile.gender,
                    age = userProfile.age,
                    weight = userProfile.weight,
                    height = userProfile.height,
                    ActivityLevel = userProfile.ActivityLevel,
                    TargetGoal = userProfile.TargetGoal
                };
            }
        }

        public void UpdateUserAccount(UpdateUserAccountBO userAccount)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"usp_UpdateUserAccount";
                var param = new
                {
                    user_id = userAccount.user_id,
                    firstname = userAccount.firstname,
                    lastname = userAccount.lastname,
                    username = userAccount.username,
                    email = userAccount.email
                };
            }
        }
    }
}
