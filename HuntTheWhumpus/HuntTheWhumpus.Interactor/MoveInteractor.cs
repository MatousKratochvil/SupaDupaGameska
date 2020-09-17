using System;
using HuntTheWhumpus.Abstraction.Interfaces;
using HuntTheWhumpus.Interactor.MoveDown;
using HuntTheWhumpus.Interactor.MoveLeft;
using HuntTheWhumpus.Interactor.MoveRight;
using HuntTheWhumpus.Interactor.MoveUp;

namespace HuntTheWhumpus.Interactor
{
    public class MoveInteractor
    {
        public void MoveUp(Guid empty, IMoveableStore moveableStore, IPresenter presenter) =>
            new MoveUpInteraction(moveableStore, presenter).Execute(new MoveUpRequest(empty));

        public void MoveDown(Guid empty, IMoveableStore moveableStore, IPresenter presenter) =>
            new MoveDownInteraction(moveableStore, presenter).Execute(new MoveDownRequest(empty));

        public void MoveLeft(Guid empty, IMoveableStore moveableStore, IPresenter presenter) =>
            new MoveLeftInteraction(moveableStore, presenter).Execute(new MoveLeftRequest(empty));

        public void MoveRight(Guid empty, IMoveableStore moveableStore, IPresenter presenter) =>
            new MoveRightInteraction(moveableStore, presenter).Execute(new MoveRightRequest(empty));
    }
}