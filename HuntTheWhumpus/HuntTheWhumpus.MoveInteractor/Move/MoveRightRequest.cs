using System;
using HuntTheWhumpus.Interactor.Abstraction;
using MediatR;

namespace HuntTheWhumpus.Interactor.Move
{
	class MoveRightRequest : MoveRequest, IRequest
	{
		public MoveRightRequest(Guid moveableId) : base(moveableId)
		{
		}
	}
}