using NutriaryWebApp.BLL.DTOs;
using NutriaryWebApp.BLL.Interfaces;
using NutriaryWebApp.BO.BO;
using NutriaryWebApp.DAL.DAL;
using NutriaryWebApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.BLL
{
    public class CreateUserBLL : ICreateUserBLL
    {
        private readonly ICreateUser _createUser;
        public CreateUserBLL()
        {
            _createUser = new CreateUserDAL();
        }

        public void CreateUser(CreateUserDTO user)
        {
            try
            {
                _createUser.CreateUser(new User
                {
                    username = user.username,
                    email = user.email,
                    password = user.password,
                    confirmpassword = user.confirmpassword,
                    firstname = user.firstname,
                    lastname = user.lastname
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
