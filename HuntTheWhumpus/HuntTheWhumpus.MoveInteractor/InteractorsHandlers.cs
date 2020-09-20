using System;
using System.Threading;
using System.Threading.Tasks;
using HuntTheWhumpus.Entities.Interfaces;
using HuntTheWhumpus.Interactor.Abstraction;
using HuntTheWhumpus.Interactor.Interfaces;
using HuntTheWhumpus.Interactor.Move;
using MediatR;

namespace HuntTheWhumpus.Interactor
{
	class InteractorsHandlers :
		IRequestHandler<MoveUpRequest>,
		IRequestHandler<MoveDownRequest>,
		IRequestHandler<MoveLeftRequest>,
		IRequestHandler<MoveRightRequest>
	{
		readonly IMoveableStore _moveableStore;
		readonly IMovePresenter _movePresenter;

		public InteractorsHandlers(IMoveableStore moveableStore, IMovePresenter movePresenter)
		{
			_moveableStore = moveableStore ?? throw new ArgumentNullException(nameof(moveableStore));
			_movePresenter = movePresenter ?? throw new ArgumentNullException(nameof(movePresenter));
		}

		public async Task<Unit> Handle(MoveDownRequest request, CancellationToken cancellationToken)
			=> await MoveHandleAsync(request, x => x.MoveDown());

		public async Task<Unit> Handle(MoveLeftRequest request, CancellationToken cancellationToken)
			=> await MoveHandleAsync(request, x => x.MoveLeft());

		public async Task<Unit> Handle(MoveRightRequest request, CancellationToken cancellationToken)
			=> await MoveHandleAsync(request, x => x.MoveRight());

		public async Task<Unit> Handle(MoveUpRequest request, CancellationToken cancellationToken)
			=> await MoveHandleAsync(request, x => x.MoveUp());

		async Task<Unit> MoveHandleAsync(MoveRequest request, Action<IMoveableEntity> requestAction)
		{
			var moveable = await _moveableStore.FindAsync(request.MoveableId).ConfigureAwait(false);

			requestAction.Invoke(moveable);

			await _moveableStore.UpdateAsync(moveable).ConfigureAwait(false);
			await _movePresenter.PresentAsync(moveable).ConfigureAwait(false);

			return Unit.Value;
		}
	}
}