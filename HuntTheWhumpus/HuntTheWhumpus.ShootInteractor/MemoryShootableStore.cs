using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HuntTheWhumpus.Entities;
using HuntTheWhumpus.Entities.Interfaces;
using HuntTheWhumpus.ShootInteractor.Interfaces;
using MediatR;

namespace HuntTheWhumpus.ShootInteractor
{
	class MemoryShootableStore : IShootableStore
	{
		static readonly object Lock = new object();

		readonly Dictionary<Guid, IShootableEntity> _dictionary = new Dictionary<Guid, IShootableEntity> {{Guid.Empty, new Player()}};

		public Task<IShootableEntity> FindAsync(Guid id)
		{
			IShootableEntity moveable = null;
			lock (Lock)
			{
				moveable = _dictionary[id];
			}

			return Task.FromResult(moveable);
		}

		public Task<Unit> UpdateAsync(IShootableEntity shootableEntity)
		{
			lock (Lock)
			{
				_dictionary[shootableEntity.Id] = shootableEntity;
			}

			return Unit.Task;
		}

		public Task<Guid> SaveAsync(IShootableEntity moveable)
		{
			lock (Lock)
			{
				_dictionary.Add(moveable.Id, moveable);
			}

			return Task.FromResult(moveable.Id);
		}
	}
}