using ConsoleBlackJack.Controllers;

namespace ConsoleBlackJack.Core
{
    /// <summary>
    /// Основной контроллер игры
    /// </summary>
    public static class BlackJackController
    {
        /// <summary>
        /// Игрок
        /// </summary>
        public static Player Player { get; private set; }

        /// <summary>
        /// Настройки игры
        /// </summary>
        public static GameSettings GameSettings { get; private set; }

        static BlackJackController()
        {
            Player = new Player();
            GameSettings = new GameSettings();
        }

        /// <summary>
        /// Старт игры
        /// </summary>
        public static void Start()
        {
            MainMenuController.Start();
        }

        public static void NewPlayer()
        {
            Player = new Player();
        }
        public static void SetGameSettings(GameSettings gameSettings)
        {
            GameSettings = gameSettings.Clone();
        }
    }
}
