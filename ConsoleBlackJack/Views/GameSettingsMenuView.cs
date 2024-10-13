using ConsoleBlackJack.Core;

namespace ConsoleBlackJack.View
{
    /// <summary>
    /// Меню настроек игры
    /// </summary>
    public static class GameSettingsMenuView
    {
        /// <summary>
        /// Отрисовать страницу настроек игры
        /// </summary>
        public static void Draw(GameSettings gameSettings)
        {
            DrawBorder();
            DrawStartPlayerMoney(gameSettings.StartPlayerMoney);
            DrawNumberOfDecks(gameSettings.NumberOfDecks);

            Console.SetCursorPosition(0, 19);
        }

        /// <summary>
        /// Обновить данные на странице
        /// </summary>
        public static void Update(GameSettings gameSettings)
        {
            DrawStartPlayerMoney(gameSettings.StartPlayerMoney);
            DrawNumberOfDecks(gameSettings.NumberOfDecks);

            Console.SetCursorPosition(0, 19);
        }

        /// <summary>
        /// Отрисовать рамку страницы
        /// </summary>
        private static void DrawBorder()
        {
            Console.Clear();

            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                         ♥♣--- Settings ---♠♦                         ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                         ╔══════════╗ ║");
            Console.WriteLine("║ Start Player Money                                      ║          ║ ║");
            Console.WriteLine("║                                                         ╚══════════╝ ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                                ╔═══╗ ║");
            Console.WriteLine("║ Number of Decks in game                                        ║   ║ ║");
            Console.WriteLine("║                                                                ╚═══╝ ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("╠══════════╦════════════════════════════════════════════════╦══════════╣");
            Console.WriteLine("║ Exit (Q) ║                                                ║ Save (S) ║");
            Console.WriteLine("╚══════════╩════════════════════════════════════════════════╩══════════╝");
        }

        /// <summary>
        /// Отрисовать стартовое количество денег игрока
        /// </summary>
        private static void DrawStartPlayerMoney(int startPlayerMoney)
        {
            Console.SetCursorPosition(60, 6);
            if (startPlayerMoney > 99999999) startPlayerMoney = 99999999;
            Console.Write(startPlayerMoney.ToString().PadLeft(8, '0'));
        }

        /// <summary>
        /// Отрисовать количество колод в игре
        /// </summary>
        private static void DrawNumberOfDecks(int numberOfDecks)
        {
            Console.SetCursorPosition(67, 10);
            if (numberOfDecks < 1) numberOfDecks = 1;
            if (numberOfDecks > 8) numberOfDecks = 8;
            Console.Write(numberOfDecks.ToString());
        }
    }
}
//   ╔ ╦ ╗
//
//   ╠ ╬ ╣ ║ ═
//
//   ╚ ╩ ╝
