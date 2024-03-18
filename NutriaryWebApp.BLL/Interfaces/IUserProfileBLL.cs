using NutriaryWebApp.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.Interfaces
{
    public interface IUserProfileBLL
    {
        void AddUserProfile(AddUserProfileDTO userProfile);
        ViewUserProfileDTO GetUserProfile(int user_id);
        void UpdateUserProfile(UpdateUserProfileDTO updateUserProfileDTO);
        void UpdateUserAccount(UpdateUserAccountDTO updateUserAccountDTO);
        UserDTO GetUserAccount(int user_id);
    }
}
