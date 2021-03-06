﻿using System.Collections.Generic;
using AnyaSpa.Infrastructure.Entities;

namespace AnyaSpa.Dal.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
