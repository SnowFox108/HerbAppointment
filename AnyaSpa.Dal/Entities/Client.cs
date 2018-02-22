using AnyaSpa.Infrastructure.Entities;

namespace AnyaSpa.Dal.Entities
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
    }
}
