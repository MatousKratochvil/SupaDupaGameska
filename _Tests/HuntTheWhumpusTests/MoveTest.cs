using System;
using System.Threading.Tasks;
using FluentAssertions;
using HuntTheWhumpus.Entities.Player;
using HuntTheWhumpus.Interactor;
using HuntTheWhumpus.Interactor.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HuntTheWhumpusTests
{
	public class MoveTest
	{
		public class TestInitiazlier
		{
			protected InteractorsFacade MoveFacade;
			protected IServiceProvider Provider;

			public TestInitiazlier()
			{
				Provider = CreateProvider();
				MoveFacade = Provider.GetService<InteractorsFacade>();
			}

			static IServiceProvider CreateProvider()
			{
				var service = new ServiceCollection();
				service.InstallInteractor();

				return service.BuildServiceProvider();
			}
		}

		public class MoveUp : TestInitiazlier
		{
			static Guid MoveableStoreId = Guid.Empty;

			[Fact]
			public async Task MoveUp_SuccessResult()
			{
				// Arrange 
				var store = Provider.GetService<IMoveableStore>();

				// Act
				await MoveFacade.MoveUp(MoveableStoreId);
				var player = (Player) await store.FindAsync(MoveableStoreId);

				// Assert
				player.Id.Should().Be(MoveableStoreId);
				player.GetPosition.x.Should().Be(0);
				player.GetPosition.y.Should().Be(-1);
			}
		}

		public class MoveDown : TestInitiazlier
		{
			static Guid MoveableStoreId = Guid.Empty;

			[Fact]
			public async Task MoveDown_SuccessResult()
			{
				// Arrange 
				var store = Provider.GetService<IMoveableStore>();

				// Act
				await MoveFacade.MoveDown(MoveableStoreId);
				var player = (Player) await store.FindAsync(MoveableStoreId);

				// Assert
				player.Id.Should().Be(MoveableStoreId);
				player.GetPosition.x.Should().Be(0);
				player.GetPosition.y.Should().Be(1);
			}
		}
		
		public class MoveLeft : TestInitiazlier
		{
			static Guid MoveableStoreId = Guid.Empty;

			[Fact]
			public async Task MoveLeft_SuccessResult()
			{
				// Arrange 
				var store = Provider.GetService<IMoveableStore>();

				// Act
				await MoveFacade.MoveLeft(MoveableStoreId);
				var player = (Player) await store.FindAsync(MoveableStoreId);

				// Assert
				player.Id.Should().Be(MoveableStoreId);
				player.GetPosition.x.Should().Be(-1);
				player.GetPosition.y.Should().Be(0);
			}
		}
		
		public class MoveRight : TestInitiazlier
		{
			static Guid MoveableStoreId = Guid.Empty;

			[Fact]
			public async Task MoveRight_SuccessResult()
			{
				// Arrange 
				var store = Provider.GetService<IMoveableStore>();

				// Act
				await MoveFacade.MoveRight(MoveableStoreId);
				var player = (Player) await store.FindAsync(MoveableStoreId);

				// Assert
				player.Id.Should().Be(MoveableStoreId);
				player.GetPosition.x.Should().Be(1);
				player.GetPosition.y.Should().Be(0);
			}
		}
		
	}
}