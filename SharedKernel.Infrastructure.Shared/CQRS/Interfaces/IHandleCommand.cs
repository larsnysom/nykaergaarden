namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.CQRS.Interfaces
{
    public interface IHandleCommand
    {
        void Handle(ICommand command);

        void Persist(ICommand command);
    }
}