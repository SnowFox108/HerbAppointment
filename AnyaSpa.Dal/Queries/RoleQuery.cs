using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnyaSpa.Dal.Entities;
using Dapper;

namespace AnyaSpa.Dal.Queries
{
    public interface IRoleQuery
    {
        Role GetRole(int id);
        IEnumerable<Role> GetRoles();
    }
    public class RoleQuery : IRoleQuery
    {
        private readonly IConnectionFactory _connectionFactory;

        public RoleQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Role GetRole(int id)
        {
            const string sql = @"SELECT * FROM [Security].[Role] WHERE Id = @Id";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Role>(sql, new
                {
                    Id = id
                }).Single();
            }
        }

        public IEnumerable<Role> GetRoles()
        {
            const string sql = @"SELECT * FROM [Security].[Role]";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Role>(sql);
            }
        }
    }
}
