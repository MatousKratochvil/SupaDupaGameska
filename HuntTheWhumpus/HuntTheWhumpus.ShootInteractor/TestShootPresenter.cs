using System;
using System.Threading.Tasks;
using HuntTheWhumpus.Entities.Interfaces;
using HuntTheWhumpus.ShootInteractor.Interfaces;
using MediatR;

namespace HuntTheWhumpus.ShootInteractor
{
	public class TestShootPresenter : IShootPresenter
	{
		public Task<Unit> PresentAsync(IShootableEntity shootableEntity)
		{
			Console.WriteLine(shootableEntity.ToString());
			return Unit.Task;
		}
	}
}