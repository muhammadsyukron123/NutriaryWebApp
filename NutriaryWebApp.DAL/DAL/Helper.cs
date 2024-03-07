using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.DAL.DAL
{
    public class Helper
    {
        public static string GetConnectionString()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings["NutriaryDatabaseConnectionString"] == null)
            {
                var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                return MyConfig.GetConnectionString("NutriaryDatabaseConnectionString");
            }
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["NutriaryDatabaseConnectionString"].ConnectionString;
            return connString;
        }
    }
}
