namespace CQRSSamples.Framework;
public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    Task Handle(TCommand command);
}
