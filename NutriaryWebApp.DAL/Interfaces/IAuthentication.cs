using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.DAL.Interfaces
{
    public interface IAuthentication
    {
        int UserLogin(string username, string password, out int userId);


    }
}
