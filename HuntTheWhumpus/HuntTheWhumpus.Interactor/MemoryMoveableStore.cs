using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HuntTheWhumpus.Entities.Interfaces;
using HuntTheWhumpus.Entities.Player;
using HuntTheWhumpus.Interactor.Interfaces;
using MediatR;

namespace HuntTheWhumpus.Interactor
{
	class MemoryMoveableStore : IMoveableStore
	{
		static readonly object @lock = new object();

		readonly Dictionary<Guid, IMoveable> _dictionary = new Dictionary<Guid, IMoveable> {{Guid.Empty, new Player()}};

		public Task<IMoveable> FindAsync(Guid id)
		{
			IMoveable moveable = null;
			lock (@lock)
			{
				moveable = _dictionary[id];
			}

			return Task.FromResult(moveable);
		}

		public Task<Unit> UpdateAsync(IMoveable moveable)
		{
			lock (@lock)
			{
				_dictionary[moveable.Id] = moveable;
			}

			return Unit.Task;
		}

		public Task<Guid> SaveAsync(IMoveable moveable)
		{
			lock (@lock)
			{
				_dictionary.Add(moveable.Id, moveable);
			}

			return Task.FromResult(moveable.Id);
		}
	}
}