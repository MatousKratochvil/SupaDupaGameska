using System.Threading.Tasks;
using HuntTheWhumpus.Entities.Interfaces;
using MediatR;

namespace HuntTheWhumpus.ShootInteractor.Interfaces
{
	public interface IShootPresenter
	{
		Task<Unit> PresentAsync(IShootable shootable);
	}
}