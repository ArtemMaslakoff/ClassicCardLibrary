using ClassicCardLibrary.Core;
using ClassicCardLibrary.Core.Cards;
using ConsoleBlackJack.Controllers;

namespace ConsoleBlackJack.Core
{
    /// <summary>
    /// Игра Black Jack
    /// </summary>
    public static class BlackJackGame
    {
        /// <summary>
        /// Настройки игры
        /// </summary>
        public static GameSettings GameSettings { get; private set; }

        /// <summary>
        /// Нынешний этап игры
        /// </summary>
        public static GameStage GameStage { get; private set; }

        /// <summary>
        /// Ставка игрока
        /// </summary>
        public static int PlayerBet { get; private set; }

        /// <summary>
        /// Колода
        /// </summary>
        private static Deck deck;

        public static List<BaseCard> DeallerCards { get; private set; }

        static BlackJackGame()
        {
            GameSettings = new GameSettings();
        }

        /// <summary>
        /// Начать новую игру
        /// </summary>
        public static void StartNewGame()
        {
            Player.NewPlayer();
            Player.GiveMoney(GameSettings.StartPlayerMoney);

            PlayerBet = 0;

            deck = DeckCreator.CreateDeckFromN52(GameSettings.NumberOfDecks);
        }

        /// <summary>
        /// Выдать карту из колоды игроку
        /// </summary>
        public static void GiveCardToPlayer(int armId)
        {
            Player.GiveCard(armId, deck.TakeCard());
        }

        /// <summary>
        /// Выдать карту из колоды диллеру
        /// </summary>
        public static void GiveCardToDealler()
        {
            DeallerCards.Add(deck.TakeCard());
        }

        /// <summary>
        /// Задать ставку игрока
        /// </summary>
        public static void SetPlayerBet(int bet)
        {
            if (bet <= 0) throw new ArgumentOutOfRangeException();
            if (bet > Player.Money) throw new ArgumentOutOfRangeException();
            PlayerBet = bet;
            Player.TakeMoney(bet);
        }

        /// <summary>
        /// Задать этап игры
        /// </summary>
        public static void SetGameStage(GameStage  gameStage)
        {
            GameStage = gameStage;
        }

        /// <summary>
        /// Задать настройки игры
        /// </summary>
        /// <param name="gameSettings"></param>
        public static void SetGameSettings(GameSettings gameSettings)
        {
            GameSettings = gameSettings.Clone();
        }
    }

    /// <summary>
    /// Этапы игры
    /// </summary>
    public enum GameStage
    {
        GAMESTART,
        BET,
        STEP,
        GAMEFINISH
    }
}
