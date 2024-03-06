﻿using NutriaryWebApp.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.Interfaces
{
    public interface IUserProfileBLL
    {
        void AddUserProfile(AddUserProfileDTO userProfile);
        IEnumerable<ViewUserProfileDTO> GetUserProfile(int user_id);
        void UpdateUserProfile(UpdateUserProfileDTO userProfile);
        void UpdateUserAccount(UpdateUserAccountDTO userAccount);
    }
}
