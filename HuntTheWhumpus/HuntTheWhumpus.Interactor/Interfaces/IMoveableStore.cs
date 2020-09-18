using System;
using System.Threading.Tasks;
using MediatR;

namespace HuntTheWhumpus.Interactor.Interfaces
{
	public interface IMoveableStore : IRepository<IMoveable>
	{
		Task<IMoveable> FindAsync(Guid id);

		Task<Unit> UpdateAsync(IMoveable moveable);

		Task<Guid> SaveAsync(IMoveable moveable);
	}
}