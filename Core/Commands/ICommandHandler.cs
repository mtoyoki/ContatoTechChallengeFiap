namespace Core.Commands
{
    public interface ICommandHandler<in T> where T: CommandBase
    {
        Result Handle(T command);
    }
}