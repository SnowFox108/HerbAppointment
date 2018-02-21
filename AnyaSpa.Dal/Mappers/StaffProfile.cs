using AnyaSpa.Dal.Commands;
using AnyaSpa.Dal.Entities;
using AutoMapper;

namespace AnyaSpa.Dal.Mappers
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<CreateStaffCommand, Staff>();

        }
    }
}
