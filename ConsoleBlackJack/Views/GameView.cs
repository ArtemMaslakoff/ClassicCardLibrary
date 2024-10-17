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

            Console.SetCursorPosition(0, 19);
        }

        /// <summary>
        /// Обновить данные на странице
        /// </summary>
        public static void Update()
        {
            DrawMoney();
            DrawNumberOfDecks();

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
            Console.WriteLine("║ Hands:                                                      Dealler: ║");
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
            Console.WriteLine("╠══════════╦═══════════════════════════════════════════════════════════╣");
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
        public static void DrawMoney()
        {
            Console.SetCursorPosition(2, 1);
            int moneyForDraw = Player.Money;
            if (moneyForDraw > 99999999) moneyForDraw = 99999999;
            Console.Write(moneyForDraw.ToString().PadLeft(8, '0'));
        }

        /// <summary>
        /// Отрисовать количество колод в игре
        /// </summary>
        public static void DrawNumberOfDecks()
        {
            Console.SetCursorPosition(69, 1);
            int numberOfDecks = BlackJackGame.GameSettings.NumberOfDecks;
            if (numberOfDecks < 1) numberOfDecks = 1;
            if (numberOfDecks > 8) numberOfDecks = 8;
            Console.Write(numberOfDecks.ToString());
        }

        /// <summary>
        /// Отрисовка карт в основной руке игрока
        /// </summary>
        public static void DrawPlayerArm()
        {
            Console.SetCursorPosition(1, 4);
            Console.Write("╔═" + new string('═', Player.Arm.Count * 4) + "═╗" + BlackJackGame.PlayerArmBet.ToString());
            Console.SetCursorPosition(1, 5);
            Console.Write("║ ");
            for (int j = 0; j < Player.Arm.Count; j++)
            {
                Console.Write(ConsoleCardDrawer.CardToString(Player.Arm.Cards[j]));
            }
            Console.Write(" ║");
            Console.SetCursorPosition(1, 6);
            Console.Write("╚═" + new string('═', Player.Arm.Count * 4) + "═╝" + BlackJackGame.GetPlayerArmSum());
        }

        /// <summary>
        /// Отрисовка карт в сплитованной руке игрока
        /// </summary>
        public static void DrawPlayerSplitArm()
        {
            Console.SetCursorPosition(1, 8);
            Console.Write("╔═" + new string('═', Player.SplitArm.Count * 4) + "═╗" + BlackJackGame.PlayerSplitArmBet.ToString());
            Console.SetCursorPosition(1, 9);
            Console.Write("║ ");
            for (int j = 0; j < Player.SplitArm.Count; j++)
            {
                Console.Write(ConsoleCardDrawer.CardToString(Player.SplitArm.Cards[j]));
            }
            Console.Write(" ║");
            Console.SetCursorPosition(1, 10);
            Console.Write("╚═" + new string('═', Player.SplitArm.Count * 4) + "═╝" + BlackJackGame.GetPlayerSplitArmSum());
        }

        /// <summary>
        /// Отрисовка карт диллера
        /// </summary>
        public static void DrawDeallerArm()
        {
            Console.SetCursorPosition(50, 4);
            Console.Write("╔═" + new string('═', BlackJackGame.DeallerCards.Count * 4) + "═╗");
            Console.SetCursorPosition(50, 5);
            Console.Write("║ ");
            for (int j = 0; j < BlackJackGame.DeallerCards.Count; j++)
            {
                Console.Write(ConsoleCardDrawer.CardToString(BlackJackGame.DeallerCards[j]));
            }
            Console.Write(" ║");
            Console.SetCursorPosition(50, 6);
            Console.Write("╚═" + new string('═', BlackJackGame.DeallerCards.Count * 4) + "═╝");
        }

        public static void DrawBETControl()
        {
            Console.SetCursorPosition(13, 17);
            Console.Write("+Bet (Arrow Up)       -Bet (Arrow Down)       Sve Bet (B)");
        }
        public static void DrawSPLITControl()
        {
            Console.SetCursorPosition(13, 17);
            Console.Write("Split (Arrow Up)                      Cansel (Arrow Down)");
        }
        //public static void DrawSPLIT_BETControl()
        //{
        //    Console.SetCursorPosition(13, 17);
        //    Console.Write("+Split Bet (Arrow Up) -Split Bet (Arrow Down) Sve Bet (B)");
        //}
        public static void DrawSTEPControl()
        {
            Console.SetCursorPosition(13, 17);
            Console.Write("Add Card (Arrow Up)                   Cansel (Arrow Down)");
        }
    }
}
//   ╔ ╦ ╗
//
//   ╠ ╬ ╣ ║ ═ ✔ X ♛
//
//   ╚ ╩ ╝
