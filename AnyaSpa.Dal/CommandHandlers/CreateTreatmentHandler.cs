using AnyaSpa.Dal.Commands;
using AnyaSpa.Dal.CreateQueries;
using AnyaSpa.Dal.Entities;
using AnyaSpa.Infrastructure.Command;
using AutoMapper;

namespace AnyaSpa.Dal.CommandHandlers
{
    public class CreateTreatmentHandler : ICommandHandler<CreateTreatmentCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICreateTreatmentQuery _createTreatmentQuery;

        public CreateTreatmentHandler(IMapper mapper, ICreateTreatmentQuery createTreatmentQuery)
        {
            _mapper = mapper;
            _createTreatmentQuery = createTreatmentQuery;
        }

        public ICommandResult Execute(CreateTreatmentCommand command)
        {
            return new CommandResult(_createTreatmentQuery.Execute(_mapper.Map<Treatment>(command)) > 0);
        }
    }
}
