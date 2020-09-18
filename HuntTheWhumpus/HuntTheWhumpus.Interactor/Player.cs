using System;
using HuntTheWhumpus.Interactor.Interfaces;

namespace HuntTheWhumpus.Interactor
{
	public class Player : IMoveable
	{
		int X;
		int Y;

		public Guid Id { get; } = Guid.Empty;
		public void MoveUp() => Y--;

		public void MoveDown() => Y++;

		public void MoveLeft() => X--;

		public void MoveRight() => X++;

		public override string ToString() => $"Player - X: {X}, Y: {Y}";
	}
}