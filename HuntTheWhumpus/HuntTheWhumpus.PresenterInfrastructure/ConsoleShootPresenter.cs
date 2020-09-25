using System;
using System.Linq;
using HuntTheWhumpus.Application;
using HuntTheWhumpus.Application.Interactions.Shoot;
using HuntTheWhumpus.Application.Interfaces;

namespace HuntTheWhumpus.PresenterInfrastructure
{
	public sealed class ConsoleShootPresenter : IShootPresenter
	{
		public void PresentNoConnection(ShootContext context)
		{
			Console.WriteLine();
			
			Console.WriteLine($"Can't shoot to this room.");

			PrintCanShootTo(context);
		}

		public void PresentActualRoom(ShootContext context)
		{
			Console.WriteLine();
			
			Console.WriteLine($"Can't shoot to same room where you at.");

			PrintCanShootTo(context);
		}

		public void Present(ShootContext context)
		{
			Console.WriteLine();

			Console.WriteLine(context.IsWhumpusShot
				? "You shot the Whumpus"
				: "You shot to empty room"
			);

			PrintCanShootTo(context);
		}

		public void PresentNoAmmunition()
		{
			Console.WriteLine();

			Console.WriteLine("You have no ammo.");
		}

		static void PrintCanShootTo(ContextBase context)
		{
			if (context != null && context.AdjacentRooms.Any())
			{
				Console.Write($"Can shoot to: ");
				foreach (var adjacentRoom in context.AdjacentRooms)
				{
					Console.Write($"{adjacentRoom}, ");
				}

				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("No other room to shoot to.");
			}
		}
	}
}