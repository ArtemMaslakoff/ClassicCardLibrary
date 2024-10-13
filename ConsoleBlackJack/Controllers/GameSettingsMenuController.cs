using ConsoleBlackJack.Core;
using ConsoleBlackJack.View;

namespace ConsoleBlackJack.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public static class GameSettingsMenuController
    {
        /// <summary>
        /// 
        /// </summary>
        private static GameSettings timeGameSettings = BlackJackGame.GameSettings.Clone();

        /// <summary>
        /// 
        /// </summary>
        public static void Start()
        {
            timeGameSettings = BlackJackGame.GameSettings.Clone();
            GameSettingsMenuView.Draw(timeGameSettings);

            ConsoleKey consoleKey = ConsoleKey.None;
            //int mouseXPosition = 0;
            //int mouseYPosition = 0;
            bool needUpdatePage = false;
            while (true)
            {
                consoleKey = Console.ReadKey().Key;
                //mouseXPosition = Console.GetCursorPosition().Left;
                //mouseYPosition = Console.GetCursorPosition().Top;
                
                if (consoleKey == ConsoleKey.UpArrow) // Увеличение начального количества денег игрока
                {
                    timeGameSettings.SetStartPlayerMoney(timeGameSettings.StartPlayerMoney + 50);
                    needUpdatePage = true;
                }
                else if (consoleKey == ConsoleKey.DownArrow) // Уменьшение начального количества денег игрока
                {
                    timeGameSettings.SetStartPlayerMoney(timeGameSettings.StartPlayerMoney - 50);
                    needUpdatePage = true;
                }
                else if (consoleKey == ConsoleKey.RightArrow) // Увеличение количества колод в игре
                {
                    timeGameSettings.SetNumberOfDecks(timeGameSettings.NumberOfDecks + 1);
                    needUpdatePage = true;
                }
                else if (consoleKey == ConsoleKey.LeftArrow) // Уменьшение количества колод в игре
                {
                    timeGameSettings.SetNumberOfDecks(timeGameSettings.NumberOfDecks - 1);
                    needUpdatePage = true;
                }
                else if (consoleKey == ConsoleKey.S)
                {
                    Console.Write("\b \b");
                    BlackJackGame.SetGameSettings(timeGameSettings);
                }
                else if (consoleKey == ConsoleKey.Q)
                {
                    return;
                }

                if (needUpdatePage)
                {
                    GameSettingsMenuView.Update(timeGameSettings);
                    needUpdatePage = false;
                }
            }
        }
    }
}
