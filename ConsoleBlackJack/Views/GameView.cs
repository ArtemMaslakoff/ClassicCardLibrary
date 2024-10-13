using ClassicCardLibraryConsoleTest;
using ConsoleBlackJack.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            DrawPlayerCards();

            Console.SetCursorPosition(0, 18);
        }

        /// <summary>
        /// Обновить данные на странице
        /// </summary>
        public static void Update()
        {
            DrawMoney();
            DrawPlayerCards();

            Console.SetCursorPosition(0, 18);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DrawBorder()
        {
            Console.Clear();

            Console.WriteLine("╔══════════╦═════════════════════════════════════════════════╗");
            Console.WriteLine("║          ║                                                 ║");
            Console.WriteLine("╠══════════╝                                                 ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
        }

        /// <summary>
        /// Отрисовать количество денег игрока
        /// </summary>
        public static void DrawMoney()
        {
            Console.SetCursorPosition(2, 1);
            int moneyForDraw = BlackJackController.Player.Money;
            if (moneyForDraw > 99999999) moneyForDraw = 99999999;
            Console.Write(moneyForDraw.ToString().PadLeft(8, '0'));
        }

        /// <summary>
        /// Отрисовка карт в руке игрока
        /// </summary>
        public static void DrawPlayerCards()
        {
            Console.SetCursorPosition(8, 8);
            foreach (var card in BlackJackController.Player.Arms[0].Cards)
            {
                Console.Write(ConsoleCardDrawer.CardToString(card));
            }
        }
    }
}
//   ╔ ╦ ╗
//
//   ╠ ╬ ╣ ║ ═
//
//   ╚ ╩ ╝
