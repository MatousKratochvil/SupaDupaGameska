using System.Threading.Tasks;
using HuntTheWhumpus.Entities.Interfaces;
using MediatR;

namespace HuntTheWhumpus.Interactor.Interfaces
{
	public interface IMovePresenter
	{
		Task<Unit> PresentAsync(IMoveable moveable);
	}
}