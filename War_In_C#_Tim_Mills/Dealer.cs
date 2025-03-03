using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
    internal class Dealer
    {

        protected List<Card> hand;

        public Dealer()
        {
            hand = new List<Card>();
        }

        public int calculatePoints()
        {
            int total = 0;
            foreach (Card card in hand)
            {
                total += card.getPointValue();
            }
            return total;
        }

        public void addCard(Card card)
        {
            hand.Add(card);
        }

        public void printInitialHand()
        {
            Console.WriteLine("Dealer is showing: " + hand[0].getRank() + " of " + hand[0].getSuit() + "\n");            
        }

        public virtual void act(Deck deck)
        {
            //A dealer in blackjack must hit on 16 and stay on any point value greater than 16
            while (calculatePoints() < 17)
            {
                hand.Add(deck.deal());
            }
        }

        public void printHand()
        {
            Console.WriteLine("\nDealer has: \n");
            foreach (Card card in hand)
            {
                Console.WriteLine(card.getRank() + " of " + card.getSuit());
            }
            Console.WriteLine();
        }
        public void resetHand()
        {
            hand = new List<Card>();
        }

    }
}
