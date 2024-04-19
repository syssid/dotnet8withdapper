using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace golum.DataAccessLayer
{
    public class DbService : IDBService
    {
        private readonly IDbConnection con;

        public DbService(IConfiguration configuration)
        {
            con = new SqlConnection(configuration.GetConnectionString("MyCon"));
        }

        public async Task<T> GetAsync<T>(string command, object parms)
        {
            T result;

            result = (await con.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();

            return result;

        }

        public async Task<List<T>> GetAll<T>(string command, object parms)
        {

            List<T> result = new List<T>();

            result = (await con.QueryAsync<T>(command, parms)).ToList();

            return result;
        }

        public async Task<int> EditData(string command, object parms)
        {
            int result;

            result = await con.ExecuteAsync(command, parms);

            return result;
        }
    }
}
