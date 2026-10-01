
using Toolkit;
using Toolkit.Rules;
// notice that we need the below line otherwise PlayWar won't exist
using Toolkit.Rules.War;
// using Toolkit.Rules.ERS;
using Toolkit.Rules.ShuffleAlgorithms;

static void Show(string label, Deck deck)
{
    var cards = deck.Deal(deck.Count);
    Console.WriteLine($"{label} ({cards.Count}):  {string.Join(" ", cards)}");
    deck.AddCardsOnTop(cards);
}

var random = new Random();          // a fixed seed, so every run matches
var myDeck = Deck.CreateStandardDeck();

Show("before", myDeck);
myDeck.Shuffle(random, ShuffleAlgorithms.RiffleShuffle);
Show("after ", myDeck);

// myDeck.PlayWar(random);

// var random = new Random();
//
// var myDeck = Deck.CreateStandardDeck(

myDeck.Shuffle(random,(d,r) => { });

myDeck.Shuffle(random, ShuffleAlgorithms.Default);

// myDeck.PlayWar(random);
// myDeck.PlayERS(random);

