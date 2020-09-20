using System;
using HuntTheWhumpus.Interactor.Abstraction;
using MediatR;

namespace HuntTheWhumpus.Interactor.Move
{
	class MoveDownRequest : MoveRequest, IRequest
	{
		public MoveDownRequest(Guid moveableId) : base(moveableId)
		{
		}
	}
}