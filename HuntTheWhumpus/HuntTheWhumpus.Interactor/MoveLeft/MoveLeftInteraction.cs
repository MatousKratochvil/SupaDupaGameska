using System;
using HuntTheWhumpus.Abstraction.Interfaces;

namespace HuntTheWhumpus.Interactor.MoveLeft
{
    public class MoveLeftInteraction : IInteraction<MoveLeftRequest>
    {
        readonly IMoveableStore _moveableStore;
        readonly IPresenter _presenter;

        public MoveLeftInteraction(IMoveableStore moveableStore, IPresenter presenter)
        {
            _moveableStore = moveableStore ?? throw new ArgumentNullException(nameof(moveableStore));
            _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        }

        public void Execute(MoveLeftRequest interactorRequest)
        {
            var movable = _moveableStore.Find(interactorRequest.MoveableId);

            movable.MoveLeft();

            _moveableStore.Save(interactorRequest.MoveableId, movable);

            _presenter.Present(movable);
        }
    }
}