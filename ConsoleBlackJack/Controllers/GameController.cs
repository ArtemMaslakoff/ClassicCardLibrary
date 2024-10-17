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
                    BlackJackGame.GiveCardToPlayerArm();
                    BlackJackGame.GiveCardToPlayerArm();
                    BlackJackGame.NextStep();

                    GameView.Update();
                    GameView.DrawPlayerArm();
                }
                if (BlackJackGame.GameStage == GameStage.DILLER_GIVE_START_CARDS)
                {
                    BlackJackGame.GiveCardToDealler();
                    BlackJackGame.GiveCardToDealler();
                    BlackJackGame.IsPossibleSplit = (Player.Arm.Cards[0].CardValue == Player.Arm.Cards[1].CardValue);
                    BlackJackGame.NextStep();

                    GameView.Update();
                    GameView.DrawDeallerArm();
                }
                if (BlackJackGame.GameStage == GameStage.SPLIT)
                {
                    GameView.DrawSPLITControl();

                    consoleKey = Console.ReadKey().Key;

                    if (consoleKey == ConsoleKey.UpArrow)
                    {
                        BlackJackGame.PlayerSplited = true;

                        BlackJackGame.SplitPlayerArm();
                        BlackJackGame.GiveCardToPlayerArm();
                        BlackJackGame.GiveCardToPlayerSplitArm();
                        BlackJackGame.NextStep();

                        GameView.Update();
                        GameView.DrawPlayerArm();
                        GameView.DrawPlayerSplitArm();
                    }
                    else if (consoleKey == ConsoleKey.DownArrow)
                    {
                        BlackJackGame.PlayerSplited = false;

                        BlackJackGame.NextStep();
                    }

                    if (consoleKey == ConsoleKey.Q) return;
                }
                if (BlackJackGame.GameStage == GameStage.SPLIT_BET)
                {
                    BlackJackGame.NextStep();
                }
                if (BlackJackGame.GameStage == GameStage.ARM_STEP)
                {
                    GameView.DrawSTEPControl();
                    consoleKey = Console.ReadKey().Key;

                    if (consoleKey == ConsoleKey.UpArrow)
                    {
                        BlackJackGame.GiveCardToPlayerArm();

                        GameView.Update();
                        GameView.DrawPlayerArm();
                    }
                    else if (consoleKey == ConsoleKey.DownArrow)
                    {
                        BlackJackGame.PlayerArmStopped = true;
                        BlackJackGame.NextStep();

                        GameView.Update();
                        GameView.DrawPlayerArm();
                    }

                    if (consoleKey == ConsoleKey.Q) return;
                }
                if (BlackJackGame.GameStage == GameStage.PLAYER_LOSE_ARM_STEP)
                {
                    BlackJackGame.NextStep();

                    if (consoleKey == ConsoleKey.Q) return;
                }
                if (BlackJackGame.GameStage == GameStage.PLAYER_WIN_ARM_STEP)
                {
                    BlackJackGame.NextStep();

                    if (consoleKey == ConsoleKey.Q) return;
                }
                if (BlackJackGame.GameStage == GameStage.SPLIT_ARM_STEP && BlackJackGame.PlayerSplited == true)
                {
                    GameView.DrawSTEPControl();
                    consoleKey = Console.ReadKey().Key;

                    if (consoleKey == ConsoleKey.UpArrow)
                    {
                        BlackJackGame.GiveCardToPlayerSplitArm();

                        GameView.Update();
                        GameView.DrawPlayerSplitArm();
                    }
                    else if (consoleKey == ConsoleKey.DownArrow)
                    {
                        BlackJackGame.PlayerSplitArmStopped = true;
                        BlackJackGame.NextStep();

                        GameView.Update();
                        GameView.DrawPlayerSplitArm();
                    }

                    if (consoleKey == ConsoleKey.Q) return;
                }
                if (BlackJackGame.GameStage == GameStage.PLAYER_LOSE_SPLIT_ARM_STEP)
                {
                    BlackJackGame.NextStep();

                    if (consoleKey == ConsoleKey.Q) return;
                }
                if (BlackJackGame.GameStage == GameStage.PLAYER_WIN_SPLIT_ARM_STEP)
                {
                    BlackJackGame.NextStep();

                    if (consoleKey == ConsoleKey.Q) return;
                }
                if (BlackJackGame.GameStage == GameStage.DILLER_STEP)
                {
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
