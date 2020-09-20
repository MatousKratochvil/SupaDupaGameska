using System;
using System.Threading.Tasks;
using FluentAssertions;
using HuntTheWhumpus.Entities;
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
				var moveable = await store.FindAsync(_moveableStoreId);

				// Assert
				moveable.Id.Should().Be(_moveableStoreId);
				moveable.GetPosition.x.Should().Be(0);
				moveable.GetPosition.y.Should().Be(-1);
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
				var moveable = await store.FindAsync(_moveableStoreId);

				// Assert
				moveable.Id.Should().Be(_moveableStoreId);
				moveable.GetPosition.x.Should().Be(0);
				moveable.GetPosition.y.Should().Be(1);
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
				var moveable = await store.FindAsync(_moveableStoreId);

				// Assert
				moveable.Id.Should().Be(_moveableStoreId);
				moveable.GetPosition.x.Should().Be(-1);
				moveable.GetPosition.y.Should().Be(0);
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
				var moveable = await store.FindAsync(_moveableStoreId);

				// Assert
				moveable.Id.Should().Be(_moveableStoreId);
				moveable.GetPosition.x.Should().Be(1);
				moveable.GetPosition.y.Should().Be(0);
			}
		}
		
	}
}