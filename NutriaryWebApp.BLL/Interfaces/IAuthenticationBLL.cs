using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.Interfaces
{
    public interface IAuthenticationBLL
    {
        int UserLogin(string username, string password, out int userId);
    }
}
