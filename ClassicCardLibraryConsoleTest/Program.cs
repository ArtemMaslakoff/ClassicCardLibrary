using ClassicCardLibrary.Core;
using ClassicCardLibraryConsoleTest;

internal class Program
{
    private static void Main(string[] args)
    {
        Deck deck = DeckCreator.CreateDeck36();

        Console.WriteLine(deck.Count());
        Console.WriteLine();
        DeckShaffler.ShaffleDeck(deck);

        Arm arm = new Arm();
        arm.AddCard(deck.TakeCard());
        arm.AddCard(deck.TakeCard());
        arm.AddCard(deck.TakeCard());
        arm.AddCard(deck.TakeCard());
        arm.AddCard(deck.TakeCard());
        arm.AddCard(deck.TakeCard());

        Console.WriteLine(arm.Count);

        for (int i = 0; i < arm.Count; i++)
        {
            Console.WriteLine(ConsoleCardDrawer.CardToString(arm.Cards[i]));
        }
    }
}