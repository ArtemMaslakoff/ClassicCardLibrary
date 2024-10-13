using ConsoleBlackJack.Core;

namespace ConsoleBlackJack.Views
{
    /// <summary>
    /// Основная страница игры
    /// </summary>
    public static class GameView
    {
        /// <summary>
        /// Отрисовать страницу игры
        /// </summary>
        public static void Draw()
        {
            DrawBorder();
            DrawMoney();
            DrawNumberOfDecks();
            DrawPlayerArms();

            Console.SetCursorPosition(0, 19);
        }

        /// <summary>
        /// Обновить данные на странице
        /// </summary>
        public static void Update()
        {
            DrawMoney();
            DrawNumberOfDecks();
            DrawPlayerArms();

            Console.SetCursorPosition(0, 19);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DrawBorder()
        {
            Console.Clear();

            Console.WriteLine("╔══════════╦═══════════════════════════════════════════════════════╦═══╗");
            Console.WriteLine("║          ║                                                       ║   ║");
            Console.WriteLine("╠══════════╝                                                       ╚═══╣");
            Console.WriteLine("║ Hands:                                                               ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("╠══════════╗                                                           ║");
            Console.WriteLine("║ Exit (Q) ║                                                           ║");
            Console.WriteLine("╚══════════╩═══════════════════════════════════════════════════════════╝");
        }

        public static void DrawBetWindow(int bet)
        {
            if (bet < 0) bet = 0;
            if (bet > Player.Money) bet = Player.Money;
            Console.SetCursorPosition(36, 9);
            Console.Write("╔══════════╗");

            Console.SetCursorPosition(36, 10);
            Console.Write("║ " + bet.ToString().PadLeft(8, '0') + " ║");

            Console.SetCursorPosition(36, 11);
            Console.Write("╚══════════╝");
        }

        /// <summary>
        /// Отрисовать количество денег игрока
        /// </summary>
        private static void DrawMoney()
        {
            Console.SetCursorPosition(2, 1);
            int moneyForDraw = Player.Money;
            if (moneyForDraw > 99999999) moneyForDraw = 99999999;
            Console.Write(moneyForDraw.ToString().PadLeft(8, '0'));
        }

        /// <summary>
        /// Отрисовать количество колод в игре
        /// </summary>
        private static void DrawNumberOfDecks()
        {
            Console.SetCursorPosition(69, 1);
            int numberOfDecks = BlackJackGame.GameSettings.NumberOfDecks;
            if (numberOfDecks < 1) numberOfDecks = 1;
            if (numberOfDecks > 8) numberOfDecks = 8;
            Console.Write(numberOfDecks.ToString());
        }

        /// <summary>
        /// Отрисовка карт в руке игрока
        /// </summary>
        private static void DrawPlayerArms()
        {
            Console.SetCursorPosition(1, 4);
            foreach (var arm in Player.Arms)
            {
                Console.Write("╔" + new string('═', arm.Value.Count * 4) + "╗" + BlackJackGame.PlayerBet.ToString());
                Console.SetCursorPosition(1, 6);
                Console.Write("╚" + new string('═', arm.Value.Count * 4) + "╝");
            }
        }
    }
}
//   ╔ ╦ ╗
//
//   ╠ ╬ ╣ ║ ═
//
//   ╚ ╩ ╝
