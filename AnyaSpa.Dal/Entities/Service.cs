using AnyaSpa.Infrastructure.Entities;

namespace AnyaSpa.Dal.Entities
{
    public class Service : IEntity
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public int TreatmentId { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public int DurationMinute { get; set; }
        public decimal Price { get; set; }
    }
}
