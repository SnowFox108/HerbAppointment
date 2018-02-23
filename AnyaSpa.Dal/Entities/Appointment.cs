using System;
using AnyaSpa.Dal.Enums;
using AnyaSpa.Infrastructure.Entities;

namespace AnyaSpa.Dal.Entities
{
    public class Appointment : IEntity
    {
        public int Id { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public int ServiceId { get; set; }
        public int StaffId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
