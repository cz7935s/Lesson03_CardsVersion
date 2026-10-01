namespace Toolkit.Rules;
public static class ShuffleAlgorithms
{
   /// <summary>
   /// Shuffles the deck using the default Fisher-Yates shuffle algorithm
   /// </summary>
   /// <param name="deck"></param>
   /// <param name="random"></param>
   public static void Default(Deck deck, Random random)
   {
      var cards = Deck.Deal(deck.Count);

      for (int i = cards.Count - 1; i > 0; i--)
      {
         int j = random.Next(i + 1);
         (cards[i], cards[j]) = (cards[j], cards[i]);
      }

      deck.AddCardsOnBottom(cards);
   }

   public static void RifleShuffle(Deck deck, Random random)
   {
      List<Card> result = [];
      
   }
}