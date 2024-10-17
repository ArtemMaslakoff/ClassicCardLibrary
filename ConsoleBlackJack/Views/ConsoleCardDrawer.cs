using ClassicCardLibrary.Core.Cards;

namespace ConsoleBlackJack.Views
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConsoleCardDrawer
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<CardSuit, char> cardSuitChars = new Dictionary<CardSuit, char>
        {
            { CardSuit.HEARTS, '♥' },
            { CardSuit.CLUBS, '♣' },
            { CardSuit.SPADES, '♠' },
            { CardSuit.DIAMONDS, '♦' }
        };

        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<CardValue, char> cardValueChars = new Dictionary<CardValue, char>
        {
            { CardValue.TWO, '2' },
            { CardValue.THREE, '3' },
            { CardValue.FOUR, '4' },
            { CardValue.FIVE, '5' },
            { CardValue.SIX, '6' },
            { CardValue.SEVEN, '7' },
            { CardValue.EIGHT, '8' },
            { CardValue.NINE, '9' },
            { CardValue.TEN, 'T' },
            { CardValue.J, 'J' },
            { CardValue.Q, 'Q' },
            { CardValue.K, 'K' },
            { CardValue.A, 'A' },
        };

        private static readonly string jokerChar = "JK";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public static string CardToString(Card card)
        {
            if (card == null) throw new ArgumentNullException();
            if (card.CardValue == CardValue.JOCKER) return "[" + jokerChar + "]";
            return "[" + cardValueChars[((Card)card).CardValue] + cardSuitChars[((Card)card).CardSuit] + "]";
        }
    }
}
