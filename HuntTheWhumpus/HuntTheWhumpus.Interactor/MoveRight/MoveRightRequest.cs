using System;
using HuntTheWhumpus.Common;
using HuntTheWhumpus.Interactor.Abstraction;

namespace HuntTheWhumpus.Interactor.MoveRight
{
    public class MoveRightRequest : DirectionRequest
    {
        public MoveRightRequest(Guid moveableId) : base(moveableId)
        {
        }

        internal override Direction Direction { get; } = Direction.Right;
    }
}