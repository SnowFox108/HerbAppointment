using System.Collections.Generic;
using System.Linq;
using AnyaSpa.Dal.Entities;
using AnyaSpa.Dal.Enums;
using Dapper;

namespace AnyaSpa.Dal.Queries
{
    public interface ITreatmentQuery
    {
        Treatment GetTreatment(int id);
        IEnumerable<Treatment> GetTreatments();
        IEnumerable<Treatment> GetTreatments(TreatmentType type);
    }
    public class TreatmentQuery : ITreatmentQuery
    {
        private readonly IConnectionFactory _connectionFactory;

        public TreatmentQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Treatment GetTreatment(int id)
        {
            const string sql = @"SELECT * FROM [Treatments] WHERE Id = @Id";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Treatment>(sql, new
                {
                    Id = id
                }).Single();
            }
        }

        public IEnumerable<Treatment> GetTreatments()
        {
            const string sql = @"SELECT * FROM [Treatments]";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Treatment>(sql);
            }
        }

        public IEnumerable<Treatment> GetTreatments(TreatmentType type)
        {
            const string sql = @"SELECT * FROM [Treatments] WHERE TreatType = @TreatType";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Treatment>(sql, new
                {
                    TreatType = type
                });
            }
        }
    }
}
