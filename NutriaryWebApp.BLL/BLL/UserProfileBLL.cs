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
    public class UserProfileBLL : IUserProfileBLL
    {
        private readonly IUserProfile _addUserProfile;
        public UserProfileBLL()
        {
            _addUserProfile = new UserProfileDAL();
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

        public IEnumerable<ViewUserProfileDTO> GetUserProfile(int user_id)
        {
            
            try
            {
                List<ViewUserProfileDTO> viewUserProfile = new List<ViewUserProfileDTO>();
                var getUserProfile = _addUserProfile.GetUserProfile(user_id);
                foreach (var item in getUserProfile)
                {
                    viewUserProfile.Add(new ViewUserProfileDTO
                    {
                        firstname = item.firstname,
                        lastname = item.lastname,
                        username = item.username,
                        email = item.email,
                        gender = item.gender,
                        age = item.age,
                        weight = item.weight,
                        height = item.height,
                        TargetGoal = item.TargetGoal,
                        ActivityLevel = item.ActivityLevel
                        
                    });
                }
                return viewUserProfile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUserAccount(UpdateUserAccountDTO userAccount)
        {
            try
            {
                var updateUserAccount = new UpdateUserAccountBO
                {
                    user_id = userAccount.user_id,
                    firstname = userAccount.firstname,
                    lastname = userAccount.lastname,
                    username = userAccount.username,
                    email = userAccount.email
                };
                _addUserProfile.UpdateUserAccount(updateUserAccount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUserProfile(UpdateUserProfileDTO userProfile)
        {
            try
            {
                var updateUserProfile = new UpdateUserProfileBO
                {
                    user_id = userProfile.user_id,
                    gender = userProfile.gender,
                    age = userProfile.age,
                    weight = userProfile.weight,
                    height = userProfile.height,
                    ActivityLevel = userProfile.ActivityLevel,
                    TargetGoal = userProfile.TargetGoal
                };
                _addUserProfile.UpdateUserProfile(updateUserProfile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
