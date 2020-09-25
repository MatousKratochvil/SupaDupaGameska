using HuntTheWhumpus.Application.Interactions.Move;

namespace HuntTheWhumpus.Application.Interfaces
{
	public interface IMovePresenter
	{
		void Present(MoveContext context);
		void PresentActualRoom(MoveContext context);
		void PresentNoConnection(MoveContext context);
	}
}