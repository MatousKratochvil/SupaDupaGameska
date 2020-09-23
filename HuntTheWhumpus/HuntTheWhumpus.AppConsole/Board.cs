using System;

namespace HuntTheWhumpus.AppConsole
{
	class Board
	{
		Graph Graph { get; }

		readonly int[] _vertices;

		public Board(int size)
		{
			Graph = new Graph(size);

			_vertices = new int[Graph.Size()];

			for (var i = 0; i < _vertices.Length; i++)
			{
				_vertices[i] = i;
			}

			Array.Sort(_vertices);

			var index0 = Array.BinarySearch(_vertices, 0);
			var index1 = Array.BinarySearch(_vertices, 1);
			var index2 = Array.BinarySearch(_vertices, 2);
			var index3 = Array.BinarySearch(_vertices, 3);

			Graph.AddEdge(index0, index1);
			Graph.AddEdge(index0, index3);

			Graph.AddEdge(index3, index1);
			Graph.AddEdge(index3, index2);
		}

		public void ShowGraph()
		{
			Console.WriteLine(Graph.ToString());
		}


		public void DisplayEdge(int index)
		{
			Console.WriteLine(Graph.DisplayEdge(_vertices, index));
		}

		public bool CanMoveLeft(Player player)
		{
			return true;
		}

		public bool CanMoveRight(Player player)
		{
			return true;
		}

		public bool CanMoveUp(Player player)
		{
			return true;
		}

		public bool CanMoveDown(Player player)
		{
			return true;
		}
	}
}