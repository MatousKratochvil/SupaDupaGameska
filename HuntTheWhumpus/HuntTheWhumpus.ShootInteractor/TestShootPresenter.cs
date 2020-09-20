using System;
using System.Threading.Tasks;
using HuntTheWhumpus.Entities.Interfaces;
using HuntTheWhumpus.ShootInteractor.Interfaces;
using MediatR;

namespace HuntTheWhumpus.ShootInteractor
{
	public class TestShootPresenter : IShootPresenter
	{
		public Task<Unit> PresentAsync(IShootable shootable)
		{
			Console.WriteLine(shootable.ToString());
			return Unit.Task;
		}
	}
}