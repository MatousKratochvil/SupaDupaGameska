using HuntTheWhumpus.Application.Interactions.Shoot;

namespace HuntTheWhumpus.Application.Interfaces
{
	public interface IShootPresenter
	{
		void PresentNoConnection(ShootContext context);
		void PresentActualRoom(ShootContext context);
		void Present(ShootContext context);
		void PresentNoAmmunition();
	}
}