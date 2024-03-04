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
    public class AddUserBLL : IAddUserProfileBLL
    {
        private readonly IAddUserProfile _addUserProfile;
        public AddUserBLL()
        {
            _addUserProfile = new AddUserProfileDAL();
        }

        public void AddUserProfile(AddUserProfileDTO userProfile)
        {
            try
            {
                var addUserProfile = new AddUserProfileBO
                {
                    user_id = userProfile.user_id,
                    gender = userProfile.gender,
                    age = userProfile.age,
                    weight = userProfile.weight,
                    height = userProfile.height,
                    activity_level_id = userProfile.activity_level_id,
                    target_goal_id = userProfile.target_goal_id
                };
                _addUserProfile.AddUserProfile(addUserProfile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
