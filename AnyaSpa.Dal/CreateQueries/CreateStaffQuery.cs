using System.Linq;
using AnyaSpa.Dal.Entities;
using Dapper;

namespace AnyaSpa.Dal.CreateQueries
{
    public interface ICreateStaffQuery
    {
        int Execute(Staff staff);
    }
    public class CreateStaffQuery : ICreateStaffQuery
    {
        private readonly IConnectionFactory _connectionFactory;

        public CreateStaffQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int Execute(Staff staff)
        {
            const string sql = @"INSERT INTO [dbo].[Staffs]
           ([FirstName]
           ,[LastName]
           ,[MobileNumber]
           ,[Email]
           ,[StartDate]
           ,[EndDate]
           ,[Notes])
     VALUES
           (@FirstName
           ,@LastName
           ,@MobileNumber
           ,@Email
           ,@StartDate
           ,@EndDate
           ,@Notes);
        SELECT CAST (Scope_Identity() AS INT);";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<int>(sql, staff).Single();
            }
        }
    }
}
