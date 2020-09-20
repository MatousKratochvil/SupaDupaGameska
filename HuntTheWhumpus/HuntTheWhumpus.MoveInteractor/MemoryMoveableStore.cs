using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HuntTheWhumpus.Entities;
using HuntTheWhumpus.Entities.Interfaces;
using HuntTheWhumpus.Interactor.Interfaces;
using MediatR;

namespace HuntTheWhumpus.Interactor
{
	class MemoryMoveableStore : IMoveableStore
	{
		static readonly object Lock = new object();

		readonly Dictionary<Guid, IMoveableEntity> _dictionary = new Dictionary<Guid, IMoveableEntity> {{Guid.Empty, new Player()}};

		public Task<IMoveableEntity> FindAsync(Guid id)
		{
			IMoveableEntity moveableEntity = null;
			lock (Lock)
			{
				moveableEntity = _dictionary[id];
			}

			return Task.FromResult(moveableEntity);
		}

		public Task<Unit> UpdateAsync(IMoveableEntity moveableEntity)
		{
			lock (Lock)
			{
				_dictionary[moveableEntity.Id] = moveableEntity;
			}

			return Unit.Task;
		}

		public Task<Guid> SaveAsync(IMoveableEntity moveableEntity)
		{
			lock (Lock)
			{
				_dictionary.Add(moveableEntity.Id, moveableEntity);
			}

			return Task.FromResult(moveableEntity.Id);
		}
	}
}