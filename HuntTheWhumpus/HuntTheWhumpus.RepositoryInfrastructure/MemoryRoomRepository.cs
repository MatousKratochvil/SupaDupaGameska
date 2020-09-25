using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HuntTheWhumpus.Core.Domain;
using HuntTheWhumpus.Core.Interfaces;
using LanguageExt;

namespace HuntTheWhumpus.RepositoryInfrastructure
{
	public sealed class MemoryRoomRepository : IRoomRepository
	{
		readonly IDictionary<int, Room> _dictionary = new Dictionary<int, Room>();

		public Task<Room> GetAsync(in int id)
			=> _dictionary.ContainsKey(id)
				? _dictionary[id].AsTask()
				: Task.FromResult<Room>(null!); 

		public Task<bool> SaveAsync(Room room)
		{
			_dictionary.Add(room.GetId(), room);

			return Task.FromResult(true);
		}

		public Task<Room> GetByConnectionIdAsync(int roomConnectionId)
			=> Task.FromResult(
				_dictionary.Values.FirstOrDefault(x => x.GetConnectionId() == roomConnectionId)
			);
	}
}