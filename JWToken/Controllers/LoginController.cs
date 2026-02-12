using System.IdentityModel.Tokens.Jwt;
using System.Text;
using JWToken.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration configuration)
        {
            _config = configuration;
        }
        private Users AuthenticateUser(Users users)
        {
            Users _users = null;

            if(users.Username == "Admin" && users.Password == "12345")
            {
                _users = new Users { Username = "Sidhartha Behera" };
            }
            return _users;
        }

        private string GenerateToken(Users users)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null, expires: DateTime.Now.AddMinutes(5), signingCredentials:credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(Users users)

        {
            IActionResult response = Unauthorized();
            var user_ = AuthenticateUser(users);
            if(user_ != null)
            {
                var token = GenerateToken(user_);
                response = Ok(new { token = token });    
            }
            return response;
        }
    }
}
