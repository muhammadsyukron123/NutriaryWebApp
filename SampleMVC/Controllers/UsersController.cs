using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using NutriaryWebApp.BLL.DTOs;
using NutriaryWebApp.BLL.Interfaces;
using System.Text.Json;

namespace NutriaryWebMVC.Controllers
{
    public class UsersController : Controller
    {
        private IAuthenticationBLL _authenticationBLL;
        private IUserProfileBLL _userProfileBLL;
        private ICreateUserBLL _createUserBLL;

        public UsersController(IAuthenticationBLL authenticationBLL, IUserProfileBLL userProfileBLL, ICreateUserBLL createUserBLL)
        {
            _authenticationBLL = authenticationBLL;
            _userProfileBLL = userProfileBLL;
            _createUserBLL = createUserBLL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(CreateUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _createUserBLL.CreateUser(userDTO);

                //assign session user info after registration
                LoginDTO loginDTO = new LoginDTO
                {
                    Username = userDTO.username,
                    Password = userDTO.password
                };
                var userLoginDTO = _authenticationBLL.LoginMVC(loginDTO);
                if (userLoginDTO == null)
                {
                    return View();
                }

                var userDTOSerialize = JsonSerializer.Serialize(userLoginDTO);
                HttpContext.Session.SetString("User", userDTOSerialize);

                TempData["Message"] = "User created successfully";
                ViewBag.Message = @"<div class=""alert alert-primary"" role=""alert"">User created successfully</div>";


                return RedirectToAction("CreateProfile", "Users");

            }

            catch (Exception ex)
            {
                ViewBag.Message = @"<div class=""alert alert-danger"" role=""alert"">" + ex.Message + "</div>";
                return View();
            }


        }

        public IActionResult CreateProfile()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return View();
        }

        [HttpPost]
        public IActionResult CreateProfile(AddUserProfileDTO userProfileDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var user = JsonSerializer.Deserialize<UserLoginDTO>(HttpContext.Session.GetString("User"));
                var userID = user.user_id;
                userProfileDTO.user_id = userID;
                _userProfileBLL.AddUserProfile(userProfileDTO);
                TempData["Message"] = "Profile created successfully";
                ViewBag.Message = @"<div class=""alert alert-primary"" role=""alert"">Profile created successfully</div>";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Message = @"<div class=""alert alert-danger"" role=""alert"">" + ex.Message + "</div>";
            }
            return View();
        }

        public IActionResult Profile()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var user = JsonSerializer.Deserialize<UserLoginDTO>(HttpContext.Session.GetString("User"));
            var userID = user.user_id;
            var userDTO = _userProfileBLL.GetUserProfile(userID);
            return View(userDTO);
        }

        [HttpPost]
        public IActionResult Profile(AddUserProfileDTO userProfileDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var user = JsonSerializer.Deserialize<UserLoginDTO>(HttpContext.Session.GetString("User"));
                var userID = user.user_id;
                userProfileDTO.user_id = userID;
                _userProfileBLL.AddUserProfile(userProfileDTO);
                TempData["Message"] = "Profile updated successfully";
                ViewBag.Message = @"<div class=""alert alert-primary"" role=""alert"">Profile updated successfully</div>";
                return RedirectToAction("Profile", "Users");
            }
            catch (Exception ex)
            {
                ViewBag.Message = @"<div class=""alert alert-danger"" role=""alert"">" + ex.Message + "</div>";
            }
            return View();
        }

        [HttpPost]
        public IActionResult UpdateAccount(UpdateUserAccountDTO userAccountDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var user = JsonSerializer.Deserialize<UserLoginDTO>(HttpContext.Session.GetString("User"));
                var userID = user.user_id;
                userAccountDTO.user_id = userID;
                _userProfileBLL.UpdateUserAccount(userAccountDTO);
                TempData["Message"] = "Account updated successfully";
                ViewBag.Message = @"<div class=""alert alert-primary"" role=""alert"">Account updated successfully</div>";
                return RedirectToAction("Profile", "Users");
            }
            catch (Exception ex)
            {
                ViewBag.Message = @"<div class=""alert alert-danger"" role=""alert"">" + ex.Message + "</div>";
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var userLoginDTO = _authenticationBLL.LoginMVC(loginDTO);
                if (userLoginDTO == null)
                {
                    return View();
                }

                var userDTOSerialize = JsonSerializer.Serialize(userLoginDTO);
                HttpContext.Session.SetString("User", userDTOSerialize);

                TempData["Message"] = "Welcome " + userLoginDTO.username;
                ViewBag.Message = @"<div class=""alert alert-primary"" role=""alert"">successfully login</div>";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                ViewBag.Message = @"<div class=""alert alert-danger"" role=""alert"">" + ex.Message + "</div>";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("LandingPage", "Home");
        }
    }
}
