using System;

namespace HuntTheWhumpus.Entities.Interfaces
{
	public interface IMoveableEntity : IEntity<Guid>
	{
		public void MoveUp() => Y--;
		public void MoveDown() => Y++;
		public void MoveLeft() => X--;
		public void MoveRight() => X++;

		public (int x, int y) GetPosition => (X, Y);
	}
}