namespace HuntTheWhumpus.Abstraction.Interfaces
{
    public interface IInteraction<TRequest> where TRequest : IInteractorRequest
    {
        void Execute(TRequest interactorRequest);
    }
}