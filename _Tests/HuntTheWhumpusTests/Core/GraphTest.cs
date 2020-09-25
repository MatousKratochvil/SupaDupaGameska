using FluentAssertions;
using HuntTheWhumpus.Core;
using Xunit;

namespace HuntTheWhumpusTests.Core
{
	public class GraphTest
	{
		readonly Graph _graph;

		public GraphTest()
		{
			_graph = new Graph(5);
		}

		[Fact]
		public void AddEdge_InRangeNumbers_CreatedEdge()
		{
			_graph.AddEdge(1, 2).Should().BeTrue();
			_graph.HasEdge(1, 2).Should().BeTrue();
		}

		[Fact]
		public void AddEdge_OutOfRangeNumbers_FailedResult()
		{
			_graph.AddEdge(int.MaxValue, int.MaxValue).Should().BeFalse();
			_graph.HasEdge(int.MaxValue, int.MaxValue).Should().BeFalse();
		}

		[Fact]
		void RemoveEdge_InRangeNumbers_RemoveEdge()
		{
			_graph.AddEdge(1, 2);
			_graph.HasEdge(1, 2).Should().BeTrue();

			_graph.RemoveEdge(1, 2).Should().BeTrue();
			_graph.HasEdge(1, 2).Should().BeFalse();
		}
		
		[Fact]
		void RemoveEdge_OutOfRangeNumbers_FailedResult()
		{
			_graph.RemoveEdge(int.MaxValue, int.MaxValue).Should().BeFalse();
		}

		[Fact]
		void GetAllConnection_InRangeNumber_AllConnectionResult()
		{
			_graph.AddEdge(1, 2);
			_graph.AddEdge(1, 3);
			_graph.AddEdge(1, 4);

			_graph.GetAllConnections(1).Should().HaveCount(3);
		}
	}
}