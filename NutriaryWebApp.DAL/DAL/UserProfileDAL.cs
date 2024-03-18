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
            return Helper.GetConnectionString();
        }
        public void AddUserProfile(AddUserProfileBO userProfile)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    var sqlSP = @"usp_InsertUserProfile";
                    var param = new
                    {
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
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public UserProfileBO GetUserProfile(int user_id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"ViewUserProfile";
                var param = new { user_id = user_id };
                return conn.QueryFirstOrDefault<UserProfileBO>(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateUserProfile(UpdateUserProfileBO updateUserProfileBO)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"usp_InsertUserProfile";
                var param = new
                {
                    user_id = updateUserProfileBO.user_id,
                    gender = updateUserProfileBO.gender,
                    age = updateUserProfileBO.age,
                    weight = updateUserProfileBO.weight,
                    height = updateUserProfileBO.height,
                    activity_level_id = updateUserProfileBO.ActivityLevel,
                    target_goal_id = updateUserProfileBO.TargetGoal
                };
                conn.Execute(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateUserAccount(UpdateUserAccountBO updateUserAccountBO)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"usp_UpdateUserAccount";
                var param = new
                {
                    user_id = updateUserAccountBO.user_id,
                    new_firstname = updateUserAccountBO.firstname,
                    new_lastname = updateUserAccountBO.lastname,
                    new_username = updateUserAccountBO.username,
                    new_email = updateUserAccountBO.email
                };
                conn.Execute(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public User GetUserAccount(int user_id)
        {
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlQuery = $"Select*from Users where user_id = @user_id";
                var param = new { user_id = user_id };
                return conn.QueryFirstOrDefault<User>(sqlQuery, param);
            }
        }
    }
}
