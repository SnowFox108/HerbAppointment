namespace AnyaSpa.Infrastructure.Command
{
    public interface ICommandBus
    {
        ICommandResult Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
