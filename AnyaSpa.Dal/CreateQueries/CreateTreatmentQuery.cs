using System.Linq;
using AnyaSpa.Dal.Entities;
using Dapper;

namespace AnyaSpa.Dal.CreateQueries
{
    public interface ICreateTreatmentQuery
    {
        int Execute(Treatment treatment);
    }
    public class CreateTreatmentQuery : ICreateTreatmentQuery
    {
        private readonly IConnectionFactory _connectionFactory;

        public CreateTreatmentQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int Execute(Treatment treatment)
        {
            const string sql = @"INSERT INTO [dbo].[Treatments]
           ([TreatmentType]
           ,[Name]
           ,[Description]
           ,[DurationMinute])
     VALUES
           (@TreatmentType
           ,@Name
           ,@Description
           ,@DurationMinute);
        SELECT CAST (Scope_Identity() AS INT);";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<int>(sql, treatment).Single();
            }
        }
    }
}
