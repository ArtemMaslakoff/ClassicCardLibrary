using ClassicCardLibrary.Core;
using ClassicCardLibrary.Core.Cards;

namespace ConsoleBlackJack.Core
{
    /// <summary>
    /// Игрок
    /// </summary>
    public static class Player
    {
        /// <summary>
        /// Деньги игрока
        /// </summary>
        public static int Money { get; private set; }

        /// <summary>
        /// Рука игрока
        /// </summary>
        public static Dictionary<int, Arm> Arms { get; private set; }

        static Player()
        {
            Money = 0;
            Arms = new Dictionary<int, Arm>() {{ 0, new Arm() }};
        }
        
        /// <summary>
        /// Новый игрок
        /// </summary>
        public static void NewPlayer()
        {
            Money = 0;
            Arms = new Dictionary<int, Arm>() { { 0, new Arm() } };
        }

        /// <summary>
        /// Добавление денег игроку
        /// </summary>
        /// <param name="money"></param>
        public static void GiveMoney(int money)
        {
            if (money <= 0) return;
            Money += money;
        }
        
        /// <summary>
        /// Изъятие денег игрока
        /// </summary>
        /// <param name="money"></param>
        public static void TakeMoney(int money)
        {
            if (money <= 0) return;
            if (money >= Money) Money = 0;
            Money -= money;
        }
        
        /// <summary>
        /// Добавление карты игроку
        /// </summary>
        /// <param name="card"></param>
        public static void GiveCard(int armId, BaseCard card)
        {
            if (armId < 0 || armId >= Arms.Count) return;
            Arms[armId].GiveCard(card);
        }

        /// <summary>
        /// Изъятие карт игрока
        /// </summary>
        /// <param name="card"></param>
        public static List<BaseCard> TakeCards()
        {
            List<BaseCard> cards = new List<BaseCard>();
            foreach (var arm in Arms)
            {
                while (arm.Value.Count > 0)
                {
                    cards.Add(arm.Value.TakeCard());
                }
            }
            return cards;
        }
    }
}