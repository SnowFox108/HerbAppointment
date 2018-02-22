using System.Collections.Generic;
using System.Linq;
using AnyaSpa.Dal.Entities;
using Dapper;

namespace AnyaSpa.Dal.Queries
{
    public interface IShopQuery
    {
        Shop GetShop(int id);
        IEnumerable<Shop> GetShops();
    }
    public class ShopQuery: IShopQuery
    {
        private readonly IConnectionFactory _connectionFactory;

        public ShopQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Shop GetShop(int id)
        {
            const string sql = @"SELECT * FROM [Shops] WHERE Id = @Id";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Shop>(sql, new
                {
                    Id = id
                }).Single();
            }
        }

        public IEnumerable<Shop> GetShops()
        {
            const string sql = @"SELECT * FROM [Shops]";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Shop>(sql);
            }
        }
    }
}
