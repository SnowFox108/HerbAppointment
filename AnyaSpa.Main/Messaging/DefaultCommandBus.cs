using AnyaSpa.Infrastructure.Command;

namespace AnyaSpa.Main.Messaging
{
    public class DefaultCommandBus : ICommandBus
    {
        private readonly ICommandHandlerFactory _commandHandlerFactory;

        public DefaultCommandBus(ICommandHandlerFactory commandHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
        }

        /// <summary>
        /// Simple direct call handler, can be replaced by event bus or any other messaging service
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _commandHandlerFactory.GetHandler<TCommand>();
            if (handler != null)
                return handler.Execute(command);
            throw new CommandHandlerNotFoundException(typeof(TCommand));
        }
    }
}
