using System;
using HuntTheWhumpus.Interactor.Abstraction;
using MediatR;

namespace HuntTheWhumpus.Interactor.Move
{
	class MoveUpRequest : DirectionRequest, IRequest
	{
		public MoveUpRequest(Guid moveableId) : base(moveableId)
		{
		}
	}
}