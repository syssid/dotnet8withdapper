using Azure;
using golum.DataAccessLayer;

namespace golum.Services
{
    public class Login : ILogin
    {
        private readonly IDBService _dbService;

        public Login(IDBService dbService)
        {
            _dbService = dbService;
        }
        public async Task<Models.Login> GetLogin(string UserID, string Password)
        {
            var parameters = new { UserID, Password};
            var UserLogin = await _dbService.GetAsync<Models.Login>("UserLogin", parameters);
            return UserLogin;
        }
        public async Task<List<Models.Login>> GetListLogin()
        {
            var GetAllUserLogin = await _dbService.GetAll<Models.Login>("GetAllUserLogin",null);
            return GetAllUserLogin;
        }
        public async Task<bool> CreateLogin(Models.Login login)
        {
            var parameters = new { login.Phone, login.Password };
            var result =
                await _dbService.EditData("CreateLogin", parameters);
            return true;
        }
        public async Task<Models.Login> UpdatePassword(Models.Login login)
        {
            var parameters = new { login.UserID, login.Password };
            var result =
                await _dbService.EditData("UpdateLoginPassword", parameters);
            return login;
        }
        public async Task<Models.Login> UpdatePhone(Models.Login login)
        {
            var parameters = new { login.UserID, login.Phone };
            var result =
                await _dbService.EditData("UpdateLoginPhone", parameters);
            return login;
        }
    }
}
