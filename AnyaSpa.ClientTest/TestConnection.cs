using System;
using System.Collections.Generic;
using System.Text;
using AnyaSpa.Dal;
using AnyaSpa.Dal.CommandHandlers;
using AnyaSpa.Dal.Commands;
using AnyaSpa.Dal.CreateQueries;
using AnyaSpa.Dal.Queries;
using AnyaSpa.Infrastructure.Command;
using Microsoft.Extensions.Logging;


namespace AnyaSpa.ClientTest
{
    public class TestConnection
    {
        private readonly IConfigConnection _configConnection;
        private readonly ICommandHandler<CreateStaffCommand> _commandHandler;
        private readonly ILogger<TestConnection> _logger;
        public TestConnection(IConfigConnection configConnection, 
            ICommandHandler<CreateStaffCommand> commandHandler, ILogger<TestConnection> logger)
        {
            _configConnection = configConnection;
            _commandHandler = commandHandler;
            _logger = logger;
        }

        public void Read()
        {
            var userQuery = new UserQuery(new ConnectionFactory(_configConnection));
            var users = userQuery.GetUsers();

            foreach (var user in users)
            {
                _logger.LogDebug($"Id: {user.Id} Name: {user.DisplayName}");
                Console.WriteLine($"Id: {user.Id} Name: {user.DisplayName}");
            }

            var user1 = userQuery.GetUser(1);

            if (user1 == null)
            {
                Console.WriteLine("User not found.");
                return;
            }
            _logger.LogInformation($"Id: {user1.Id} Name: {user1.Email}");
            Console.WriteLine($"Id: {user1.Id} Email: {user1.Email}");
            foreach (var role in user1.Roles)
            {
                Console.WriteLine($"Role: {role.Name}");
            }
        }

        public void Insert()
        {
            //var handler = new CreateStaffHandler(new CreateStaffQuery(new ConnectionFactory(_configConnection)));

            var command = new CreateStaffCommand("first", "last", "123456789", "test@test.com", DateTime.Now, null,
                "note");
            if (_commandHandler.Execute(command).Success)
            {
                Console.WriteLine("new record inserted.");
            }

            var staffQuery = new StaffQuery(new ConnectionFactory(_configConnection));
            var staffs = staffQuery.GetStaffs();

            foreach (var staff in staffs)
            {
                Console.WriteLine($"Name: {staff.FirstName} {staff.LastName} Email: {staff.Email} Create: {staff.StartDate}");
            }
        }
    }
}
