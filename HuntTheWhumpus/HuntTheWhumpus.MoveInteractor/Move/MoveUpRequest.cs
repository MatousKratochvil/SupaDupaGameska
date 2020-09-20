using System;
using HuntTheWhumpus.Interactor.Abstraction;
using MediatR;

namespace HuntTheWhumpus.Interactor.Move
{
	class MoveUpRequest : MoveRequest, IRequest
	{
		public MoveUpRequest(Guid moveableId) : base(moveableId)
		{
		}
	}
}