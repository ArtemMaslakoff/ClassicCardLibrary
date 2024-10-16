﻿using ClassicCardLibrary.Core.Cards;

namespace ClassicCardLibrary.Core
{
    /// <summary>
    /// Колода
    /// </summary>
    public class Deck
    {
        /// <summary>
        /// Карты в колоде
        /// </summary>
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();    
        }

        /// <summary>
        /// Добавление карты в колоду
        /// </summary>
        /// <param name="card"></param>
        public void GiveCard(Card card)
        {
            cards.Add(card);
        }

        /// <summary>
        /// Изъятие карты из колоды
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Card TakeCard()
        {
            if (cards.Count == 0)   throw new Exception("Deck is empty");
            Card card = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return card;
        }

        /// <summary>
        /// Количество карт в колоде
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return cards.Count;
        }
    }
}
