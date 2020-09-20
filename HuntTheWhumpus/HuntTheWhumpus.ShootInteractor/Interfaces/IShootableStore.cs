using System;
using System.Threading.Tasks;
using HuntTheWhumpus.Entities.Interfaces;
using MediatR;

namespace HuntTheWhumpus.ShootInteractor.Interfaces
{
	public interface IShootableStore : IRepository<IShootable>
	{
		Task<IShootable> FindAsync(Guid id);

		Task<Unit> UpdateAsync(IShootable moveable);

		Task<Guid> SaveAsync(IShootable moveable);
	}
}