using System;
using HuntTheWhumpus.Interactor.Abstraction;
using MediatR;

namespace HuntTheWhumpus.Interactor.Move
{
	class MoveDownRequest : DirectionRequest, IRequest
	{
		public MoveDownRequest(Guid moveableId) : base(moveableId)
		{
		}
	}
}