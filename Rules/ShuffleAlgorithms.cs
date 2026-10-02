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

   //1. What the hands do, step by step, in plain words: First the hands split the deck of cards into two equal sized decks. Then small chunks(1-4 cards) of each deck get added to the final shuffled deck until one of the decks runs out. Once one runs out all the remaining cards from the rest are just added. 
   //2. Which lines of code match which step: Deck result = Deck.CreateEmpty(); creates the space for the result/shuffled deck; Deck right = deck.Split(); creates the 'right' deck (the 'left' deck is the original deck); the while loop keeps looping until one of the right/left decks runs out and each time it loops, 1-4 cards get added from each deck as one can see in the body of the loop. The next two lines below the loop describe adding the remainder of the cards after one of the decks runs out, and the final line describes returning the result List that we've been adding cards to back into the actual deck. 
   //3. One place your code differs from the person, and why you let it: One place where my code differs from the person is that the person, when shuffling, may add more than 4 cards from one of the left/right decks at one time as shuffling can be quite unpredictable. 
   //4. Any member you added to Deck, and why it belongs on the deck and stays out of your shuffle: Another member I added to Deck was "CreateEmpty" which still belongs in Deck because it is still a deck despite being empty. It stays out of shuffle because it's Deck's job to know how to create oneself, not the shuffle algorithm's job. 
   public static void RiffleShuffle(Deck deck, Random random)
   {
      Deck result = Deck.CreateEmpty();
      Deck right = deck.Split();
      
      while (deck.Count > 0 && right.Count > 0)
      {
         result.AddCardsOnBottom(deck.Deal(random.Next(1,5)));
         result.AddCardsOnBottom(right.Deal(random.Next(1,5)));
      }
      
      result.AddCardsOnBottom(deck.Deal(deck.Count));
      result.AddCardsOnBottom(right.Deal(right.Count));

      deck.AddCardsOnBottom(result.Deal(result.Count));
   }
}