using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NutriaryRESTService.Helpers;
using NutriaryWebApp.BLL.DTOs;
using NutriaryWebApp.BLL.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NutriaryRESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationBLL _authenticationBLL;
        private AppSettings _appSettings;

        public AuthenticationController(IAuthenticationBLL authenticationBLL, IOptions<AppSettings> appSettings)
        {
            _authenticationBLL = authenticationBLL;
            _appSettings = appSettings.Value;

        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO user)
        {
            try
            {
                var result = _authenticationBLL.LoginMVC(user);
                if (result == null)
                {
                    return NotFound();
                }
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, result.username));
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var userWithToken = new
                {
                    user_id = result.user_id,
                    username = result.username,
                    firstname = result.firstname,
                    lastname = result.lastname,
                    token = tokenHandler.WriteToken(token)
                };
                return Ok(userWithToken);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
            
        }
    }
}
