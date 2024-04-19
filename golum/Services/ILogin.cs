namespace golum.Services
{
    public interface ILogin
    {
        Task<Models.Login> GetLogin(string UserID, string Password);
        Task<List<Models.Login>> GetListLogin();
        Task<bool> CreateLogin(Models.Login employee);
      //  Task<Models.Login> UpdateLogin(Models.Login login);
     //   Task<bool> DeleteLogin(string UserID);
    }
}
