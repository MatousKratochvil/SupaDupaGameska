using System;
using System.Threading;
using System.Threading.Tasks;
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
		readonly IPresenter _presenter;

		public InteractorsHandlers(IMoveableStore moveableStore, IPresenter presenter)
		{
			_moveableStore = moveableStore ?? throw new ArgumentNullException(nameof(moveableStore));
			_presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
		}

		public async Task<Unit> Handle(MoveDownRequest request, CancellationToken cancellationToken)
			=> await MoveHandleAsync(request, x => x.MoveDown());

		public async Task<Unit> Handle(MoveLeftRequest request, CancellationToken cancellationToken)
			=> await MoveHandleAsync(request, x => x.MoveLeft());

		public async Task<Unit> Handle(MoveRightRequest request, CancellationToken cancellationToken)
			=> await MoveHandleAsync(request, x => x.MoveRight());

		public async Task<Unit> Handle(MoveUpRequest request, CancellationToken cancellationToken)
			=> await MoveHandleAsync(request, x => x.MoveUp());

		async Task<Unit> MoveHandleAsync(DirectionRequest request, Action<IMoveable> requestAction)
		{
			var moveable = await _moveableStore.FindAsync(request.MoveableId).ConfigureAwait(false);

			requestAction.Invoke(moveable);

			await _moveableStore.UpdateAsync(moveable).ConfigureAwait(false);
			await _presenter.PresentAsync(moveable).ConfigureAwait(false);

			return Unit.Value;
		}
	}
}