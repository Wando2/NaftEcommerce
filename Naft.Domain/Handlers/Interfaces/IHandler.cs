using Naft.Domain.Commands.Interfaces;

namespace Naft.Domain.Handlers.Interfaces;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}