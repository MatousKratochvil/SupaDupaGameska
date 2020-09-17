using System;
using HuntTheWhumpus.Common;
using HuntTheWhumpus.Interactor.Abstraction;

namespace HuntTheWhumpus.Interactor.MoveUp
{
    public class MoveUpRequest : DirectionRequest
    {
        public MoveUpRequest(Guid moveableId) : base(moveableId)
        {
        }

        internal override Direction Direction { get; } = Direction.Up;
    }
}