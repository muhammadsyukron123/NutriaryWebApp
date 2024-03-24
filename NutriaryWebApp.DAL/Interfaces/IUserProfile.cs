using NutriaryWebApp.BO.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.DAL.Interfaces
{
    public interface IUserProfile
    {
        void AddUserProfile(AddUserProfileBO userProfile);
        UserProfileBO GetUserProfile(int user_id);
        void UpdateUserProfile(UpdateUserProfileBO updateUserProfileBO);

        User GetUserAccount(int user_id);
        void UpdateUserAccount(UpdateUserAccountBO updateUserAccountBO);
        UserDiary GetUserDiary(int user_id, DateTime date);
    }
}
