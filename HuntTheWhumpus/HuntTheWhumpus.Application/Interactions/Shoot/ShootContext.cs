using HuntTheWhumpus.Core.Domain;

namespace HuntTheWhumpus.Application.Interactions.Shoot
{
	public class ShootContext : ContextBase
	{
		public Room ShootToRoom;
		public bool IsWhumpusShot;

		public void SetShootRoom(Room room) => ShootToRoom = room;
		public void SetShotWhumpus(bool isWhumpusShot) => IsWhumpusShot = isWhumpusShot;
		public override void AddAdjustedRoom(Room room) => AdjacentRooms.Add(room);
	}
}