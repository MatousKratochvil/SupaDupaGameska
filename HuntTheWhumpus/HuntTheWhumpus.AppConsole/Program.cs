using System;
using HuntTheWhumpus.Interactor;

namespace HuntTheWhumpus.AppConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            var moveableStore = new MoveableStore();
            moveableStore.Save(Guid.Empty, new Player(1, 1));

            var readLine = string.Empty;
            while (!readLine.ToUpperInvariant().Equals("EXIT"))
            {
                Console.Clear();

                try
                {
                    CommandProcessor(readLine, moveableStore);
                }
                catch (ArgumentNullException)
                {
                    /* Ok to pass */
                }

                WriteCommandHelp();
                WriteExitHelp();
                readLine = Guard.StringRemainEmpty(Console.ReadLine());
            }

            Console.WriteLine("Konec");
        }

        static void WriteExitHelp()
        {
            Console.WriteLine("Pro konec napiš 'exit'");
        }

        static void WriteCommandHelp()
        {
            Console.WriteLine("Napiš příkaz");
            Console.WriteLine("up: pro pohyb nahoru");
            Console.WriteLine("down: pro pohyb dolu");
            Console.WriteLine("left: pro pohyb doleva");
            Console.WriteLine("right: pro pohyb doprava");
        }

        static void CommandProcessor(string readLine, MoveableStore moveableStore)
        {
            Guard.StringNull(readLine);

            var interactor = new MoveInteractor();
            var presenter = new Presenter();

            MoveCommandProcess(readLine, moveableStore, interactor, presenter);
        }

        static void MoveCommandProcess(string readLine, MoveableStore moveableStore, MoveInteractor interactor,
            Presenter presenter)
        {
            Guard.Command(readLine, "UP", () => interactor.MoveUp(Guid.Empty, moveableStore, presenter));
            Guard.Command(readLine, "DOWN", () => interactor.MoveDown(Guid.Empty, moveableStore, presenter));
            Guard.Command(readLine, "LEFT", () => interactor.MoveLeft(Guid.Empty, moveableStore, presenter));
            Guard.Command(readLine, "RIGHT", () => interactor.MoveRight(Guid.Empty, moveableStore, presenter));
        }
    }

    static class Guard
    {
        public static void StringNull(string readLine)
        {
            if (string.IsNullOrWhiteSpace(readLine))
                throw new ArgumentNullException(nameof(readLine));
        }

        public static void Command(string readLine, string type, Action action)
        {
            if (readLine.ToUpperInvariant().Equals(type))
                action.Invoke();
        }

        public static string StringRemainEmpty(string readLine) => readLine ?? string.Empty;
    }
}