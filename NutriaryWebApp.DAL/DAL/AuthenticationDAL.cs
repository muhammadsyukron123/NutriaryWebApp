using Dapper;
using NutriaryWebApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace NutriaryWebApp.DAL.DAL
{
    public class AuthenticationDAL : IAuthentication
    {

        private string GetConnectionString()
        {
            //return @"Data Source=BSINB23L011\BSISQLEXPRESS;Initial Catalog=NutriaryDatabase;Integrated Security=True;TrustServerCertificate=True";
            return ConfigurationManager.ConnectionStrings["NutriaryDatabaseConnectionString"].ConnectionString;
        }
        public void UserLogin(string username, string password)
        {
            //connect to the usp_UserLogin store procedure
            
        }

        int IAuthentication.UserLogin(string username, string password, out int userId)
        {
            userId = 0;
            int loginResult = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    var sqlSP = @"usp_LoginUser";
                    var param = new { username = username, password = password };
                    var results = conn.QuerySingleOrDefault<dynamic>(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
                    loginResult = results.LoginResult;
                    userId = results.UserID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return loginResult;
            
            
        }
    }
}
