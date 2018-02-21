using AnyaSpa.Dal.Commands;
using AnyaSpa.Dal.CreateQueries;
using AnyaSpa.Dal.Entities;
using AnyaSpa.Infrastructure.Command;
using AutoMapper;

namespace AnyaSpa.Dal.CommandHandlers
{
    public class CreateStaffHandler : ICommandHandler<CreateStaffCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICreateStaffQuery _createStaff;

        public CreateStaffHandler(
            ICreateStaffQuery createStaff, 
            IMapper mapper)
        {
            _createStaff = createStaff;
            _mapper = mapper;
        }

        public ICommandResult Execute(CreateStaffCommand command)
        {
            return new CommandResult(_createStaff.Execute(_mapper.Map<Staff>(command)) > 0);
        }
    }
}
