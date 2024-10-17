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
        public static Arm Arm { get; private set; }
        public static Arm SplitArm { get; private set; }

        static Player()
        {
            Money = 0;
            Arm = new Arm();
            SplitArm = new Arm();
        }
        
        /// <summary>
        /// Новый игрок
        /// </summary>
        public static void NewPlayer()
        {
            Money = 0;
            Arm = new Arm();
            SplitArm = new Arm();
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
        /// Добавление карты в основную руку
        /// </summary>
        /// <param name="card"></param>
        public static void ArmGiveCard(Card card)
        {
            if (card == null) return;
            Arm.GiveCard(card);
        }

        /// <summary>
        /// Добавление карты в сплитованную руку
        /// </summary>
        /// <param name="card"></param>
        public static void SplitArmGiveCard(Card card)
        {
            if (card == null) return;
            SplitArm.GiveCard(card);
        }

        /// <summary>
        /// Изъятие карты из основной руки игрока
        /// </summary>
        public static Card ArmTakeCard()
        {
            return Arm.TakeCard();
        }

        /// <summary>
        /// Изъятие карты из сплитованной руки игрока
        /// </summary>
        public static Card SplitArmTakeCard()
        {
            return SplitArm.TakeCard();
        }

        /// <summary>
        /// Изъятие карт игрока
        /// </summary>
        /// <param name="card"></param>
        public static List<Card> TakeCards()
        {
            List<Card> cards = new List<Card>();
            while (Arm.Count > 0)
            {
                cards.Add(Arm.TakeCard());
            }
            while (SplitArm.Count > 0)
            {
                cards.Add(SplitArm.TakeCard());
            }
            return cards;
        }
    }
}