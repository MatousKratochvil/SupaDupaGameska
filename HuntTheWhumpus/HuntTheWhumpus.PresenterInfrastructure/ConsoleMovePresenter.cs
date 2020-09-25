using System;
using System.Linq;
using HuntTheWhumpus.Application.Interactions.Move;
using HuntTheWhumpus.Application.Interfaces;

namespace HuntTheWhumpus.PresenterInfrastructure
{
	public sealed class ConsoleMovePresenter : IMovePresenter
	{
		public void Present(MoveContext context)
		{
			Console.WriteLine();

			Console.WriteLine($"Actual room: {context.ActualRoom}.");
			
			PrintCanMoveTo(context);
		}

		public void PresentActualRoom(MoveContext context)
		{
			Console.WriteLine();

			Console.WriteLine("You are already in this room.");

			PrintCanMoveTo(context);
		}
		
		public void PresentNoConnection(MoveContext context)
		{
			Console.WriteLine();

			Console.WriteLine($"Room are not connected.");
			Console.WriteLine($"You are in room: {context.ActualRoom}");
			
			PrintCanMoveTo(context);
		}
		
		static void PrintCanMoveTo(MoveContext context)
		{
			if (context != null && context.AdjacentRooms.Any())
			{
				Console.Write($"Can move to: ");
				foreach (var adjacentRoom in context.AdjacentRooms)
				{
					Console.Write($"{adjacentRoom}, ");
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("No other room to go to.");
			}

			if (context?.PreviousRoom != null)
				Console.WriteLine($"Can go back to: {context.PreviousRoom}.");
		}
	}
}