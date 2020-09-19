using HuntTheWhumpus.Entities.Interfaces;

namespace HuntTheWhumpus.Entities.Player
{
	public partial class Player : IMoveable
	{
		int X;
		int Y;
		
		public void MoveUp() => Y--;
		public void MoveDown() => Y++;
		public void MoveLeft() => X--;
		public void MoveRight() => X++;

		public (int x, int y) GetPosition => (X, Y);
	}
}