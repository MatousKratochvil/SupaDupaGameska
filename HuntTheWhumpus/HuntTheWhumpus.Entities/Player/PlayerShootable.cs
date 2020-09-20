using HuntTheWhumpus.Entities.Interfaces;

namespace HuntTheWhumpus.Entities.Player
{
	public partial class Player : IShootable
	{
		int _shootX;
		int _shootY;

		public void ShootUp()
		{
			_shootX = _x;
			_shootY = _y - 1;
		}

		public void ShootDown()
		{
			_shootX = _x;
			_shootY = _y + 1;
		}

		public void ShootLeft()
		{
			_shootX = _x - 1;
			_shootY = _y;
		}

		public void ShootRight()
		{
			_shootX = _x + 1;
			_shootY = _y;
		}

		public (int x, int y) GetShootLocation => (_shootX, _shootY);
	}
}