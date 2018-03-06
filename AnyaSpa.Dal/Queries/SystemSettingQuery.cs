using System.Collections.Generic;
using AnyaSpa.Dal.Entities;
using Dapper;

namespace AnyaSpa.Dal.Queries
{
    public interface ISystemSettingQuery
    {
        IEnumerable<SystemSetting> GetSystemSettings();
    }
    public class SystemSettingQuery : ISystemSettingQuery
    {
        private readonly IConnectionFactory _connectionFactory;

        public SystemSettingQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<SystemSetting> GetSystemSettings()
        {
            const string sql = @"SELECT * FROM [SystemSettings]";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<SystemSetting>(sql);
            }
        }
    }
}
