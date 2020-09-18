using System.Threading.Tasks;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace HuntTheWhumpusTests
{
	public class UnitTest1
	{
		[Fact]
		public async Task Test1()
		{
			var mocker = new AutoMocker();

			mocker.GetMock<ITestMocker>().Setup(x => x.ProcessIntAsync(42)).ReturnsAsync(45);

			var test = mocker.CreateInstance<Testing>();

			Assert.Equal(45, await test.process());
			mocker.VerifyAll();
		}
	}

	public class Testing
	{
		readonly ITestMocker _mocker;

		public Testing(ITestMocker mocker)
		{
			_mocker = mocker;
		}

		public async Task<int> process() => await _mocker.ProcessIntAsync(42);
	}

	public interface ITestMocker
	{
		Task<int> ProcessIntAsync(int number);
	}
}