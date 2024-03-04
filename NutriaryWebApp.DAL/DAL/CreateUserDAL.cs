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
    public class CreateUserDAL : ICreateUser
    {
        private string GetConnectionString()
        {
            //return @"Data Source=BSINB23L011\BSISQLEXPRESS;Initial Catalog=NutriaryDatabase;Integrated Security=True;TrustServerCertificate=True";
            return ConfigurationManager.ConnectionStrings["NutriaryDatabaseConnectionString"].ConnectionString;
        }
        public void CreateUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var sqlSP = @"usp_RegisterUser";
                var param = new { username = user.username, email = user.email, password = user.password, firstname = user.firstname, lastname = user.lastname };
                conn.Execute(sqlSP, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
