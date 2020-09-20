using System;

namespace HuntTheWhumpus.Entities.Interfaces
{
	public interface IShootableEntity : IEntity<Guid>
	{
		protected int ShootX { get; set; }
		protected int ShootY { get; set; }

		public void ShootUp()
		{
			ShootX = X;
			ShootY = Y - 1;
		}

		public void ShootDown()
		{
			ShootX = X;
			ShootY = Y + 1;
		}

		public void ShootLeft()
		{
			ShootX = X - 1;
			ShootY = Y;
		}

		public void ShootRight()
		{
			ShootX = X + 1;
			ShootY = Y;
		}

		public (int x, int y) GetShootLocation => (ShootX, ShootY);
	}
}