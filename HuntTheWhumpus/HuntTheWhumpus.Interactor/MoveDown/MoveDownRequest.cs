using System;
using HuntTheWhumpus.Common;
using HuntTheWhumpus.Interactor.Abstraction;

namespace HuntTheWhumpus.Interactor.MoveDown
{
    public class MoveDownRequest : DirectionRequest
    {
        public MoveDownRequest(Guid moveableId) : base(moveableId)
        {
        }

        internal override Direction Direction { get; } = Direction.Down;
    }
}