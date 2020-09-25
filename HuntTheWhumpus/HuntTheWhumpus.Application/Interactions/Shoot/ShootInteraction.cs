using System;
using System.Threading.Tasks;
using HuntTheWhumpus.Application.Interfaces;
using HuntTheWhumpus.Core.Domain;

namespace HuntTheWhumpus.Application.Interactions.Shoot
{
	public class ShootInteraction : InteractionBase
	{
		readonly Whumpus _whumpus;
		readonly IShootPresenter _presenter;

		public ShootInteraction(Player player, Board board, Whumpus whumpus, IShootPresenter shootPresenter) : base(player, board)
		{
			_whumpus = whumpus ?? throw new ArgumentNullException(nameof(whumpus));
			_presenter = shootPresenter ?? throw new ArgumentNullException(nameof(shootPresenter));
		}

		public override async Task ExecuteAsync(int toRoomId)
		{
			var context = new ShootContext();

			int roomId = Player.GetActualRoomId();
			context.SetActualRoom(await Board.GetRoomAsync(roomId));
			
			await FillAdjustedRoomsAsync(roomId, context);

			if (roomId == toRoomId)
				_presenter.PresentActualRoom(context);

			else if (!Board.HasRoomConnection(roomId, toRoomId))
				_presenter.PresentNoConnection(context);

			else if (!Player.HasAmmunition())
				_presenter.PresentNoAmmunition();
			
			else
			{
				Player.Shoot();
				
				context.SetShootRoom(await Board.GetRoomAsync(toRoomId));

				context.SetShotWhumpus(_whumpus.GetActualRoomId() == toRoomId);

				_presenter.Present(context);
			}

			var shootToRoom = await Board.GetRoomAsync(toRoomId);
			context.SetShootRoom(shootToRoom);
		}
	}
}