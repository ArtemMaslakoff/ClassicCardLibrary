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

            Console.SetCursorPosition(0, 18);
        }

        /// <summary>
        /// Обновить данные на странице
        /// </summary>
        public static void Update(GameSettings gameSettings)
        {
            DrawStartPlayerMoney(gameSettings.StartPlayerMoney);

            Console.SetCursorPosition(0, 18);
        }

        /// <summary>
        /// Отрисовать рамку страницы
        /// </summary>
        private static void DrawBorder()
        {
            Console.Clear();

            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    ♥♣--- Settings ---♠♦                    ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                            ╔══════════╗    ║");
            Console.WriteLine("║ Start Player Money                         ║          ║    ║");
            Console.WriteLine("║                                            ╚══════════╝    ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("╠══════════╦══════════════════════════════════════╦══════════╣");
            Console.WriteLine("║ Exit (Q) ║                                      ║ Save (S) ║");
            Console.WriteLine("╚══════════╩══════════════════════════════════════╩══════════╝");
        }

        /// <summary>
        /// Отрисовать стартовое количество денег игрока
        /// </summary>
        private static void DrawStartPlayerMoney(int startPlayerMoney)
        {
            Console.SetCursorPosition(47, 5);
            if (startPlayerMoney > 99999999) startPlayerMoney = 99999999;
            Console.Write(startPlayerMoney.ToString().PadLeft(8, '0'));
        }
    }
}
//   ╔ ╦ ╗
//
//   ╠ ╬ ╣ ║ ═
//
//   ╚ ╩ ╝
