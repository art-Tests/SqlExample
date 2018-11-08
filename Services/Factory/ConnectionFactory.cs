using System.Data;
using System.Data.SqlClient;

namespace SqlExample.Services.Factory
{
    public class ConnectionFactory
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=northwind;Persist Security Info=True;User ID=web;Password=web";

        public static IDbConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}