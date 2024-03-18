using Azure;
using NutriaryWebApp.BLL.DTOs;
using NutriaryWebApp.BLL.Interfaces;
using NutriaryWebApp.BO.BO;
using NutriaryWebApp.DAL.DAL;
using NutriaryWebApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
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

        public UserDTO GetUserAccount(int user_id)
        {
            UserDTO user = new UserDTO();
            var getUserAccount = _addUserProfile.GetUserAccount(user_id);

            if (getUserAccount == null)
            {
                throw new Exception("User not found");
            }

            user.user_id = getUserAccount.user_id;
            user.firstname = getUserAccount.firstname;
            user.lastname = getUserAccount.lastname;
            user.username = getUserAccount.username;
            user.email = getUserAccount.email;
            return user;
        }

        public ViewUserProfileDTO GetUserProfile(int user_id)
        {

            try
            {
                ViewUserProfileDTO viewUserProfile = new ViewUserProfileDTO();
                var getUserProfile = _addUserProfile.GetUserProfile(user_id);
                var getUserAccount = _addUserProfile.GetUserAccount(user_id);
                if (getUserProfile == null)
                {
                    viewUserProfile.username = getUserAccount.username;
                    viewUserProfile.firstname = getUserAccount.firstname;
                    viewUserProfile.lastname = getUserAccount.lastname;
                    viewUserProfile.email = getUserAccount.email;
                    viewUserProfile.age = 0;
                    viewUserProfile.gender = "Not set";
                    viewUserProfile.weight = 0;
                    viewUserProfile.height = 0;
                    viewUserProfile.ActivityLevel = "Not set";
                    viewUserProfile.TargetGoal = "Not set";
                    return viewUserProfile;
                }

                viewUserProfile.username = getUserProfile.username;
                viewUserProfile.firstname = getUserProfile.firstname;
                viewUserProfile.lastname = getUserProfile.lastname;
                viewUserProfile.email = getUserProfile.email;
                viewUserProfile.age = getUserProfile.age;
                viewUserProfile.gender = getUserProfile.gender;
                viewUserProfile.weight = getUserProfile.weight;
                viewUserProfile.height = getUserProfile.height;
                viewUserProfile.ActivityLevel = getUserProfile.ActivityLevel;
                viewUserProfile.TargetGoal = getUserProfile.TargetGoal;


                return viewUserProfile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUserAccount(UpdateUserAccountDTO updateUserAccountDTO)
        {
            try
            {
                var updateUserAccount = new UpdateUserAccountBO
                {
                    user_id = updateUserAccountDTO.user_id,
                    firstname = updateUserAccountDTO.firstname,
                    lastname = updateUserAccountDTO.lastname,
                    username = updateUserAccountDTO.username,
                    email = updateUserAccountDTO.email
                };
                _addUserProfile.UpdateUserAccount(updateUserAccount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUserProfile(UpdateUserProfileDTO updateUserProfileDTO)
        {
            try
            {
                var updateUserProfile = new UpdateUserProfileBO
                {
                    user_id = updateUserProfileDTO.user_id,
                    gender = updateUserProfileDTO.gender,
                    age = updateUserProfileDTO.age,
                    weight = updateUserProfileDTO.weight,
                    height = updateUserProfileDTO.height,
                    ActivityLevel = updateUserProfileDTO.ActivityLevel,
                    TargetGoal = updateUserProfileDTO.TargetGoal
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
