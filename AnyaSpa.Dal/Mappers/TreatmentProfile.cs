using AnyaSpa.Dal.Commands;
using AnyaSpa.Dal.Entities;
using AutoMapper;

namespace AnyaSpa.Dal.Mappers
{
    public class TreatmentProfile : Profile
    {
        public TreatmentProfile()
        {
            CreateMap<CreateTreatmentCommand, Treatment>();
        }
    }
}
