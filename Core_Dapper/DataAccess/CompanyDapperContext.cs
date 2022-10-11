using Microsoft.Data.SqlClient;
using System.Data;

namespace Core_Dapper.DataAccess
{
    public class CompanyDapperContext
    {
        private readonly IConfiguration configuration;
        private readonly string connStr;
        public CompanyDapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            connStr = this.configuration.GetConnectionString("DbConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(connStr);
    }
}
