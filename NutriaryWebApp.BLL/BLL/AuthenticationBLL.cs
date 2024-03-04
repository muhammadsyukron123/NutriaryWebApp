using Microsoft.IdentityModel.Tokens;
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
    public class AuthenticationBLL : IAuthenticationBLL
    {
        private readonly IAuthentication _authentication;
        public AuthenticationBLL()
        {
            _authentication = new AuthenticationDAL();
        }

        public UserLoginDTO LoginUser(string username, string password)
        {
            try
            {
                var result = _authentication.LoginUser(username, password);
                if (result == null)
                {
                    throw new Exception("Invalid username or password");
                }
                UserLoginDTO userLoginDTO = new UserLoginDTO
                {
                    LoginResult = result.LoginResult,
                    user_id = result.user_id,
                    username = result.username,
                    firstname = result.firstname,
                    lastname = result.lastname
                };
                return userLoginDTO;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
