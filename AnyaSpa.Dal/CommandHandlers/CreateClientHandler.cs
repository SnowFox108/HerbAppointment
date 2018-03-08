using AnyaSpa.Dal.Commands;
using AnyaSpa.Dal.CreateQueries;
using AnyaSpa.Dal.Entities;
using AnyaSpa.Infrastructure.Command;
using AutoMapper;

namespace AnyaSpa.Dal.CommandHandlers
{
    public class CreateClientHandler : ICommandHandler<CreateClientCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICreateClientQuery _createClientQuery;

        public CreateClientHandler(IMapper mapper, ICreateClientQuery createClientQuery)
        {
            _mapper = mapper;
            _createClientQuery = createClientQuery;
        }

        public ICommandResult Execute(CreateClientCommand command)
        {
            return new CommandResult(_createClientQuery.Execute(_mapper.Map<Client>(command)) > 0);
        }
    }
}
