using HuntTheWhumpus.Entities.Interfaces;

namespace HuntTheWhumpus.Entities.Player
{
	public partial class Player : IMoveable
	{
		int _x;
		int _y;
		
		public void MoveUp() => _y--;
		public void MoveDown() => _y++;
		public void MoveLeft() => _x--;
		public void MoveRight() => _x++;

		public (int x, int y) GetPosition => (_x, _y);
	}
}