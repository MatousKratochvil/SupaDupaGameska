using FluentAssertions;
using HuntTheWhumpus.Core.Domain;
using Xunit;

namespace HuntTheWhumpusTests.Core
{
	public class PlayerTest
	{
		readonly Player _player;
		
		public PlayerTest()
		{
			_player = new Player(1, 1);
		}

		[Fact]
		public void PlayerShoot_DecrementedAmmunition()
		{
			_player.HasAmmunition().Should().BeTrue();
			_player.Shoot();
			_player.HasAmmunition().Should().BeFalse();
		}

		[Fact]
		public void PlayerActualRoomChange_SuccessfullyChange()
		{
			_player.GetActualRoomId().Should().Be(1);
			_player.SetActualRoom(2);
			_player.GetActualRoomId().Should().Be(2);
		}
	}
}