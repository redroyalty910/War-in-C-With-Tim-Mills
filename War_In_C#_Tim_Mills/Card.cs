using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame // this was the class we were intended to use from class
{
    internal class Card
    {

        private String suit;
        private String rank;
        private int pointValue;

        public Card(String s, String r, int pV)
        {
            this.suit = s;
            this.rank = r;
            this.pointValue = pV;
        }

        public String getSuit() { return suit; }
        public String getRank() { return rank; }
        public int getPointValue() { return pointValue; }
        public void setPointValue(int val) { pointValue = val; }    //should only be used for aces.

        public override string ToString()
        {
            return rank + " of " + suit + ": " + pointValue;
        }

    }
}
