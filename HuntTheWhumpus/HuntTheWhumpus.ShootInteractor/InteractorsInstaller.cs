using HuntTheWhumpus.ShootInteractor.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HuntTheWhumpus.ShootInteractor
{
	public static class InteractorsInstaller
	{
		public static IServiceCollection InstallShootInteractor(this IServiceCollection collection)
		{
			collection.AddMediatR(typeof(ShootInteractorsFacade).Assembly);
			collection.AddSingleton<IShootableStore, MemoryShootableStore>();
			collection.AddScoped<IShootPresenter, TestShootPresenter>();
			collection.AddScoped(typeof(ShootInteractorsFacade));

			return collection;
		}
	}
}