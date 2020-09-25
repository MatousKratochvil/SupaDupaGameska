using System;

namespace HuntTheWhumpus.Core.Domain
{
	public sealed class Room : IEquatable<Room>
	{
		readonly string _name;
		readonly int _id;
		readonly int _connectionId;

		public Room(string name, int id, int connectionId)
		{
			_name = name;
			_id = id;
			_connectionId = connectionId;
		}

		public int GetId() => _id;

		public int GetConnectionId() => _connectionId;

		public override string ToString() => _name;

		public override bool Equals(object obj)
			=> ReferenceEquals(this, obj) || Equals((Room) obj);
		public bool Equals(Room? other)
			=> !ReferenceEquals(null, other) && _id == other._id;

		public override int GetHashCode() => _id;
	}
}