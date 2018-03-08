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
        private readonly ICreateStaffQuery _createStaffQuery;

        public CreateStaffHandler(
            ICreateStaffQuery createStaffQuery, 
            IMapper mapper)
        {
            _createStaffQuery = createStaffQuery;
            _mapper = mapper;
        }

        public ICommandResult Execute(CreateStaffCommand command)
        {
            return new CommandResult(_createStaffQuery.Execute(_mapper.Map<Staff>(command)) > 0);
        }
    }
}
