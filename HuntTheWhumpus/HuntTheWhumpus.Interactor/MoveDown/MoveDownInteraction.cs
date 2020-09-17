using System;
using HuntTheWhumpus.Abstraction.Interfaces;

namespace HuntTheWhumpus.Interactor.MoveDown
{
    public class MoveDownInteraction : IInteraction<MoveDownRequest>
    {
        readonly IMoveableStore _moveableStore;
        readonly IPresenter _presenter;

        public MoveDownInteraction(IMoveableStore moveableStore, IPresenter presenter)
        {
            _moveableStore = moveableStore ?? throw new ArgumentNullException(nameof(moveableStore));
            _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        }

        public void Execute(MoveDownRequest interactorRequest)
        {
            var movable = _moveableStore.Find(interactorRequest.MoveableId);

            movable.MoveDown();

            _moveableStore.Save(interactorRequest.MoveableId, movable);

            _presenter.Present(movable);
        }
    }
}