using System;
using System.Threading;
using System.Threading.Tasks;
using HuntTheWhumpus.Entities.Interfaces;
using HuntTheWhumpus.ShootInteractor.Abstraction;
using HuntTheWhumpus.ShootInteractor.Interfaces;
using HuntTheWhumpus.ShootInteractor.Shoot;
using MediatR;

namespace HuntTheWhumpus.ShootInteractor
{
	public class InteractorsHandlers :
		IRequestHandler<ShootUpRequest>,
		IRequestHandler<ShootDownRequest>,
		IRequestHandler<ShootLeftRequest>,
		IRequestHandler<ShootRightRequest>
	{
		readonly IShootableStore _shootableStore;
		readonly IShootPresenter _shootPresenter;

		public InteractorsHandlers(IShootableStore shootableStore, IShootPresenter shootPresenter)
		{
			_shootableStore = shootableStore ?? throw new ArgumentNullException(nameof(shootableStore));
			_shootPresenter = shootPresenter ?? throw new ArgumentNullException(nameof(shootPresenter));
		}

		public Task<Unit> Handle(ShootUpRequest request, CancellationToken cancellationToken)
			=> ShootHandleAsync(request, x => x.ShootUp());

		public Task<Unit> Handle(ShootDownRequest request, CancellationToken cancellationToken)
			=> ShootHandleAsync(request, x => x.ShootDown());

		public Task<Unit> Handle(ShootLeftRequest request, CancellationToken cancellationToken)
			=> ShootHandleAsync(request, x => x.ShootLeft());

		public Task<Unit> Handle(ShootRightRequest request, CancellationToken cancellationToken)
			=> ShootHandleAsync(request, x => x.ShootRight());
		
		async Task<Unit> ShootHandleAsync(ShootRequest request, Action<IShootableEntity> requestAction)
		{
			var shootable = await _shootableStore.FindAsync(request.ShootableId).ConfigureAwait(false);

			requestAction.Invoke(shootable);

			await _shootableStore.UpdateAsync(shootable).ConfigureAwait(false);
			await _shootPresenter.PresentAsync(shootable).ConfigureAwait(false);

			return Unit.Value;
		}
	}
}