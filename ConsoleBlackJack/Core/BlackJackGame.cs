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
        /// Остановился ли игрок брять карты в руку
        /// </summary>
        public static bool PlayerArmStopped { get; set; }

        /// <summary>
        /// Остановился ли игрок брять карты в сплитованную руку
        /// </summary>
        public static bool PlayerSplitArmStopped { get; set; }

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

            PlayerArmStopped = false;
            PlayerSplitArmStopped = false;
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
                    else GameStage = GameStage.ARM_STEP;
                    break;
                case GameStage.SPLIT:
                    if (PlayerSplited) GameStage = GameStage.SPLIT_BET;
                    else GameStage = GameStage.ARM_STEP;
                    break;
                case GameStage.SPLIT_BET:
                    GameStage = GameStage.ARM_STEP;
                    break;
                case GameStage.ARM_STEP:
                    if (CheckPlayerArmSumUpper21()) GameStage = GameStage.PLAYER_LOSE_ARM_STEP;
                    else if (GetPlayerArmSum() == 21) GameStage = GameStage.PLAYER_WIN_ARM_STEP;
                    else if (PlayerArmStopped)
                    {
                        if (PlayerSplited == true) GameStage = GameStage.SPLIT_ARM_STEP;
                        else GameStage = GameStage.DILLER_STEP;
                    }
                    break;
                case GameStage.PLAYER_LOSE_ARM_STEP:
                    if (PlayerSplited == true) GameStage = GameStage.SPLIT_ARM_STEP;
                    else GameStage = GameStage.DILLER_STEP;
                    break;
                case GameStage.PLAYER_WIN_ARM_STEP:
                    if (PlayerSplited == true) GameStage = GameStage.SPLIT_ARM_STEP;
                    else GameStage = GameStage.DILLER_STEP;
                    break;
                case GameStage.SPLIT_ARM_STEP:
                    if (CheckPlayerSplitArmSumUpper21()) GameStage = GameStage.PLAYER_LOSE_SPLIT_ARM_STEP;
                    else if (GetPlayerSplitArmSum() == 21) GameStage = GameStage.PLAYER_WIN_SPLIT_ARM_STEP;
                    else if (PlayerSplitArmStopped) GameStage = GameStage.DILLER_STEP;
                    break;
                case GameStage.PLAYER_LOSE_SPLIT_ARM_STEP:
                    GameStage = GameStage.DILLER_STEP;
                    break;
                case GameStage.PLAYER_WIN_SPLIT_ARM_STEP:
                    GameStage = GameStage.DILLER_STEP;
                    break;
                case GameStage.DILLER_STEP:
                    break;

            }
        }

        /// <summary>
		/// Сплитануть руку игрока
        /// </summary>
        public static void SplitPlayerArm()
        {
            Player.SplitArmGiveCard(Player.ArmTakeCard());

            Player.TakeMoney(PlayerArmBet);
            PlayerSplitArmBet = PlayerArmBet;
        }

        /// <summary>
        /// Проверить руку игрока на 21
        /// </summary>
        /// <returns></returns>
        public static bool CheckPlayerArmSumUpper21()
        {
            if (GetPlayerArmSum() > 21) return true;
            return false;
        }

        /// <summary>
        /// Проверить сплитованную руку игрока на 21
        /// </summary>
        /// <returns></returns>
        public static bool CheckPlayerSplitArmSumUpper21()
        {
            if (GetPlayerSplitArmSum() > 21) return true;
            return false;
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

        /// <summary>
        /// Сумма карт в руке
        /// </summary>
        /// <returns></returns>
        public static int GetPlayerArmSum()
        {
            int result = 0;
            int ACount = 0;
            for (int i = 0;i < Player.Arm.Count; i++)
            {
                if (Player.Arm.Cards[i].CardValue == CardValue.J ||
                    Player.Arm.Cards[i].CardValue == CardValue.Q ||
                    Player.Arm.Cards[i].CardValue == CardValue.K)
                {
                    result += 10;
                }
                else if (Player.Arm.Cards[i].CardValue == CardValue.A)
                {
                    ACount++;
                }
                else
                {
                    result += (int)Player.Arm.Cards[i].CardValue;
                }
            }
            result += ACount;
            for (int i = 0; i < ACount; i++)
            {
                result += 10;
                if (result > 21)
                {
                    result -= 10;
                    return result;
                }
            }
            return result;
        }

        /// <summary>
        /// Сумма карт в сплитованной руке
        /// </summary>
        /// <returns></returns>
        public static int GetPlayerSplitArmSum()
        {
            int result = 0;
            int ACount = 0;
            for (int i = 0; i < Player.SplitArm.Count; i++)
            {
                if (Player.SplitArm.Cards[i].CardValue == CardValue.J ||
                    Player.SplitArm.Cards[i].CardValue == CardValue.Q ||
                    Player.SplitArm.Cards[i].CardValue == CardValue.K)
                {
                    result += 10;
                }
                else if (Player.SplitArm.Cards[i].CardValue == CardValue.A)
                {
                    ACount++;
                }
                else
                {
                    result += (int)Player.SplitArm.Cards[i].CardValue;
                }
            }
            result += ACount;
            for (int i = 0; i < ACount; i++)
            {
                result += 10;
                if (result > 21)
                {
                    result -= 10;
                    return result;
                }
            }
            return result;
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
        ARM_STEP,
        SPLIT_ARM_STEP,
        PLAYER_WIN_ARM_STEP,
        PLAYER_LOSE_ARM_STEP,
        PLAYER_WIN_SPLIT_ARM_STEP,
        PLAYER_LOSE_SPLIT_ARM_STEP,
        DILLER_STEP,
        GAME_FINISH
    }
}
