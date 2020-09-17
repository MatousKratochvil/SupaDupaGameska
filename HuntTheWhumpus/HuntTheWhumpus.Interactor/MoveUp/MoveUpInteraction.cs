using System;
using HuntTheWhumpus.Abstraction.Interfaces;

namespace HuntTheWhumpus.Interactor.MoveUp
{
    public class MoveUpInteraction : IInteraction<MoveUpRequest>
    {
        readonly IMoveableStore _moveableStore;
        readonly IPresenter _presenter;

        public MoveUpInteraction(IMoveableStore moveableStore, IPresenter presenter)
        {
            _moveableStore = moveableStore ?? throw new ArgumentNullException(nameof(moveableStore));
            _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        }

        public void Execute(MoveUpRequest interactorRequest)
        {
            var movable = _moveableStore.Find(interactorRequest.MoveableId);

            movable.MoveUp();

            _moveableStore.Save(interactorRequest.MoveableId, movable);

            _presenter.Present(movable);
        }
    }
}