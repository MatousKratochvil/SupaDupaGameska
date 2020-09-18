using System;
using System.Threading.Tasks;
using HuntTheWhumpus.Interactor.Interfaces;
using MediatR;

namespace HuntTheWhumpus.Interactor
{
	public class TestPresenter : IPresenter
	{
		public Task<Unit> PresentAsync(IMoveable moveable)
		{
			Console.WriteLine(moveable.ToString());
			return Unit.Task;
		}
	}
}