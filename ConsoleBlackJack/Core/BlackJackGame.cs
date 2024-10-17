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
        /// Ставка игрока основной руки
        /// </summary>
        public static int PlayerArmBet { get; private set; }

        /// <summary>
        /// Ставка игрока сплитованной руки
        /// </summary>
        public static int PlayerSplitArmBet { get; private set; }

        /// <summary>
        /// Колода
        /// </summary>
        private static Deck deck;

        /// <summary>
        /// Карты диллера
        /// </summary>
        public static List<Card> DeallerCards { get; private set; }

        /// <summary>
        /// Возможен ли сплит
        /// </summary>
        public static bool IsPossibleSplit { get; set; }

        /// <summary>
        /// Игрок сплитанул
        /// </summary>
        public static bool PlayerSplited { get; set; }

        static BlackJackGame()
        {
            GameSettings = new GameSettings();

            deck = new Deck();

            DeallerCards = new List<Card>();
        }
 
        /// <summary>
        /// Начать новую игру
        /// </summary>
        public static void StartNewGame()
        {
            Player.NewPlayer();
            Player.GiveMoney(GameSettings.StartPlayerMoney);

            PlayerArmBet = 0;
            PlayerSplitArmBet = 0;

            deck = DeckCreator.CreateDeckFromN52(GameSettings.NumberOfDecks);
            DeckShaffler.ShaffleDeck(deck);

            DeallerCards = new List<Card>();

            GameStage = GameStage.GAME_START;

            IsPossibleSplit = false;
            PlayerSplited = false;
        }

        public static void NextStep()
        {
            switch (GameStage)
            {
                case GameStage.GAME_START:
                    GameStage = GameStage.BET;
                    break;
                case GameStage.BET:
                    GameStage = GameStage.PLAYER_GIVE_START_CARDS;
                    break;
                case GameStage.PLAYER_GIVE_START_CARDS:
                    GameStage = GameStage.DILLER_GIVE_START_CARDS;
                    break;
                case GameStage.DILLER_GIVE_START_CARDS:
                    if (IsPossibleSplit) GameStage = GameStage.SPLIT;
                    else GameStage = GameStage.STEP;
                    break;
                case GameStage.SPLIT:
                    if (PlayerSplited) GameStage = GameStage.SPLIT_BET;
                    else GameStage = GameStage.STEP;
                    break;
                case GameStage.SPLIT_BET:
                    GameStage = GameStage.STEP;
                    break;
                case GameStage.STEP:
                    break;
            }
        }

        public static void SplitPlayerArm()
        {
            Player.SplitArmGiveCard(Player.ArmTakeCard());

            Player.TakeMoney(PlayerArmBet);
            PlayerSplitArmBet = PlayerArmBet;
        }

        /// <summary>
        /// Выдать карту из колоды игроку
        /// </summary>
        public static void GiveCardToPlayerArm()
        {
            Player.ArmGiveCard(deck.TakeCard());
        }

        /// <summary>
        /// Выдать карту из колоды игроку
        /// </summary>
        public static void GiveCardToPlayerSplitArm()
        {
            Player.SplitArmGiveCard(deck.TakeCard());
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
            PlayerArmBet = bet;
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
        GAME_START,
        BET,
        PLAYER_GIVE_START_CARDS,
        DILLER_GIVE_START_CARDS,
        SPLIT,
        SPLIT_BET,
        STEP,
        PASS_STEP,
        ADD_CARD_STEP,
        HOLD_STEP,
        DILLER_STEP,
        PLAYER_WIN_STEP,
        DILLER_WIN_STEP,
        GAME_FINISH
    }
}
