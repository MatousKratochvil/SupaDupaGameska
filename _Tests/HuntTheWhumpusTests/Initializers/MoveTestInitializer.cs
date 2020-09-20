using System;
using HuntTheWhumpus.Interactor;
using Microsoft.Extensions.DependencyInjection;

namespace HuntTheWhumpusTests.Initializers
{
	public class MoveTestInitializer
	{
		protected MoveInteractorsFacade MoveFacade;
		protected IServiceProvider Provider;

		public MoveTestInitializer()
		{
			Provider = CreateProvider();
			MoveFacade = Provider.GetService<MoveInteractorsFacade>();
		}

		static IServiceProvider CreateProvider()
		{
			var service = new ServiceCollection();
			service.InstallMoveInteractor();

			return service.BuildServiceProvider();
		}
	}
}