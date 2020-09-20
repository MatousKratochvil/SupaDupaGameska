using System;
using System.Threading.Tasks;
using HuntTheWhumpus.Entities.Interfaces;
using HuntTheWhumpus.Interactor.Interfaces;
using MediatR;

namespace HuntTheWhumpus.Interactor
{
	public class TestMovePresenter : IMovePresenter
	{
		public Task<Unit> PresentAsync(IMoveableEntity moveableEntity)
		{
			Console.WriteLine(moveableEntity.ToString());
			return Unit.Task;
		}
	}
}