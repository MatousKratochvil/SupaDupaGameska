using System;
using System.Drawing;

namespace HuntTheWhumpus.AppConsole
{
	static class Program
	{
		static void Main(string[] args)
		{
			var board = LoadDungeon();
			var player = LoadPlayer();

			for (var i = 0; i < 200; i++)
			{
				MovePlayerUp(board, player);
				MovePlayerLeft(board, player);
			}

			for (var i = 0; i < 20; i++)
			{
				MovePlayerDown(board, player);
				MovePlayerRight(board, player);
			}

			for (var i = 0; i < 200; i++)
			{
				MovePlayerUp(board, player);
			}

			board.ShowGraph();
			board.DisplayEdge(3);
		}

		static void MovePlayerDown(Board board, Player player)
		{
			if (!board.CanMoveDown(player)) return;

			player.MoveDown();
			Console.WriteLine(player);
		}

		static void MovePlayerUp(Board board, Player player)
		{
			if (!board.CanMoveUp(player)) return;

			player.MoveUp();
			Console.WriteLine(player);
		}

		static void MovePlayerRight(Board board, Player player)
		{
			if (!board.CanMoveRight(player)) return;

			player.MoveRight();
			Console.WriteLine(player);
		}

		static void MovePlayerLeft(Board board, Player player)
		{
			if (!board.CanMoveLeft(player)) return;

			player.MoveLeft();
			Console.WriteLine(player);
		}

		static Player LoadPlayer()
			=> new Player(new Point(5, 5));


		static Board LoadDungeon()
			=> new Board(5);
	}
}