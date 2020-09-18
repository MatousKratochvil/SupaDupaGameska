using System;
using HuntTheWhumpus.Interactor.Abstraction;
using MediatR;

namespace HuntTheWhumpus.Interactor.Move
{
	class MoveLeftRequest : DirectionRequest, IRequest
	{
		public MoveLeftRequest(Guid moveableId) : base(moveableId)
		{
		}
	}
}