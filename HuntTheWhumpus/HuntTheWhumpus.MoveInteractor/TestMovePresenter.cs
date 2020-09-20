using System;
using System.Threading.Tasks;
using HuntTheWhumpus.Entities.Interfaces;
using HuntTheWhumpus.Interactor.Interfaces;
using MediatR;

namespace HuntTheWhumpus.Interactor
{
	public class TestMovePresenter : IMovePresenter
	{
		public Task<Unit> PresentAsync(IMoveable moveable)
		{
			Console.WriteLine(moveable.ToString());
			return Unit.Task;
		}
	}
}