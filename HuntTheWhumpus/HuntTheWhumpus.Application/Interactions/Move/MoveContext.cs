using HuntTheWhumpus.Core.Domain;

namespace HuntTheWhumpus.Application.Interactions.Move
{
	public class MoveContext : ContextBase
	{
		public Room PreviousRoom;

		public void SetPreviousRoom(Room room) => PreviousRoom = room;

		public override void AddAdjustedRoom(Room room)
		{
			if (room.Equals(PreviousRoom))
				return;
			AdjacentRooms.Add(room);
		}
	}
}