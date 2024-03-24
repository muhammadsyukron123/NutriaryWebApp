using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriaryWebApp.BLL.DTOs;
using NutriaryWebApp.BLL.Interfaces;

namespace NutriaryRESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ICreateUserBLL _createUserBLL;
        private IUserProfileBLL _userProfileBLL;

        public UsersController(ICreateUserBLL createUserBLL, IUserProfileBLL userProfileBLL)
        {
            _createUserBLL = createUserBLL;
            _userProfileBLL = userProfileBLL;
            
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] CreateUserDTO user)
        {
            _createUserBLL.CreateUser(user);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [Authorize]
        [HttpPost("profile")]
        public IActionResult Profile([FromBody] AddUserProfileDTO userProfile)
        {
            _userProfileBLL.AddUserProfile(userProfile);
            if (userProfile != null)
            {
                return Ok(userProfile);
            }
            return NotFound();
        }

        [Authorize]
        [HttpGet("profile")]
        public IActionResult GetProfile(int user_id)
        {
            var result = _userProfileBLL.GetUserProfile(user_id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }


        [Authorize]
        [HttpPut("profile")]
        public IActionResult UpdateProfile([FromBody] AddUserProfileDTO updateUserProfile)
        {
            _userProfileBLL.AddUserProfile(updateUserProfile);
            return Ok();
        }

        [Authorize]
        [HttpGet("account")]
        public IActionResult GetAccount(int user_id)
        {
            var result = _userProfileBLL.GetUserAccount(user_id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [Authorize]
        [HttpPut("account")]
        public IActionResult UpdateAccount([FromBody] UpdateUserAccountDTO updateUserAccount)
        {
            _userProfileBLL.UpdateUserAccount(updateUserAccount);
            return Ok();
        }

    }
}
