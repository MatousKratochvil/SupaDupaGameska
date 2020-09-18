using System;
using System.Threading.Tasks;
using HuntTheWhumpus.Interactor;
using Microsoft.Extensions.DependencyInjection;

namespace AAA_testConsole
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var move = Provider().GetService<InteractorsFacade>();

			await move.MoveUp(Guid.Empty);
			await move.MoveUp(Guid.Empty);
			
			await move.MoveDown(Guid.Empty);
			await move.MoveDown(Guid.Empty);

			await move.MoveLeft(Guid.Empty);
			await move.MoveLeft(Guid.Empty);

			await move.MoveRight(Guid.Empty);
			await move.MoveRight(Guid.Empty);

			Console.WriteLine("KONEC");
		}

		static IServiceProvider Provider()
		{
			var service = new ServiceCollection();
			service.Install();

			return service.BuildServiceProvider();
		}
	}
}