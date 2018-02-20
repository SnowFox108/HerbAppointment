using System;
using System.Collections.Generic;
using System.Text;
using AnyaSpa.Infrastructure.Entities;

namespace AnyaSpa.Dal.Entities
{
    public class Shop : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime OpeningHoursFrom { get; set; }
        public DateTime OpeningHoursTo { get; set; }
    }
}
