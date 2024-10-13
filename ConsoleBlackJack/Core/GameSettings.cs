using System.Runtime.CompilerServices;

namespace ConsoleBlackJack.Core
{
    /// <summary>
    /// Настройки игры
    /// </summary>
    public class GameSettings
    {
        /// <summary>
        /// Начальное количество денег игрока
        /// </summary>
        public int StartPlayerMoney { get; private set; }

        /// <summary>
        /// Задать чтартовое количество денег игрока
        /// </summary>
        /// <param name="startPlayerMoney"></param>
        public void SetStartPlayerMoney(int startPlayerMoney)
        {
            StartPlayerMoney = startPlayerMoney;
            if (startPlayerMoney < 0) StartPlayerMoney = 0;
        }

        /// <summary>
        /// Клонировать экземпляр класса
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public GameSettings Clone()
        {
            GameSettings clone = new GameSettings();
            clone.StartPlayerMoney = StartPlayerMoney;
            return clone;
        }
    }
}
