using System;
using System.Threading.Tasks;
using HuntTheWhumpus.Application.Interfaces;
using HuntTheWhumpus.Core.Domain;

namespace HuntTheWhumpus.Application.Interactions.Move
{
	public class MoveInteraction : InteractionBase
	{
		readonly IMovePresenter _presenter;

		public MoveInteraction(Player player, Board board, IMovePresenter presenter) : base(player, board)
		{
			_presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
		}

		public override async Task ExecuteAsync(int toRoomId)
		{
			var context = new MoveContext();

			int roomId = Player.GetActualRoomId();
			context.SetActualRoom(await Board.GetRoomAsync(roomId));
			
			await FillAdjustedRoomsAsync(roomId, context);

			if (roomId == toRoomId)
				_presenter.PresentActualRoom(context);
			
			else if (!Board.HasRoomConnection(roomId, toRoomId))
				_presenter.PresentNoConnection(context);
			
			else
			{
				Player.SetActualRoom(toRoomId);
				context.SetPreviousRoom(await Board.GetRoomAsync(roomId));
				context.SetActualRoom(await Board.GetRoomAsync(toRoomId));

				_presenter.Present(context);
			}
		}
	}
}