using HuntTheWhumpus.Interactor.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HuntTheWhumpus.Interactor
{
	public static class InteractorsInstaller
	{
		public static IServiceCollection InstallInteractor(this IServiceCollection collection)
		{
			collection.AddMediatR(typeof(InteractorsFacade).Assembly);
			collection.AddSingleton<IMoveableStore, MemoryMoveableStore>();
			collection.AddScoped<IPresenter, TestPresenter>();
			collection.AddScoped(typeof(InteractorsFacade));

			return collection;
		}
	}
}