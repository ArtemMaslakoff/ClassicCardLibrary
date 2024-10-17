using ClassicCardLibrary.Core.Cards;

namespace ClassicCardLibrary.Core
{
    /// <summary>
    /// Перемешиватель колод
    /// </summary>
    public static class DeckShaffler
    {
        /// <summary>
        /// Раздомайзер
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// Перемешать колоду
        /// </summary>
        public static void ShaffleDeck(Deck deck)
        {
            Card[] cards = new Card[deck.Count()];
            for (int i = 0; i < cards.Length;i++)
            {
                cards[i] = deck.TakeCard();
            }
            for (int i = 0; i < cards.Length;i++)
            {
                int splitterPosition = random.Next(cards.Count());
                Card timeCard = cards[splitterPosition];
                cards[splitterPosition] = cards[i];
                cards[i] = timeCard;
            }
            for (int i = 0; i < cards.Length;i++)
            {
                deck.GiveCard(cards[i]);
            }
        }
    }
}
