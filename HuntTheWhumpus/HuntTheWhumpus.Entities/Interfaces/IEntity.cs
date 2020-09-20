namespace HuntTheWhumpus.Entities.Interfaces
{
	public interface IEntity<TKey>
	{
		TKey Id { get; }

		protected int X { get; set; }
		protected int Y { get; set; }
	}
}