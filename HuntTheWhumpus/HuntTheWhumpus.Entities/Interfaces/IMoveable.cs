using System;

namespace HuntTheWhumpus.Entities.Interfaces
{
	public interface IMoveable : IEntity<Guid>
	{
		void MoveUp();
		void MoveDown();
		void MoveLeft();
		void MoveRight();
	}
}