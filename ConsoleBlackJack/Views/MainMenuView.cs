namespace ConsoleBlackJack.View
{
    /// <summary>
    /// Главное меню игры
    /// </summary>
    public static class MainMenuView
    {
        public static void Draw()
        {
            Console.Clear();
            Console.SetCursorPosition(0,0);

            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                        ♥♣--- Black Jack ---♠♦                        ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ Press G for start game                                               ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ Press S for settings                                                 ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ Press Q for exit                                                     ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝");

            Console.SetCursorPosition(0, 19);
        }
    }
}
//   ╔ ╦ ╗
//
//   ╠ ╬ ╣ ║ ═
//
//   ╚ ╩ ╝