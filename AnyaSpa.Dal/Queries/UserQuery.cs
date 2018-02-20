using System;
using System.Collections.Generic;
using System.Linq;
using AnyaSpa.Dal.Entities;
using AnyaSpa.Dal.Models;
using Dapper;

namespace AnyaSpa.Dal.Queries
{
    public interface IUserQuery
    {
        UserDto GetUser(int id);
        IEnumerable<User> GetUsers();
    }
    public class UserQuery : IUserQuery
    {
        private readonly IConnectionFactory _connectionFactory;
        public UserQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public UserDto GetUser(int id)
        {
            //const string sql = @"SELECT * FROM [Security].[User] WHERE Id = @Id";
            const string sql = @"SELECT u.Id, u.DisplayName, u.Email, r.Id, r.Name, r.Description
                                FROM [Security].[User] as u INNER JOIN
                                [Security].[UserRole] as ur ON
                                u.Id = ur.UserId JOIN
                                [Security].[Role] as r
                                ON r.Id = ur.RoleId
                                Where u.Id = @Id";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                var results = connection.Query<UserDto, RoleDto, UserDto>(sql,
                        (user, role) =>
                        {
                            user.Roles.Add(role);
                            return user;
                        },
                        new
                        {
                            Id = id
                        }
                    )
                    .GroupBy(o => o.Id)
                .Select(group =>
                    {
                        var combinedUser = group.First();
                        combinedUser.Roles = group.Select(user => user.Roles.Single()).ToList();
                        return combinedUser;
                        //return group.Select(user => user).FirstOrDefault();
                    });
                return results.FirstOrDefault();
            }
        }

        public IEnumerable<User> GetUsers()
        {
            const string sql = @"SELECT * FROM [Security].[User]";

            using (var connection = _connectionFactory.OpenAnyaSpaConnection())
            {
                return connection.Query<User>(sql);
            }
        }
    }
}
