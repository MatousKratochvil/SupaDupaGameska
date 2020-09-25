using FluentAssertions;
using HuntTheWhumpus.Core.Domain;
using Xunit;

namespace HuntTheWhumpusTests.Core
{
	public class RoomTest
	{
		const string FirstRoom = "FirstRoom";
		
		readonly Room _firstRoom;
		readonly Room _firstAgainRoom;
		readonly Room _secondRoom;
		
		public RoomTest()
		{
			_firstRoom = new Room(FirstRoom, 1, 1);
			_firstAgainRoom = new Room("FirstAgainRoom", 1, 2);
			
			_secondRoom = new Room("SecondRoom", 2, 2);
		}

		[Fact]
		public void TwoRoom_Equals_ReturnFalse()
		{
			_firstRoom.Equals(_secondRoom).Should().BeFalse();
		}

		[Fact]
		public void TwoRoom_Equals_ReturnTrue()
		{
			_firstRoom.Equals(_firstAgainRoom).Should().BeTrue();
		}

		[Fact]
		public void RoomToNull_Equals_ReturnFalse()
		{
			_firstRoom.Equals(null).Should().BeFalse();
		}

		[Fact]
		public void ToString_ReturnRoomName()
		{
			_firstRoom.ToString().Should().Be(FirstRoom);
		}

		[Fact]
		public void GetHashCode_ReturnId()
		{
			_firstRoom.GetHashCode().Should().Be(_firstRoom.GetId());
		}
	}
}