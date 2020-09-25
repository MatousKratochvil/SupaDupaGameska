using FluentAssertions;
using HuntTheWhumpus.Core.Domain;
using Xunit;

namespace HuntTheWhumpusTests.Core
{
	public class WhumpusTest
	{
		readonly Whumpus _whumpus;
		
		public WhumpusTest()
		{
			_whumpus = new Whumpus(1);
		}
		
		[Fact]
		public void PlayerActualRoomChange_SuccessfullyChange()
		{
			_whumpus.GetActualRoomId().Should().Be(1);
			_whumpus.SetActualRoom(2);
			_whumpus.GetActualRoomId().Should().Be(2);
		}
	}
}