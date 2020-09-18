namespace HuntTheWhumpus.Interactor.Interfaces
{
	public interface IEntity<TKey>
	{
		TKey Id { get; }
	}
}