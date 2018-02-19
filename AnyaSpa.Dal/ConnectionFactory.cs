using System.Data.SqlClient;

namespace AnyaSpa.Dal
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfigConnection _config;

        public ConnectionFactory(IConfigConnection config)
        {
            _config = config;
        }
        public SqlConnection OpenAnyaSpaConnection()
        {
            var connection = new SqlConnection(_config.ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
