using AnyaSpa.Dal.Enums;
using AnyaSpa.Infrastructure.Entities;

namespace AnyaSpa.Dal.Entities
{
    public class Treatment : IEntity
    {
        public int Id { get; set; }
        public TreatmentType TreatmentType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationMinute { get; set; }
    }
}
