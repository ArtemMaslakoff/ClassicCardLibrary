using ClassicCardLibrary.Core.Cards;
using ConsoleBlackJack.Core;
using ConsoleBlackJack.View;
using ConsoleBlackJack.Views;

namespace ConsoleBlackJack.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public static class GameController
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Start()
        {
            GameView.Draw();

            ConsoleKey consoleKey = ConsoleKey.None;
            bool needUpdatePage = false;
            while (true)
            {
                consoleKey = Console.ReadKey().Key;

                if (consoleKey == ConsoleKey.C)
                {
                    BlackJackController.Player.GiveCard(0, new Card(CardSuit.DIAMONDS, CardValue.EIGHT));
                    needUpdatePage = true;
                }
                else if (consoleKey == ConsoleKey.Q)
                {
                    return;
                }

                if (needUpdatePage)
                {
                    GameView.Update();
                    needUpdatePage = false;
                }
            }
        }
    }
}
