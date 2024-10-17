using ClassicCardLibrary.Core.Cards;

namespace ClassicCardLibrary.Core
{
    /// <summary>
    /// Создатель колод стандартных форматов
    /// </summary>
    public static class DeckCreator
    {
        /// <summary>
        /// Создание классической колоды в 36 карт
        /// </summary>
        /// <returns></returns>
        public static Deck CreateDeck36()
        {
            Deck deck = new Deck();
            for (CardSuit cardSuit = CardSuit.DIAMONDS; cardSuit <= CardSuit.SPADES; cardSuit++)
            {
                for (CardValue cardValue = CardValue.SIX; cardValue <= CardValue.A; cardValue++)
                {
                    deck.GiveCard(new Card(cardSuit, cardValue));
                }
            }
            return deck;
        }

        /// <summary>
        /// Создание колоды из n классических колод в 36 карт
        /// </summary>
        /// <param name="decksCount"></param>
        /// <returns></returns>
        public static Deck CreateDeckFromN36(int decksCount)
        {
            Deck deck = new Deck();
            for (int i = 0; i < decksCount; i++)
            {
                for (CardSuit cardSuit = CardSuit.DIAMONDS; cardSuit <= CardSuit.SPADES; cardSuit++)
                {
                    for (CardValue cardValue = CardValue.SIX; cardValue <= CardValue.A; cardValue++)
                    {
                        deck.GiveCard(new Card(cardSuit, cardValue));
                    }
                }
            }
            return deck;
        }

        /// <summary>
        /// Создание классической колоды в 52 карты
        /// </summary>
        /// <returns></returns>
        public static Deck CreateDeck52()
        {
            Deck deck = new Deck();
            for (CardSuit cardSuit = CardSuit.DIAMONDS; cardSuit <= CardSuit.SPADES; cardSuit++)
            {
                for (CardValue cardValue = CardValue.TWO; cardValue <= CardValue.A; cardValue++)
                {
                    deck.GiveCard(new Card(cardSuit, cardValue));
                }
            }
            return deck;
        }

        /// <summary>
        /// Создание колоды из n классических колод в 52 карт
        /// </summary>
        /// <param name="decksCount"></param>
        /// <returns></returns>
        public static Deck CreateDeckFromN52(int decksCount)
        {
            Deck deck = new Deck();
            for (int i = 0; i < decksCount; i++)
            {
                for (CardSuit cardSuit = CardSuit.DIAMONDS; cardSuit <= CardSuit.SPADES; cardSuit++)
                {
                    for (CardValue cardValue = CardValue.TWO; cardValue <= CardValue.A; cardValue++)
                    {
                        deck.GiveCard(new Card(cardSuit, cardValue));
                    }
                }
            }
            return deck;
        }

        /// <summary>
        /// Создание классической колоды в 54 карты (2 джокера)
        /// </summary>
        /// <returns></returns>
        public static Deck CreateDeck54()
        {
            Deck deck = new Deck();
            for (CardSuit cardSuit = CardSuit.DIAMONDS; cardSuit <= CardSuit.SPADES; cardSuit++)
            {
                for (CardValue cardValue = CardValue.TWO; cardValue <= CardValue.A; cardValue++)
                {
                    deck.GiveCard(new Card(cardSuit, cardValue));
                }
            }
            deck.GiveCard(new Card(CardSuit.JOCKER, CardValue.JOCKER));
            deck.GiveCard(new Card(CardSuit.JOCKER, CardValue.JOCKER));
            return deck;
        }

        /// <summary>
        /// Создание колоды из n классических колод в 54 карт
        /// </summary>
        /// <returns></returns>
        public static Deck CreateDeckFromN54(int decksCount)
        {
            Deck deck = new Deck();
            for (int i = 0; i < decksCount; i++)
            {
                for (CardSuit cardSuit = CardSuit.DIAMONDS; cardSuit <= CardSuit.SPADES; cardSuit++)
                {
                    for (CardValue cardValue = CardValue.TWO; cardValue <= CardValue.A; cardValue++)
                    {
                        deck.GiveCard(new Card(cardSuit, cardValue));
                    }
                }
                deck.GiveCard(new Card(CardSuit.JOCKER, CardValue.JOCKER));
                deck.GiveCard(new Card(CardSuit.JOCKER, CardValue.JOCKER));
            }
            return deck;
        }
    }
}
