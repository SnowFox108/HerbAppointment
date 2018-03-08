using System.Linq;
using AnyaSpa.Dal.Entities;
using Dapper;

namespace AnyaSpa.Dal.CreateQueries
{
    public interface ICreateServiceQuery
    {
        int Execute(Service service);
    }
    public class CreateServiceQuery : ICreateServiceQuery
    {
        private readonly IConnectionFactory _connectionFactory;

        public CreateServiceQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int Execute(Service service)
        {
            const string sql = @"INSERT INTO [dbo].[Services]
           ([ShopId]
           ,[TreatmentId]
           ,[Alias]
           ,[Description]
           ,[DurationMinute]
           ,[Price])
     VALUES
           (@ShopId
           ,@TreatmentId
           ,@Alias
           ,@Description
           ,@DurationMinute
           ,@Price);
        SELECT CAST (Scope_Identity() AS INT);";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<int>(sql, service).Single();
            }
        }
    }
}
