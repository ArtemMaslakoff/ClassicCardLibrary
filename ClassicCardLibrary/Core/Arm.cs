using ClassicCardLibrary.Core.Cards;
using System.ComponentModel.DataAnnotations;

namespace ClassicCardLibrary.Core
{
    /// <summary>
    /// Рука
    /// </summary>
    public class Arm
    {
        /// <summary>
        /// Карты в руке
        /// </summary>
        public List<BaseCard> Cards { get; private set; }

        /// <summary>
        /// Количество карт в руке
        /// </summary>
        public int Count => Cards.Count;

        public Arm()
        {
            Cards = new List<BaseCard>();
        }

        /// <summary>
        /// Добавление карты в руку
        /// </summary>
        /// <param name="card"></param>
        public void GiveCard(BaseCard card)
        {
            Cards.Add(card);
        }

        /// <summary>
        /// Изъятие карты из руки
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public BaseCard TakeCard()
        {
            if (Cards.Count == 0) throw new Exception("Arm is empty");
            BaseCard card = Cards[Cards.Count - 1];
            Cards.RemoveAt(Cards.Count - 1);
            return card;
        }
    }
}
