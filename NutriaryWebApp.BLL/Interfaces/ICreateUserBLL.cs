using NutriaryWebApp.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.Interfaces
{
    public interface ICreateUserBLL
    {
        void CreateUser(CreateUserDTO user);
    }
}
