using System.Threading.Tasks;
using HuntTheWhumpus.Core.Domain;

namespace HuntTheWhumpus.Core.Interfaces
{
	public interface IRoomRepository : IRepository<Room>
	{
		Task<Room>? GetAsync(in int id);

		Task<bool> SaveAsync(Room room);
		
		Task<Room> GetByConnectionIdAsync(int roomConnectionId);
	}
}