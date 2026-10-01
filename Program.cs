using Toolkit;
using Toolkit.Rules;
// notice that we need the below line otherwise PlayWar won't exist
using Toolkit.Rules.War;
using Toolkit.Rules.ERS;


var random = new Random();

var myDeck = Deck.CreateStandardDeck();

myDeck.Shuffle(random,(d,r) => { });

myDeck.Shuffle(random, ShuffleAlgorithms.Default);

myDeck.PlayWar(random);
myDeck.PlayERS(random);