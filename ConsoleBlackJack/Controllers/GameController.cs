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
            BlackJackGame.StartNewGame();
            BlackJackGame.NextStep();
            GameView.Draw();

            ConsoleKey consoleKey = ConsoleKey.None;
            bool needUpdatePage = false;
            while (true)
            {
                if (BlackJackGame.GameStage == GameStage.GAME_START)
                {
                    BlackJackGame.StartNewGame();
                    BlackJackGame.NextStep();
                }
                if (BlackJackGame.GameStage == GameStage.BET)
                {
                    GameView.DrawBetWindow(timePlayerBet);
                    GameView.DrawBETControl();

                    consoleKey = Console.ReadKey().Key;

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
                        BlackJackGame.NextStep();

                        GameView.Draw();
                    }

                    if (consoleKey == ConsoleKey.Q) return;

                    if (needToUpdateBetWindow)
                    {
                        GameView.DrawBetWindow(timePlayerBet);
                    }
                }
                if (BlackJackGame.GameStage == GameStage.PLAYER_GIVE_START_CARDS)
                {
                    BlackJackGame.GiveCardToPlayer(0);
                    BlackJackGame.GiveCardToPlayer(0);
                    BlackJackGame.NextStep();

                    GameView.Update();
                    GameView.DrawPlayerArms();
                }
                if (BlackJackGame.GameStage == GameStage.DILLER_GIVE_START_CARDS)
                {
                    BlackJackGame.GiveCardToDealler();
                    BlackJackGame.GiveCardToDealler();
                    BlackJackGame.NextStep();

                    GameView.Update();
                    GameView.DrawDeallerArm();
                }
                if (BlackJackGame.GameStage == GameStage.SPLIT)
                {
                    GameView.DrawSPLITControl();

                    consoleKey = Console.ReadKey().Key;

                    if (consoleKey == ConsoleKey.Q) return;
                }
                if (BlackJackGame.GameStage == GameStage.SPLIT_BET)
                {
                    GameView.DrawSPLIT_BETControl();

                    consoleKey = Console.ReadKey().Key;

                    if (consoleKey == ConsoleKey.Q) return;
                }
                if (BlackJackGame.GameStage == GameStage.STEP)
                {
                    GameView.DrawSTEPControl();
                    consoleKey = Console.ReadKey().Key;

                    if (consoleKey == ConsoleKey.Q) return;
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
