using System;
using System.Threading.Tasks;
using HuntTheWhumpus.Entities.Interfaces;
using MediatR;

namespace HuntTheWhumpus.Interactor.Interfaces
{
	public interface IMoveableStore : IRepository<IMoveableEntity>
	{
		Task<IMoveableEntity> FindAsync(Guid id);

		Task<Unit> UpdateAsync(IMoveableEntity moveableEntity);

		Task<Guid> SaveAsync(IMoveableEntity moveableEntity);
	}
}