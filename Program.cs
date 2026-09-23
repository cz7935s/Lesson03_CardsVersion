using Toolkit;
// notice that we need the below line otherwise PlayWar won't exist
using Toolkit.Rules.War;

var random = new Random();

var myDeck = Deck.CreateStandardDeck();

myDeck.Shuffle(random);

myDeck.PlayWar(random);