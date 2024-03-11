using NutriaryWebApp.BO.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.DAL.Interfaces
{
    public interface IUserProfile
    {
        void AddUserProfile(AddUserProfileBO userProfile);
        IEnumerable<UserProfileBO> GetUserProfile(int user_id);
        void UpdateUserProfile(UpdateUserProfileBO updateUserProfileBO);

        User GetUserAccount(int user_id);
        void UpdateUserAccount(UpdateUserAccountBO updateUserAccountBO);
    }
}
