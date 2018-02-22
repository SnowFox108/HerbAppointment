using System.Collections.Generic;
using System.Linq;
using AnyaSpa.Dal.Entities;
using Dapper;

namespace AnyaSpa.Dal.Queries
{
    public interface IClientQuery
    {
        Client GetClient(int id);
        IEnumerable<Client> GetClients();
    }
    public class ClientQuery : IClientQuery
    {
        private readonly IConnectionFactory _connectionFactory;

        public ClientQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Client GetClient(int id)
        {
            const string sql = @"SELECT * FROM [Clients] WHERE Id = @Id";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Client>(sql, new
                {
                    Id = id
                }).Single();
            }
        }

        public IEnumerable<Client> GetClients()
        {
            const string sql = @"SELECT * FROM [Clients]";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Client>(sql);
            }
        }
    }
}
