using HuntTheWhumpus.Interactor.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HuntTheWhumpus.Interactor
{
	public static class InteractorsInstaller
	{
		public static IServiceCollection InstallMoveInteractor(this IServiceCollection collection)
		{
			collection.AddMediatR(typeof(MoveInteractorsFacade).Assembly);
			collection.AddSingleton<IMoveableStore, MemoryMoveableStore>();
			collection.AddScoped<IMovePresenter, TestMovePresenter>();
			collection.AddScoped(typeof(MoveInteractorsFacade));

			return collection;
		}
	}
}