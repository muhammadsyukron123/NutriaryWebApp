﻿using NutriaryWebApp.BO.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.DAL.Interfaces
{
    public interface IAuthentication
    {
        UserLogin LoginUser(string username, string password);

    }
}
