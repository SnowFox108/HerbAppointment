namespace AnyaSpa.Infrastructure.Command
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
    }
}
