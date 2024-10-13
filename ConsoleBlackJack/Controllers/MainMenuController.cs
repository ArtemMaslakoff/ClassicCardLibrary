using ConsoleBlackJack.Core;
using ConsoleBlackJack.View;

namespace ConsoleBlackJack.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public static class MainMenuController
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Start()
        {
            MainMenuView.Draw();
            ConsoleKey consoleKey = ConsoleKey.None;
            bool fromOtherPage = false;
            while (true)
            {
                consoleKey = Console.ReadKey().Key;
                if (consoleKey == ConsoleKey.G)
                {
                    BlackJackController.NewPlayer();
                    BlackJackController.Player.GiveMoney(BlackJackController.GameSettings.StartPlayerMoney);

                    GameController.Start();
                    fromOtherPage = true;
                }
                else if (consoleKey == ConsoleKey.S)
                {
                    GameSettingsMenuController.Start();
                    fromOtherPage = true;
                }
                else if (consoleKey == ConsoleKey.Q)
                {
                    return;
                }

                if (fromOtherPage)
                {
                    MainMenuView.Draw();
                    fromOtherPage = false;
                }
            }
        }
    }
}
