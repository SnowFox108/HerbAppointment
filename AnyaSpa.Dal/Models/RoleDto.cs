using AnyaSpa.Infrastructure.Entities;

namespace AnyaSpa.Dal.Models
{
    public class RoleDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
