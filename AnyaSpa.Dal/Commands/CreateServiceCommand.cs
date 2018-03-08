using AnyaSpa.Infrastructure.Command;

namespace AnyaSpa.Dal.Commands
{
    public class CreateServiceCommand : ICommand
    {
        public CreateServiceCommand(
            int shopId, 
            int treatmentId, 
            string @alias, 
            string description, 
            int durationMinute,
            decimal price)
        {
            ShopId = shopId;
            TreatmentId = treatmentId;
            Alias = alias;
            Description = description;
            DurationMinute = durationMinute;
            Price = price;
        }

        public int ShopId { get; }
        public int TreatmentId { get; }
        public string Alias { get; }
        public string Description { get; }
        public int DurationMinute { get; }
        public decimal Price { get; }
    }
}
