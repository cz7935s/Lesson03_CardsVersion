using LanguageExt;

namespace Toolkit;

public record Deck
{
    //factory method: it is impossible to create an invalid deck here, it will always be a standard deck
    public static Deck CreateStandardDeck() => new Deck();
    public static Deck CreateEmpty() => new Deck([]);

    private List<Card> _cards;

    private Deck(List<Card> fromcards) => _cards = fromcards;
    
    private Deck()
    {
        _cards = new List<Card>();
        foreach (var suit in new[] { Suit.Hearts, Suit.Diamonds, Suit.Clubs, Suit.Spades })
        {
            foreach (var value in new[] { Value.Ace, Value.Two, Value.Three, Value.Four, Value.Five, Value.Six, Value.Seven, Value.Eight, Value.Nine, Value.Ten, Value.Jack, Value.Queen, Value.King })
            {
                _cards.Add(new Card(suit, value));
            }
        }
    }

    /// <summary>
    /// Shuffles the deck of cards!
    /// </summary>
    /// <param name="random">Inject your RNG here!</param>
    // public void Shuffle(Random random)
    // {
    //     for (int i = _cards.Count - 1; i > 0; i--)
    //     {
    //         int j = random.Next(i + 1);
    //         (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
    //     }
    // }

    public void Shuffle(Random random, Action<Deck, Random> shuffleAlgorithm)
    {
        shuffleAlgorithm(this, random);
    }

    public Deck Split()
    {
        Deck other = new Deck(_cards.Take(_cards.Count / 2).ToList());
        _cards.RemoveRange(0, _cards.Count / 2);
        return other;
        // throw new NotImplementedException("Split method is not implemented yet.");
        // TODO: Implement the Split method to return a new Deck with half-ish of the cards.
    }

    // public void Cut()
    // {
    //     //throw new NotImplementedException("Cut method is not implemented yet.");
    //     // TODO: How is Cut different from Split?
    //
    //     Random random = new Random();
    //     int cutPoint = random.Next(_cards.Count);
    //     List<Card> cut = _cards.Take(cutPoint).ToList();
    //     _cards.RemoveRange(0, cutPoint);
    //     _cards.AddRange(cut);
    // }

    public Deck Cut(Random random)
    {
        var cutPoint = random.Next(_cards.Count);
        var otherHalf = new Deck([.._cards[..cutPoint]]); // wild syntax with the .. 
        _cards = [.._cards[cutPoint..]];

        return otherHalf;
    }
    

    // public Card DealOne()
    // {
    //     if (_cards.Count == 0)
    //         throw new InvalidOperationException("No cards left in the deck.");
    //     // a valid way to do it: return null; 
    //     // another way: i can try to give you a card but can't guarantee that 
    //
    //     var card = _cards[0];
    //     _cards.RemoveAt(0);
    //     return card;
    // }

    public Card? DealOne()
    {
        if (_cards.Count == 0)
            return null;
        
        var card = _cards[0];
        _cards.RemoveAt(0);
        return card;
    }

    public List<Card> Deal(int count)
    {
        var dealtCards = new List<Card>();
        for (int i = 0; i < count; i++)
        {
            var card = DealOne();
            if(card is not null)
              dealtCards.Add(card);
        }
        return dealtCards;
    }
    
    // but what if theres a null card? u might get the number of cards u asked for, but you might also get less than that! 

    public int Count => _cards.Count;
    
    public Deck DealHand(int count)
    {
        return new Deck(Deal(count));
    }

    public void AddCardsOnTop(params List<Card> cards)
        => _cards = [..cards, .._cards];

    public void AddCardsOnBottom(params List<Card> cards)
        => _cards = [.. _cards, .. cards];

    public void InsertCardsRandomly(Random random, params List<Card> cards)
    {
        var otherHalf  = Cut(random);

        _cards = [.. _cards, .. cards, ..otherHalf._cards];

    }


}



