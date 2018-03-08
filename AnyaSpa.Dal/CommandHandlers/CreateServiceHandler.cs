using AnyaSpa.Dal.Commands;
using AnyaSpa.Dal.CreateQueries;
using AnyaSpa.Dal.Entities;
using AnyaSpa.Infrastructure.Command;
using AutoMapper;

namespace AnyaSpa.Dal.CommandHandlers
{
    public class CreateServiceHandler : ICommandHandler<CreateServiceCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICreateServiceQuery _createServiceQuery;

        public CreateServiceHandler(IMapper mapper, ICreateServiceQuery createServiceQuery)
        {
            _mapper = mapper;
            _createServiceQuery = createServiceQuery;
        }

        public ICommandResult Execute(CreateServiceCommand command)
        {
            return new CommandResult(_createServiceQuery.Execute(_mapper.Map<Service>(command)) > 0);
        }
    }
}
