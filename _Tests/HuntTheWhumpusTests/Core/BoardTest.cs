using System.Threading.Tasks;
using FluentAssertions;
using HuntTheWhumpus.Core.Domain;
using HuntTheWhumpus.Core.Interfaces;
using HuntTheWhumpus.RepositoryInfrastructure;
using Xunit;

namespace HuntTheWhumpusTests.Core
{
	public class BoardTest
	{
		readonly Board _board;
		readonly MemoryRoomRepository _repository;
		readonly RepositoryReturnFalseOnSave _repositoryReturnFalse;

		public BoardTest()
		{ 
			_repository = new MemoryRoomRepository();
			_board = new Board(5, _repository);
			
			_repositoryReturnFalse = new RepositoryReturnFalseOnSave();
		}
		
		static Room CreateRoom() => new Room("TestRoom", 1, 1);
		static Room CreateSecondRoom() => new Room("TestRoom2", 2, 2);

		[Fact]
		public async Task Board_AddRoomWithConnection_SuccessfullyReturns()
		{
			var room = CreateRoom();
			await _board.AddRoomAsync(room, 1, 2, 3, 4);
			
			_board.HasRoomConnection(1, 2).Should().BeTrue();
		}

		[Fact]
		public async Task Board_AddRoomWithConnection_Failed_NoConnections()
		{
			// Arrange
			var boardNoConnection = new Board(5, _repositoryReturnFalse);
			
			var room = CreateRoom();
			await boardNoConnection.AddRoomAsync(room, 2, 3, 4);

			boardNoConnection.HasRoomConnection(1, 2).Should().BeFalse();
		}

		[Fact]
		public async Task Board_GetRoomAsync_SuccessfullyReturn()
		{
			var room = CreateRoom();

			await _board.AddRoomAsync(room, 1);

			var roomReturn = await _board.GetRoomAsync(room.GetId());

			roomReturn.Should().Be(room);
		}

		[Fact]
		public async Task AllConnectionToRoom_SuccessfullyReturn()
		{
			var room = CreateRoom();
			var roomTwo = CreateSecondRoom();

			await _board.AddRoomAsync(room, 2);
			await _board.AddRoomAsync(roomTwo, 1);

			await foreach (var connectedRoom in _board.GetConnectedRooms(room.GetId()))
			{
				connectedRoom.Should().Be(roomTwo);
			}
		}
	}

	class RepositoryReturnFalseOnSave : IRoomRepository
	{
		public Task<Room>? GetAsync(in int id) => null;

		public Task<bool> SaveAsync(Room room) => Task.FromResult(false);

		public Task<Room> GetByConnectionIdAsync(int roomConnectionId) => null!;
	}
}