using System;
using System.Threading.Tasks;
using FluentAssertions;
using HuntTheWhumpus.Entities;
using HuntTheWhumpus.ShootInteractor.Interfaces;
using HuntTheWhumpusTests.Initializers;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HuntTheWhumpusTests
{
	public class ShootTest
	{
		public class ShootUp : ShootTestInitializer
		{
			static Guid _shootableStoreId = Guid.Empty;

			[Fact]
			public async Task ShootUp_SuccessResult()
			{
				// Arrange 
				var store = Provider.GetService<IShootableStore>();

				// Act
				await ShootFacade.ShootUp(_shootableStoreId);
				var shootable = await store.FindAsync(_shootableStoreId);

				// Assert
				shootable.Id.Should().Be(_shootableStoreId);
				shootable.GetShootLocation.x.Should().Be(0);
				shootable.GetShootLocation.y.Should().Be(-1);
			}
		}

		public class ShootDown : ShootTestInitializer
		{
			static Guid _shootableStoreId = Guid.Empty;

			[Fact]
			public async Task MoveDown_SuccessResult()
			{
				// Arrange 
				var store = Provider.GetService<IShootableStore>();

				// Act
				await ShootFacade.ShootDown(_shootableStoreId);
				var shootable = await store.FindAsync(_shootableStoreId);

				// Assert
				shootable.Id.Should().Be(_shootableStoreId);
				shootable.GetShootLocation.x.Should().Be(0);
				shootable.GetShootLocation.y.Should().Be(1);
			}
		}

		public class ShootLeft : ShootTestInitializer
		{
			static Guid _shootableStoreId = Guid.Empty;

			[Fact]
			public async Task MoveLeft_SuccessResult()
			{
				// Arrange 
				var store = Provider.GetService<IShootableStore>();

				// Act
				await ShootFacade.ShootLeft(_shootableStoreId);
				var shootable = await store.FindAsync(_shootableStoreId);

				// Assert
				shootable.Id.Should().Be(_shootableStoreId);
				shootable.GetShootLocation.x.Should().Be(-1);
				shootable.GetShootLocation.y.Should().Be(0);
			}
		}

		public class ShootRight : ShootTestInitializer
		{
			static Guid _shootableStoreId = Guid.Empty;

			[Fact]
			public async Task MoveRight_SuccessResult()
			{
				// Arrange 
				var store = Provider.GetService<IShootableStore>();

				// Act
				await ShootFacade.ShootRight(_shootableStoreId);
				var shootable = await store.FindAsync(_shootableStoreId);

				// Assert
				shootable.Id.Should().Be(_shootableStoreId);
				shootable.GetShootLocation.x.Should().Be(1);
				shootable.GetShootLocation.y.Should().Be(0);
			}
		}
	}
}