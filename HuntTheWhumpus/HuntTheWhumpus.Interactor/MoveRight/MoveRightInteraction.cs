using System;
using HuntTheWhumpus.Abstraction.Interfaces;

namespace HuntTheWhumpus.Interactor.MoveRight
{
    public class MoveRightInteraction : IInteraction<MoveRightRequest>
    {
        readonly IMoveableStore _moveableStore;
        readonly IPresenter _presenter;

        public MoveRightInteraction(IMoveableStore moveableStore, IPresenter presenter)
        {
            _moveableStore = moveableStore ?? throw new ArgumentNullException(nameof(moveableStore));
            _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        }

        public void Execute(MoveRightRequest interactorRequest)
        {
            var movable = _moveableStore.Find(interactorRequest.MoveableId);

            movable.MoveRight();

            _moveableStore.Save(interactorRequest.MoveableId, movable);

            _presenter.Present(movable);
        }
    }
}