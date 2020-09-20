using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HuntTheWhumpus.Entities.Interfaces;
using HuntTheWhumpus.Entities.Player;
using HuntTheWhumpus.ShootInteractor.Interfaces;
using MediatR;

namespace HuntTheWhumpus.ShootInteractor
{
	class MemoryShootableStore : IShootableStore
	{
		static readonly object Lock = new object();

		readonly Dictionary<Guid, IShootable> _dictionary = new Dictionary<Guid, IShootable> {{Guid.Empty, new Player()}};

		public Task<IShootable> FindAsync(Guid id)
		{
			IShootable moveable = null;
			lock (Lock)
			{
				moveable = _dictionary[id];
			}

			return Task.FromResult(moveable);
		}

		public Task<Unit> UpdateAsync(IShootable shootable)
		{
			lock (Lock)
			{
				_dictionary[shootable.Id] = shootable;
			}

			return Unit.Task;
		}

		public Task<Guid> SaveAsync(IShootable moveable)
		{
			lock (Lock)
			{
				_dictionary.Add(moveable.Id, moveable);
			}

			return Task.FromResult(moveable.Id);
		}
	}
}