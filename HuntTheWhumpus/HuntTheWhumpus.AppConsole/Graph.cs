using System.Text;

namespace HuntTheWhumpus.AppConsole
{
	class Graph
	{
		// Used Adjacency Matrix for Graph 
		// Search and edge addition easy and fast O(1)
		// Creation heavy and slow but created only once
		
		readonly int _size;
		readonly bool[][] _matrix;

		public Graph(int size)
		{
			_size = size;
			_matrix = new bool[_size][];

			for (var i = 0; i < _matrix.Length; i++)
			{
				_matrix[i] = new bool[_size];
			}
		}

		public void AddEdge(int oneIndex, int twoIndex)
		{
			_matrix[oneIndex][twoIndex] = true;
			_matrix[twoIndex][oneIndex] = true;
		}

		public void RemoveEdge(int oneIndex, int twoIndex)
		{
			_matrix[oneIndex][twoIndex] = false;
			_matrix[twoIndex][oneIndex] = false;
		}

		public int Size() => _size;

		public bool ExistEdge(int oneIndex, int twoIndex) => _matrix[oneIndex][twoIndex];

		public string DisplayEdge(int[] vertices, int index)
		{
			var sb = new StringBuilder();
			for (var i = 0; i < _matrix.Length; i++)
			{
				if (_matrix[index][i])
				{
					sb.AppendLine($"{vertices[index]} is connected to {vertices[i]}");
				}
			}

			return sb.ToString();
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			for (var i = 0; i < _size; i++) {
				sb.Append($"{i}: ");
				foreach(var j in _matrix[i]) {
					sb.Append($"{(j ? 1 : 0)} ");
				}
				sb.AppendLine();
			}

			return sb.ToString();
		}
	}
}