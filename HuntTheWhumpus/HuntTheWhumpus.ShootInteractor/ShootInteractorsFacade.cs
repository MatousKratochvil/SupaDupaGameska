using System;
using System.Threading.Tasks;
using HuntTheWhumpus.ShootInteractor.Shoot;
using MediatR;

namespace HuntTheWhumpus.ShootInteractor
{
	public class ShootInteractorsFacade
	{		
		readonly IMediator _mediator;

		public ShootInteractorsFacade(IMediator mediator)
		{
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		public Task<Unit> ShootUp(Guid id) => _mediator.Send(new ShootUpRequest(id));
		public Task<Unit> ShootDown(Guid id) => _mediator.Send(new ShootDownRequest(id));
		public Task<Unit> ShootLeft(Guid id) => _mediator.Send(new ShootLeftRequest(id));
		public Task<Unit> ShootRight(Guid id) => _mediator.Send(new ShootRightRequest(id));
		
	}
}