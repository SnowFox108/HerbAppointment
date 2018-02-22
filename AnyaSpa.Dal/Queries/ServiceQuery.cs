using System.Collections.Generic;
using System.Linq;
using AnyaSpa.Dal.Entities;
using Dapper;

namespace AnyaSpa.Dal.Queries
{
    public interface IServiceQuery
    {
        Service GetService(int id);
        IEnumerable<Service> GetServices();
        IEnumerable<Service> GetServiceByShop(int shopId);
    }
    public class ServiceQuery : IServiceQuery
    {
        private readonly IConnectionFactory _connectionFactory;

        public ServiceQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Service GetService(int id)
        {
            const string sql = @"SELECT * FROM [Services] WHERE Id = @Id";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Service>(sql, new
                {
                    Id = id
                }).Single();
            }
        }

        public IEnumerable<Service> GetServices()
        {
            const string sql = @"SELECT * FROM [Services]";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Service>(sql);
            }
        }

        public IEnumerable<Service> GetServiceByShop(int shopId)
        {
            const string sql = @"SELECT * FROM [Treatments] WHERE ShopId = @ShopId";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Service>(sql, new
                {
                    ShopId = shopId
                });
            }
        }
    }
}
