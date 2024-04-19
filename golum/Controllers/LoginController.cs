using golum.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace golum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _login;
        public LoginController(ILogin login)
        {
            _login = login;
        }
        [HttpGet("Login")]
        public async Task<IActionResult> GetLogin(string UserID, string Password)
        {
            var result = await _login.GetLogin(UserID, Password);

            return Ok(result);
        }
        [HttpPost("CreateLogin")]
        public async Task<IActionResult> AddEmployee([FromBody] Models.Login login)
        {
            var result = await _login.CreateLogin(login);
            return Ok(result);
        }

        [HttpGet("GetAllLogin")]
        public async Task<IActionResult> GetAllUserLogin()
        {
            var result = await _login.GetListLogin();
            return Ok(result);
        }
    }
}
