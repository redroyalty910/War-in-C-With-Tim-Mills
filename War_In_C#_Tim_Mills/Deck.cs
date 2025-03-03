using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame // this was the class we were intended to use from class
{
    internal class Deck
    {

        private Random rng;
        private string[] suits = { "hearts", "diamonds", "clubs", "spades" };
        private string[] ranks = {"ace", "two", "three", "four", "five", "six", "seven",
            "eight", "nine", "ten", "jack", "queen", "king" };

        private List<Card> deck;

        public Deck()
        {            
            initialize();
        }

        public void initialize()
        {
            rng = new Random();
            deck = new List<Card>();   //clears deck                        
            
            foreach(string s in suits)
            {
                int pointCounter = 1;           //used to assign points to our cards                
                foreach (string r in ranks) {   //iterate over ranks so I can keep track of point values.
                    if (r == "ace") deck.Add(new Card(s, r, 11));   //make aces default to 11
                    else 
                    {
                        if (pointCounter < 10)                      //max out points at 10 (except for aces)
                            pointCounter++;
                        deck.Add(new Card(s, r, pointCounter));     //add a non-ace
                    }                    
                }
            }
            //Shuffle the deck 100 times (C# rng is bad!)
            for(int i = 0; i < 100; i++)
            {
                shuffle();
            }            
        }

        //Represents one shuffle of the Deck
        //Does a non in-line shuffle of a List.
        //Copies all contents of the list by having two Lists present (this is not memory-efficient)
        private void shuffle()
        {
            List<Card> shuffled = new List<Card>();
            while (deck.Count > 0)
            {
                int randomIndex = rng.Next(0, deck.Count);
                Card removed = deck[randomIndex];
                deck.Remove(removed);
                shuffled.Add(removed);
            }
            deck = shuffled;
        }

        //Return top card.
        public Card deal()
        {
            Card removed = deck[0];
            deck.RemoveAt(0);
            return removed;
        }

        //This may be a useful function in many games.
        //It is used by our cheating dealer.
        public Card getCardWithValue(int pointValue)
        {
            foreach (Card card in deck)
            {
                if (card.getPointValue() == pointValue)
                {
                    deck.Remove(card);
                    return card;
                }
            }
            return null;
        }

        //Prints all of the Cards in the Deck.  Useful for debugging.
        public void printDeck()
        {
            foreach(Card card in deck)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine("Total Cards: " + deck.Count);
        }

    }
}
