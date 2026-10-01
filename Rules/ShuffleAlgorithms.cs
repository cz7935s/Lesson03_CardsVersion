using LanguageExt;

namespace Toolkit.Rules.ShuffleAlgorithms;
public static class ShuffleAlgorithms
{
   /// <summary>
   /// Shuffles the deck using the default Fisher-Yates shuffle algorithm
   /// </summary>
   /// <param name="deck"></param>
   /// <param name="random"></param>
   public static void Default(Deck deck, Random random)
   {
      var cards = deck.Deal(deck.Count);

      for (int i = cards.Count - 1; i > 0; i--)
      {
         int j = random.Next(i + 1);
         (cards[i], cards[j]) = (cards[j], cards[i]);
      }

      deck.AddCardsOnBottom(cards);
   }

   public static void RiffleShuffle(Deck deck, Random random)
   {
      List<Card> result = [];
      Deck right = deck.Split();
      
      while (deck.Count > 0 && right.Count > 0)
      {
         result.AddRange(deck.Deal(random.Next(1,5)));
         result.AddRange(right.Deal(random.Next(1,5)));
      }
      
      result.AddRange(deck.Deal(deck.Count));
      result.AddRange(right.Deal(right.Count));

      deck.AddCardsOnTop(result);
   }
}