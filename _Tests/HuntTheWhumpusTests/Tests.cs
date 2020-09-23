using Xunit;
using Xunit.Abstractions;

namespace HuntTheWhumpusTests
{
	public class Tests
	{
		const int X = 1_000;
		const int Y = 1_000;
		readonly ITestOutputHelper _output;

		public Tests(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public void Board()
		{
			Assert.True(true);
		}
	}
}