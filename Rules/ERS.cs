namespace Toolkit.Rules.ERS;

public static class ERSRules
{
    extension(Deck deck)
    {
        public void PlayERS(Random random)
        {
            Card? card = deck.DealOne();
            if (card == null) return;
            if (card.Value == Value.Ace || card.Value == Value.Jack || card.Value == Value.Queen ||
                card.Value == Value.King)
            {
                Console.WriteLine("A face card, " + card.Value + " was played!");
            }
        }
        
        public List<Deck> DealStartingHands(int numberOfPlayers, int cardsPerPlayer)
        {
            List<Deck> startingHands = new List<Deck>();


            for (int i = 0; i < numberOfPlayers; i++)
            {
                deck.DealHand(cardsPerPlayer);
            }

            return startingHands;
        }
    }
    
}
