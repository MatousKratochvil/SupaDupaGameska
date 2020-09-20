using System;

namespace HuntTheWhumpus.Entities.Interfaces
{
	public interface IShootable : IEntity<Guid>
	{
		void ShootUp();
		void ShootDown();
		void ShootLeft();
		void ShootRight();
	}
}