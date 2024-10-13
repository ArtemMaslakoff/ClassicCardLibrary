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

        static BlackJackGame()
        {
            GameSettings = new GameSettings();
        }

        /// <summary>
        /// Старт игры
        /// </summary>
        public static void Start()
        {
            MainMenuController.Start();
        }

        /// <summary>
        /// Задать ставку игрока
        /// </summary>
        public static void SetPlayerBet(int bet)
        {
            if (bet <= 0) throw new ArgumentOutOfRangeException();
            if (bet > Player.Money) throw new ArgumentOutOfRangeException();
            PlayerBet = bet;
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
