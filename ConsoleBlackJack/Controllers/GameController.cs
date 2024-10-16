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
        private static int timePlayerBet = 0;

        /// <summary>
        /// 
        /// </summary>
        public static void Start()
        {
            GameView.Draw();
            BlackJackGame.StartNewGame();

            ConsoleKey consoleKey = ConsoleKey.None;
            bool needUpdatePage = false;
            while (true)
            {
                consoleKey = Console.ReadKey().Key;

                if (BlackJackGame.GameStage == GameStage.GAME_START)
                {
                    BlackJackGame.StartNewGame();
                    BlackJackGame.NextStep();
                }
                if (BlackJackGame.GameStage == GameStage.BET)
                {
                    GameView.DrawBetWindow(timePlayerBet);

                    bool needToUpdateBetWindow = false;
                    if (consoleKey == ConsoleKey.UpArrow)
                    {
                        timePlayerBet += 10;
                        if (timePlayerBet > Player.Money) timePlayerBet = Player.Money;
                        needToUpdateBetWindow = true;
                    }
                    else if (consoleKey == ConsoleKey.DownArrow)
                    {
                        timePlayerBet -= 10;
                        if (timePlayerBet < 0) timePlayerBet = 0;
                        needToUpdateBetWindow = true;
                    }
                    else if (consoleKey == ConsoleKey.B)
                    {
                        BlackJackGame.SetPlayerBet(timePlayerBet);
                        BlackJackGame.SetGameStage(GameStage.STEP);
                        GameView.Draw();
                    }

                    if (needToUpdateBetWindow)
                    {
                        GameView.DrawBetWindow(timePlayerBet);
                    }
                }

                if (consoleKey == ConsoleKey.Q)
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
