using System;
using System.Threading.Tasks;
using FluentAssertions;
using HuntTheWhumpus.Entities.Player;
using HuntTheWhumpus.Interactor.Interfaces;
using HuntTheWhumpusTests.Initializers;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HuntTheWhumpusTests
{
	public class MoveTest
	{
		public class MoveUp : MoveTestInitializer
		{
			static Guid _moveableStoreId = Guid.Empty;

			[Fact]
			public async Task MoveUp_SuccessResult()
			{
				// Arrange 
				var store = Provider.GetService<IMoveableStore>();

				// Act
				await MoveFacade.MoveUp(_moveableStoreId);
				var player = (Player) await store.FindAsync(_moveableStoreId);

				// Assert
				player.Id.Should().Be(_moveableStoreId);
				player.GetPosition.x.Should().Be(0);
				player.GetPosition.y.Should().Be(-1);
			}
		}

		public class MoveDown : MoveTestInitializer
		{
			static Guid _moveableStoreId = Guid.Empty;

			[Fact]
			public async Task MoveDown_SuccessResult()
			{
				// Arrange 
				var store = Provider.GetService<IMoveableStore>();

				// Act
				await MoveFacade.MoveDown(_moveableStoreId);
				var player = (Player) await store.FindAsync(_moveableStoreId);

				// Assert
				player.Id.Should().Be(_moveableStoreId);
				player.GetPosition.x.Should().Be(0);
				player.GetPosition.y.Should().Be(1);
			}
		}
		
		public class MoveLeft : MoveTestInitializer
		{
			static Guid _moveableStoreId = Guid.Empty;

			[Fact]
			public async Task MoveLeft_SuccessResult()
			{
				// Arrange 
				var store = Provider.GetService<IMoveableStore>();

				// Act
				await MoveFacade.MoveLeft(_moveableStoreId);
				var player = (Player) await store.FindAsync(_moveableStoreId);

				// Assert
				player.Id.Should().Be(_moveableStoreId);
				player.GetPosition.x.Should().Be(-1);
				player.GetPosition.y.Should().Be(0);
			}
		}
		
		public class MoveRight : MoveTestInitializer
		{
			static Guid _moveableStoreId = Guid.Empty;

			[Fact]
			public async Task MoveRight_SuccessResult()
			{
				// Arrange 
				var store = Provider.GetService<IMoveableStore>();

				// Act
				await MoveFacade.MoveRight(_moveableStoreId);
				var player = (Player) await store.FindAsync(_moveableStoreId);

				// Assert
				player.Id.Should().Be(_moveableStoreId);
				player.GetPosition.x.Should().Be(1);
				player.GetPosition.y.Should().Be(0);
			}
		}
		
	}
}