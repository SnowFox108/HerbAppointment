using System.Collections.Generic;
using AnyaSpa.Infrastructure.Entities;

namespace AnyaSpa.Dal.Models
{
    public class UserDto : IDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }

        public List<RoleDto> Roles { get; set; }

        public UserDto()
        {
            Roles = new List<RoleDto>();
        }

    }
}
