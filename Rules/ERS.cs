// namespace Toolkit.Rules.ERS;
//
// public static class ERSRules
// {
//     extension(Deck deck)
//     {
//         public void PlayERS(Random random)
//         {
//             List<Card> pile = new List<Card>();
//             Card? card = deck.DealOne();
//             if (card == null) return;
//             pile.Add(card);
//             if (card.Value == Value.Ace || card.Value == Value.Jack || card.Value == Value.Queen ||
//                 card.Value == Value.King)
//             {
//                 Console.WriteLine("A face card, " + card.Value + " was played!");
//             }
//
//             IsSlap(pile);
//         } 
//         
//         public List<Deck> DealStartingHands(int numberOfPlayers, int cardsPerPlayer)
//         {
//             List<Deck> startingHands = new List<Deck>();
//
//
//             for (int i = 0; i < numberOfPlayers; i++)
//             {
//                 startingHands.Add(deck.DealHand(cardsPerPlayer));
//             }
//
//             return startingHands;
//         }
//
//         bool IsSlap(List<Card> pile)
//         {
//             if (pile.Count < 2) return false;
//             if (pile[pile.Count - 1].Value == pile[pile.Count - 2].Value)
//             {
//                 return true;
//             }
//
//             return false;
//         }
//     }
//     
// }
