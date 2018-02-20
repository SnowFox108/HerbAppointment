using System.Collections.Generic;
using System.Linq;
using AnyaSpa.Dal.Entities;
using Dapper;

namespace AnyaSpa.Dal.Queries
{
    public interface IStaffQuery
    {
        Staff GetStaff(int id);
        IEnumerable<Staff> GetStaffs();
    }
    public class StaffQuery : IStaffQuery
    {
        private readonly IConnectionFactory _connectionFactory;

        public StaffQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Staff GetStaff(int id)
        {
            const string sql = @"SELECT * FROM [Security].[Staff] WHERE Id = @Id";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Staff>(sql, new
                {
                    Id = id
                }).Single();
            }
        }

        public IEnumerable<Staff> GetStaffs()
        {
            const string sql = @"SELECT * FROM [Security].[Staff]";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Staff>(sql);
            }
        }
    }
}
