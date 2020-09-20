using System;
using HuntTheWhumpus.Interactor.Abstraction;
using MediatR;

namespace HuntTheWhumpus.Interactor.Move
{
	class MoveLeftRequest : MoveRequest, IRequest
	{
		public MoveLeftRequest(Guid moveableId) : base(moveableId)
		{
		}
	}
}