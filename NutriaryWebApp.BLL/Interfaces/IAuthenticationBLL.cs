using NutriaryWebApp.BLL.DTOs;
using NutriaryWebApp.BO.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.Interfaces
{
    public interface IAuthenticationBLL
    {
        UserLoginDTO LoginUser(string username, string password);
        UserLoginDTO LoginMVC(LoginDTO loginDTO);

    }
}
