using System;

namespace HuntTheWhumpus.Abstraction.Interfaces
{
    public interface IMoveableStore
    {
        IMoveable Find(Guid moveableId);
        void Save(Guid moveableId, IMoveable movable);
    }
}