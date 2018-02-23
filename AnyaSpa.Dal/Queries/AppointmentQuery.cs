using System;
using System.Collections.Generic;
using System.Linq;
using AnyaSpa.Dal.Entities;
using Dapper;

namespace AnyaSpa.Dal.Queries
{
    public interface IAppointmentQuery
    {
        Appointment GetAppointment(int id);
        IEnumerable<Appointment> GetAppointments();
        IEnumerable<Appointment> GetAppointmentsByDate(DateTime date);
    }
    public class AppointmentQuery : IAppointmentQuery
    {
        private readonly IConnectionFactory _connectionFactory;

        public AppointmentQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Appointment GetAppointment(int id)
        {
            const string sql = @"SELECT * FROM [Appointments] WHERE Id = @Id";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Appointment>(sql, new
                {
                    Id = id
                }).Single();
            }
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            const string sql = @"SELECT * FROM [Appointments]";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Appointment>(sql);
            }
        }

        public IEnumerable<Appointment> GetAppointmentsByDate(DateTime date)
        {
            const string sql = @"SELECT * FROM [Clients] WHERE StartTime > @StartDate AND StartTime < @EndDate";
            var startDate = date.Date;
            var endDate = date.AddDays(1).Date;

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<Appointment>(sql, new
                {
                    StartDate = startDate,
                    EndDate = endDate
                });
            }
        }
    }
}
