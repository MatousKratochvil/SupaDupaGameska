using System;
using HuntTheWhumpus.Abstraction.Interfaces;

namespace HuntTheWhumpus.AppConsole
{
    public class Presenter : IPresenter
    {
        public void Present(IMoveable movable)
        {
            Console.WriteLine($"Position : {movable} ");
        }
    }
}