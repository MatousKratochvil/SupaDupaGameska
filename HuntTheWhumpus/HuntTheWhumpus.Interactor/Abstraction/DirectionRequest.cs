using System;
using HuntTheWhumpus.Abstraction.Interfaces;
using HuntTheWhumpus.Common;

namespace HuntTheWhumpus.Interactor.Abstraction
{
    public abstract class DirectionRequest : IInteractorRequest
    {
        protected DirectionRequest(Guid moveableId)
        {
            MoveableId = moveableId;
        }

        internal abstract Direction Direction { get; }
        internal Guid MoveableId { get; }
    }
}