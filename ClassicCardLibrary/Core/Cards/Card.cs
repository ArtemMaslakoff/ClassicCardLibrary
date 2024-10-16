namespace ClassicCardLibrary.Core.Cards
{
    /// <summary>
    /// Карта
    /// </summary>
    public class Card : BaseCard
    {
        /// <summary>
        /// Масть карты
        /// </summary>
        public CardSuit CardSuit { get; private set; }

        /// <summary>
        /// Номинал карты
        /// </summary>
        public CardValue CardValue { get; private set; }

        public Card(CardSuit cardSuit, CardValue cardValue)
        {
            CardSuit = cardSuit;
            CardValue = cardValue;
        }

        /// <summary>
        /// Строковое представление
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return CardSuit.ToString() + " " + CardValue.ToString();
        }

        /// <summary>
        /// Сравнение
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Card)) return false;
            if (this == obj) return true;
            if (this.CardSuit == ((Card)obj).CardSuit && this.CardValue == ((Card)obj).CardValue) return true;
            return false;
        }
    }

    /// <summary>
    /// Карточные масти
    /// </summary>
    public enum CardSuit
    {
        DIAMONDS = 1, // Бубы
        HEARTS = 2, // Черви
        CLUBS = 3, // Крести
        SPADES = 4 // Пики
    }

    /// <summary>
    /// Карточные номиналы
    /// </summary>
    public enum CardValue
    {
        TWO = 2,
        THREE = 3,
        FOUR = 4,
        FIVE = 5,
        SIX = 6,
        SEVEN = 7,
        EIGHT = 8,
        NINE = 9,
        TEN = 10,
        J = 11,
        Q = 12,
        K = 13,
        A = 14
    }
}
