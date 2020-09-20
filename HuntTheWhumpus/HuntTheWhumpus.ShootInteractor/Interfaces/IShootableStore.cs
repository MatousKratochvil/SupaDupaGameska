using System;
using System.Threading.Tasks;
using HuntTheWhumpus.Entities.Interfaces;
using MediatR;

namespace HuntTheWhumpus.ShootInteractor.Interfaces
{
	public interface IShootableStore : IRepository<IShootableEntity>
	{
		Task<IShootableEntity> FindAsync(Guid id);

		Task<Unit> UpdateAsync(IShootableEntity moveable);

		Task<Guid> SaveAsync(IShootableEntity moveable);
	}
}