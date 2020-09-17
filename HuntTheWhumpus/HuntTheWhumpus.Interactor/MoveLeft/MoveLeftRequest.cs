using System;
using HuntTheWhumpus.Common;
using HuntTheWhumpus.Interactor.Abstraction;

namespace HuntTheWhumpus.Interactor.MoveLeft
{
    public class MoveLeftRequest : DirectionRequest
    {
        public MoveLeftRequest(Guid moveableId) : base(moveableId)
        {
        }

        internal override Direction Direction { get; } = Direction.Left;
    }
}