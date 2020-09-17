using System;
using System.Collections.Generic;
using HuntTheWhumpus.Abstraction.Interfaces;

namespace HuntTheWhumpus.AppConsole
{
    public class MoveableStore : IMoveableStore
    {
        readonly Dictionary<Guid, IMoveable> _memoryStore;

        public MoveableStore()
        {
            _memoryStore = new Dictionary<Guid, IMoveable>();
        }

        public IMoveable Find(Guid moveableId) => _memoryStore[moveableId];
        public void Save(Guid moveableId, IMoveable movable) => _memoryStore[moveableId] = movable;
    }
}