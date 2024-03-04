using Microsoft.IdentityModel.Tokens;
using NutriaryWebApp.BLL.Interfaces;
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

        public int UserLogin(string username, string password, out int userId)
        {
            try
            {
                var result = _authentication.UserLogin(username, password, out userId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
