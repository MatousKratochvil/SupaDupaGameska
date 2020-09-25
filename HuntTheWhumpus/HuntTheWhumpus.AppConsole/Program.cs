using System;
using System.Threading.Tasks;
using HuntTheWhumpus.Application.Interactions.Move;
using HuntTheWhumpus.Application.Interactions.Shoot;
using HuntTheWhumpus.Application.Interfaces;
using HuntTheWhumpus.Core.Domain;
using HuntTheWhumpus.Core.Interfaces;
using HuntTheWhumpus.PresenterInfrastructure;
using HuntTheWhumpus.RepositoryInfrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace HuntTheWhumpus.AppConsole
{
	static class Program
	{
		static async Task Main(string[] args)
		{
			var provider = InitializeServiceProvider();

			await MoveTo(2, provider);
			await ShootTo(3, provider);
			// should kill whumpus
			
			await MoveTo(3, provider);
			await MoveTo(0, provider);
			await MoveTo(3, provider);
			await MoveTo(2, provider);
			await MoveTo(4, provider);
			
			await MoveTo(4, provider);
			await MoveTo(2, provider);
			await MoveTo(4, provider);
			await MoveTo(2, provider);
			
			await MoveTo(4, provider);
			await MoveTo(4, provider);

			await ShootTo(0, provider);
			await ShootTo(1, provider);
			await ShootTo(2, provider);
			await ShootTo(3, provider);
			await ShootTo(4, provider);
			
			await ShootTo(2, provider);
			await ShootTo(2, provider);
			await ShootTo(2, provider);
			await ShootTo(2, provider);
			await ShootTo(2, provider);
			await ShootTo(2, provider);
		}

		static async Task MoveTo(int toRoomId, IServiceProvider provider)
		{
			var moveInteraction = provider.GetService<MoveInteraction>();
			await moveInteraction.ExecuteAsync(toRoomId);
		}

		static async Task ShootTo(int toRoomId, IServiceProvider provider)
		{
			var shootInteraction = provider.GetService<ShootInteraction>();
			await shootInteraction.ExecuteAsync(toRoomId);
		}

		static IServiceProvider InitializeServiceProvider()
		{
			var serviceCollection = new ServiceCollection();

			serviceCollection.AddSingleton(new Player(1, 5));
			serviceCollection.AddSingleton(new Whumpus(3));

			serviceCollection.AddSingleton<IRoomRepository, MemoryRoomRepository>();
			
			serviceCollection.AddSingleton<IMovePresenter, ConsoleMovePresenter>();
			serviceCollection.AddSingleton<IShootPresenter, ConsoleShootPresenter>();

			serviceCollection.AddScoped<MoveInteraction>();
			serviceCollection.AddScoped<ShootInteraction>();

			serviceCollection.LoadDungeon();

			return serviceCollection.BuildServiceProvider();
		}

		static void LoadDungeon(this IServiceCollection services)
		{
			var provider = services.BuildServiceProvider();

			services.AddSingleton(LoadDungeon(provider).GetAwaiter().GetResult());
		}


		static async Task<Board> LoadDungeon(ServiceProvider serviceProvider)
		{
			const int size = 5;

			var board = new Board(size, serviceProvider.GetService<IRoomRepository>());

			await board.AddRoomAsync(new Room("Hallway part1", 0, 0), 3);
			await board.AddRoomAsync(new Room("Hallway part2",1, 1), 2, 0);
			await board.AddRoomAsync(new Room("Central room",2, 2), 1, 2, 3, 4, 0);
			await board.AddRoomAsync(new Room("Kitchen",3, 3), 2, 0);
			await board.AddRoomAsync(new Room("Bathroom",4, 4), 2);

			return board;
		}
	}
}