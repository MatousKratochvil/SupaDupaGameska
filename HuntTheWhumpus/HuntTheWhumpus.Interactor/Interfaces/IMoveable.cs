using System;

namespace HuntTheWhumpus.Interactor.Interfaces
{
	public interface IMoveable : IEntity<Guid>
	{
		void MoveUp();
		void MoveDown();
		void MoveLeft();
		void MoveRight();
	}
}