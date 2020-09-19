namespace HuntTheWhumpus.Entities.Interfaces
{
	public interface IEntity<TKey>
	{
		TKey Id { get; }
	}
}