using AnyaSpa.Dal.Enums;
using AnyaSpa.Infrastructure.Command;

namespace AnyaSpa.Dal.Commands
{
    public class CreateTreatmentCommand : ICommand
    {
        public CreateTreatmentCommand(
            TreatmentType treatmentType, 
            string name, 
            string description, 
            int durationMinute)
        {
            TreatmentType = treatmentType;
            Name = name;
            Description = description;
            DurationMinute = durationMinute;
        }

        public TreatmentType TreatmentType { get; }
        public string Name { get; }
        public string Description { get; }
        public int DurationMinute { get; }

    }
}
