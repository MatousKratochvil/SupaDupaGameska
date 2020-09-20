using System;
using HuntTheWhumpus.ShootInteractor;
using Microsoft.Extensions.DependencyInjection;

namespace HuntTheWhumpusTests.Initializers
{
	public class ShootTestInitializer
	{
		protected ShootInteractorsFacade ShootFacade;
		protected IServiceProvider Provider;

		public ShootTestInitializer()
		{
			Provider = CreateProvider();
			ShootFacade = Provider.GetService<ShootInteractorsFacade>();
		}

		static IServiceProvider CreateProvider()
		{
			var service = new ServiceCollection();
			service.InstallShootInteractor();

			return service.BuildServiceProvider();
		}
	}
}