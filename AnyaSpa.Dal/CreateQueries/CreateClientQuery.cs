using System.Linq;
using AnyaSpa.Dal.Entities;
using Dapper;

namespace AnyaSpa.Dal.CreateQueries
{
    public interface ICreateClientQuery
    {
        int Execute(Client client);
    }
    public class CreateClientQuery : ICreateClientQuery
    {
        private readonly IConnectionFactory _connectionFactory;

        public CreateClientQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int Execute(Client client)
        {
            const string sql = @"INSERT INTO [dbo].[Clients]
           ([ClientType]
           ,[FirstName]
           ,[LastName]
           ,[MobileNumber]
           ,[Email]
           ,[Note])
     VALUES
           (@ClientType
           ,@FirstName
           ,@LastName
           ,@MobileNumber
           ,@Email
           ,@Note);
        SELECT CAST (Scope_Identity() AS INT);";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<int>(sql, client).Single();
            }
        }
    }
}
