using System.Drawing;

namespace HuntTheWhumpus.AppConsole
{
	class Player
	{
		Point _position;

		public Player(Point position)
		{
			_position = position;
		}

		public override string ToString() => $"x: {_position.X} Y: {_position.Y}";

		public void MoveLeft() => _position.X--;
		public void MoveRight() => _position.X++;

		public void MoveUp() => _position.Y--;
		public void MoveDown() => _position.Y++;

		public Point GetPosition() => _position;
	}
}