using System;

namespace HuntTheWhumpus.Entities.Player
{
	public partial class Player
	{
		public Guid Id { get; } = Guid.Empty;
		
		public override string ToString() => $"Player - X: {_x}, Y: {_y}";
	}
}