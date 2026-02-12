using golum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace golum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class EmployeeController : ControllerBase
        {
            [Authorize]
            [HttpGet("DataGet")]
            public string GetData()
            {
                return "Authenticated With JWT";
            }
            [HttpPost("AddUser")]
            [Authorize]
            public string AddUser(Users users)
            {
                return "New User Added With Username" + users.Username;
            }
        }
}
 
