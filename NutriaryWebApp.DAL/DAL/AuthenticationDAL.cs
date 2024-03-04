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
    public class AuthenticationDAL : IAuthentication
    {
        public UserLogin LoginUser(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    var sqlSP = @"usp_LoginUser";
                    var param = new { username = username, password = password };
                    var results = conn.QueryFirstOrDefault<UserLogin>(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
                    return results;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetConnectionString()
        {
            //return @"Data Source=BSINB23L011\BSISQLEXPRESS;Initial Catalog=NutriaryDatabase;Integrated Security=True;TrustServerCertificate=True";
            return ConfigurationManager.ConnectionStrings["NutriaryDatabaseConnectionString"].ConnectionString;
        }

    }
}
