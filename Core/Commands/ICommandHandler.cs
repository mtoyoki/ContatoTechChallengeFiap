namespace Core.Commands
{
    public interface ICommandHandler<in T> where T: CommandBase
    {
        CommandResult Handle(T command);
    }
}