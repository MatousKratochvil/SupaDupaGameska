using System;
using System.Threading.Tasks;
using HuntTheWhumpus.Core.Domain;

namespace HuntTheWhumpus.Application
{
	public abstract class InteractionBase
	{
		protected readonly Player Player;
		protected readonly Board Board;

		protected InteractionBase(Player player, Board board)
		{
			Player = player ?? throw new ArgumentNullException(nameof(player));
			Board = board ?? throw new ArgumentNullException(nameof(board));
		}
		
		public abstract Task ExecuteAsync(int toRoomId);

		protected async Task FillAdjustedRoomsAsync(int roomId, ContextBase context)
		{
			await foreach (var room in Board.GetConnectedRooms(roomId))
				context.AddAdjustedRoom(room);
		}
	}
}