using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HuntTheWhumpus.Core.Interfaces;

namespace HuntTheWhumpus.Core.Domain
{
	public sealed class Board
	{
		readonly IRoomRepository _roomRepository;
		readonly Graph _roomConnections;
		
		public Board(int size, IRoomRepository roomRepository)
		{
			_roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
			_roomConnections = new Graph(size);
		}

		public async Task<bool> AddRoomAsync(Room room, params int[] connectionToRoom)
		{
			AddConnections(room.GetConnectionId(), connectionToRoom);
			if (!await _roomRepository.SaveAsync(room))
				RevertConnections(room.GetConnectionId(), connectionToRoom);
			
			return true;
		}

		public Task<Room> GetRoomAsync(int id) => _roomRepository.GetAsync(id);

		public bool HasRoomConnection(int fromId, int toId) => _roomConnections.HasEdge(fromId, toId);

		void RevertConnections(int roomConnectionId, IEnumerable<int> connectionToRoom)
		{
			foreach (int connectionId in connectionToRoom)
			{
				_roomConnections.RemoveEdge(roomConnectionId, connectionId);
			}
		}

		void AddConnections(int roomConnectionId, IEnumerable<int> connectionToRoom)
		{
			foreach (int connectionId in connectionToRoom)
			{
				_roomConnections.AddEdge(roomConnectionId, connectionId);
			}
		}

		public async IAsyncEnumerable<Room> GetConnectedRooms(int fromRoomId)
		{
			foreach (int roomConnectionId in _roomConnections.GetAllConnections(fromRoomId))
			{
				var room = await _roomRepository.GetByConnectionIdAsync(roomConnectionId);
				yield return room;
			}
		}
	}
}