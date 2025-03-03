using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
    internal class Player
    {
        private List<Card> hand;
        private int chips;
        public Player() { 
            hand = new List<Card>();
            chips = 2000;
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

        public int getChips()
        {
            return chips;
        }

        public void setChips(int c)
        {
            chips += c;
        }

        public void addCard(Card card)
        {
            hand.Add(card);
        }

        public void printHand()
        {
            Console.WriteLine("\nYou have: \n");
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
