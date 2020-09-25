// Used Adjacency Matrix for Graph 
// Search and edge addition easy and fast O(1)
// Creation heavy and slow but created only once

using System.Collections.Generic;

namespace HuntTheWhumpus.Core
{
	public class Graph
	{
		readonly bool[][] _edgeMatrix;
		readonly int _size;

		public Graph(int size)
		{
			_size = size;
			_edgeMatrix = new bool[_size][];

			for (int i = 0; i < _edgeMatrix.Length; i++)
				_edgeMatrix[i] = new bool[_size];
		}

		public bool AddEdge(int firstIndex, int secondIndex)
		{
			if (!InRangeCheck(firstIndex, secondIndex))
				return false;

			_edgeMatrix[firstIndex][secondIndex] = true;
			_edgeMatrix[secondIndex][firstIndex] = true;
			
			return true;
		}

		public bool RemoveEdge(int firstIndex, int secondIndex)
		{
			if (!InRangeCheck(firstIndex, secondIndex))
				return false;

			_edgeMatrix[firstIndex][secondIndex] = false;
			_edgeMatrix[secondIndex][firstIndex] = false;

			return true;
		}

		public bool HasEdge(int firstIndex, int secondIndex)
		{
			if (!InRangeCheck(firstIndex, secondIndex))
				return false;

			return _edgeMatrix[firstIndex][secondIndex] && _edgeMatrix[secondIndex][firstIndex];
		}

		bool InRangeCheck(int firstIndex, int secondIndex)
			=> firstIndex < _size || secondIndex < _size;

		public IEnumerable<int> GetAllConnections(int toRoomId)
		{
			for (int i = 0; i < _size; i++)
			{
				if (_edgeMatrix[toRoomId][i])
					yield return i;
			}
		}
	}
}