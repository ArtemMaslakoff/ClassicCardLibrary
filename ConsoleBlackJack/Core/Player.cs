using ClassicCardLibrary.Core;
using ClassicCardLibrary.Core.Cards;

namespace ConsoleBlackJack.Core
{
    /// <summary>
    /// Игрок
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Деньги игрока
        /// </summary>
        public int Money { get; private set; }

        /// <summary>
        /// Рука игрока
        /// </summary>
        public Dictionary<int, Arm> Arms { get; private set; }

        public Player()
        {
            Money = 0;
            Arms = new Dictionary<int, Arm>();
            Arms.Add(0, new Arm());
        }
        public Player(int money)
        {
            if (money <= 0) money = 0;
            Money = money;
            Arms = new Dictionary<int, Arm>();
            Arms.Add(0, new Arm());
        }
        
        /// <summary>
        /// Добавление денег игроку
        /// </summary>
        /// <param name="money"></param>
        public void GiveMoney(int money)
        {
            if (money <= 0) return;
            Money += money;
        }
        
        /// <summary>
        /// Изъятие денег игрока
        /// </summary>
        /// <param name="money"></param>
        public void TakeMoney(int money)
        {
            if (money <= 0) return;
            if (money >= Money) Money = 0;
            Money -= money;
        }
        
        /// <summary>
        /// Добавление карты игроку
        /// </summary>
        /// <param name="card"></param>
        public void GiveCard(int armId, BaseCard card)
        {
            if (armId < 0 || armId >= Arms.Count) return;
            Arms[armId].GiveCard(card);
        }

        /// <summary>
        /// Изъятие карт игрока
        /// </summary>
        /// <param name="card"></param>
        public List<BaseCard> TakeCards()
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