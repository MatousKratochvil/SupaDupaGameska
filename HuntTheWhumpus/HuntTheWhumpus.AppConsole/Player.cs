using HuntTheWhumpus.Abstraction.Interfaces;

namespace HuntTheWhumpus.AppConsole
{
    public class Player : IMoveable
    {
        int X;
        int Y;

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void MoveDown()
        {
            Y -= 1;
        }

        public void MoveLeft()
        {
            X -= 1;
        }

        public void MoveRight()
        {
            X += 1;
        }

        public void MoveUp()
        {
            Y += 1;
        }

        public override string ToString() => $"X:{X}, Y:{Y}";
    }
}