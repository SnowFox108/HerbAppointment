using System;
using System.Collections.Generic;
using System.Text;
using AnyaSpa.Dal;
using AnyaSpa.Dal.Queries;

namespace AnyaSpa.ClientTest
{
    public class TestConnection
    {
        private IConfigConnection _configConnection;
        public TestConnection(IConfigConnection configConnection)
        {
            _configConnection = configConnection;
            Read();
        }

        private void Read()
        {
            var userQuery = new UserQuery(new ConnectionFactory(_configConnection));
            var users = userQuery.GetUsers();

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id} Name: {user.DisplayName}");
            }

            var user1 = userQuery.GetUser(4);

            if (user1 == null)
            {
                Console.WriteLine("User not found.");
                return;
            }
            Console.WriteLine($"Id: {user1.Id} Email: {user1.Email}");
            foreach (var role in user1.Roles)
            {
                Console.WriteLine($"Role: {role.Name}");
            }
        }
    }
}
