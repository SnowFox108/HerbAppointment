using AnyaSpa.Dal.Enums;
using AnyaSpa.Infrastructure.Command;

namespace AnyaSpa.Dal.Commands
{
    public class CreateClientCommand : ICommand
    {
        public CreateClientCommand(
            ClientType clientType, 
            string firstName, 
            string lastName, 
            string mobileNumber,
            string email, 
            string note)
        {
            ClientType = clientType;
            FirstName = firstName;
            LastName = lastName;
            MobileNumber = mobileNumber;
            Email = email;
            Note = note;
        }

        public ClientType ClientType { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string MobileNumber { get; }
        public string Email { get; }
        public string Note { get; }

    }
}
