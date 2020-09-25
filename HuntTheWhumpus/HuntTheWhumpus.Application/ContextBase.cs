using System.Collections.Generic;
using HuntTheWhumpus.Core.Domain;

namespace HuntTheWhumpus.Application
{
	public abstract class ContextBase
	{
		public Room ActualRoom;
		public readonly HashSet<Room> AdjacentRooms = new HashSet<Room>();
		public void SetActualRoom(Room room) => ActualRoom = room;
		public abstract void AddAdjustedRoom(Room room);
	}
}