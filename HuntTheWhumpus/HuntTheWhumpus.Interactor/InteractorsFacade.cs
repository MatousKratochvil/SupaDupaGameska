using System;
using System.Threading.Tasks;
using HuntTheWhumpus.Interactor.Move;
using MediatR;

namespace HuntTheWhumpus.Interactor
{
	public class InteractorsFacade
	{
		readonly IMediator _mediator;

		public InteractorsFacade(IMediator mediator)
		{
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		public Task<Unit> MoveUp(Guid id) => _mediator.Send(new MoveUpRequest(id));
		public Task<Unit> MoveDown(Guid id) => _mediator.Send(new MoveDownRequest(id));
		public Task<Unit> MoveLeft(Guid id) => _mediator.Send(new MoveLeftRequest(id));
		public Task<Unit> MoveRight(Guid id) => _mediator.Send(new MoveRightRequest(id));
	}
}