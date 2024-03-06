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
        void UpdateUserProfile(UpdateUserProfileBO userProfile);

        void UpdateUserAccount(UpdateUserAccountBO userAccount);
    }
}
