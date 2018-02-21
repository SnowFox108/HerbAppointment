using System;
using AnyaSpa.Infrastructure.Command;

namespace AnyaSpa.Dal.Commands
{
    public class CreateStaffCommand : ICommand
    {
        public CreateStaffCommand(string firstName, string lastName, string mobileNumber, string email,
            DateTime startDate, DateTime? endDate, string notes)
        {
            FirstName = firstName;
            LastName = lastName;
            MobileNumber = mobileNumber;
            Email = email;
            StartDate = startDate;
            EndDate = endDate;
            Notes = notes;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string MobileNumber { get; }
        public string Email { get; }
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
        public string Notes { get; }

    }
}
