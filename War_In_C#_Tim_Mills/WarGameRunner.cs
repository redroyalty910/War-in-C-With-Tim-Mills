using System;
using System.Collections.Generic;


/* Issues that I think I have:
 *  Games that exceed beyond like, thirty rounds are really REALLY boring and don't provide much entertainment value. Maybe I could implement a round limit?
 *  Other than that, this works. it works efficiently enough and it's War. it does everything that it was asked to do.
 */
namespace WarGame
{
    class WarGame
    {
        private Queue<Card> playerDeck;  // deck of the very good player
        private Queue<Card> computerDeck;// deck of the evil EVIL computer that we are playing against in the actual game
        private int roundCount;          // integer that keeps track of the various in-game rounds

        public WarGame()
        {
            Deck deck = new Deck();
            playerDeck = new Queue<Card>();
            computerDeck = new Queue<Card>();

            // split the fated deck into two halves and incorporate the queue functions that we learned in CS326 
            for (int i = 0; i < 26; i++)
            {
                playerDeck.Enqueue(deck.deal());
                computerDeck.Enqueue(deck.deal());
            }

            roundCount = 0; //default
        }

        public void Play()
        {
            Console.WriteLine("Welcome to Tim's official game of war project! You are Player 1, obviously. Why would you be anything but?"); //I tried to make the dialogue a LITTLE spicier because this is conceptually not that appealing to a regular fellow I think
            Console.WriteLine("\nGo ahead, press the fated 'Enter' key to absolutely lock in and enter a new stage of battle...");
            Console.ReadLine();

            while (playerDeck.Count > 0 && computerDeck.Count > 0)
            {
                roundCount++;
                Console.WriteLine($"\n--- Round: {roundCount} ---"); // displays the count of the overall rounds to this point in regular gameplay loop fashion
                Console.WriteLine($"YOU have {playerDeck.Count} cards | YOUR ENEMY has {computerDeck.Count} cards"); // displays card count between you and opponent

                PlayRound();
            }

            // determine the winner of the round
            if (playerDeck.Count == 0)
                Console.WriteLine("\nGame Over! THE ENEMY unfortunately happened to win the game.");
            else
                Console.WriteLine("\nCongratulations! You, the fated player, have won the war!");
        }

        private void PlayRound()
        {
            if (playerDeck.Count == 0 || computerDeck.Count == 0)
                return;

            Console.WriteLine("\nPress that 'enter' key to draw your card...");
            Console.ReadLine();

            Console.WriteLine("Drawing..."); // look how suspenseful
            Thread.Sleep(2000); // this equates to about a 2 second pause of suspense. I did it because it feels cool but maybe it's annoying to your average player, I don't know

            Card playerCard = playerDeck.Dequeue();
            Card aiCard = computerDeck.Dequeue();

            Console.WriteLine($"\nYOU play -----------------> {playerCard}");
            Console.WriteLine($"The EVIL ENEMY plays -----> {aiCard}");

            List<Card> warPile = new List<Card> { playerCard, aiCard };

            if (playerCard.getPointValue() > aiCard.getPointValue())
            {
                Console.WriteLine("\nYou win this round, my friend!");
                Console.WriteLine("\n----------------------------------------------------------------"); // little border that closes in each round and makes the user-interface more appealing
                AddCardsToDeck(playerDeck, warPile);
            }
            else if (aiCard.getPointValue() > playerCard.getPointValue())
            {
                Console.WriteLine("\nThat EVIL COMPUTER you're playing against wins this round, but don't give up! You lost the battle, but not the WAR!");
                Console.WriteLine("\n----------------------------------------------------------------");
                AddCardsToDeck(computerDeck, warPile);
            }
            else
            {
                Console.WriteLine("\nWAR!!!!!!!!!!!!!! ");
                Console.WriteLine("Press that 'enter' key to begin this battle...");
                Console.ReadLine();
                War(warPile);
            }
        }

        private void War(List<Card> warPile)
        {
            if (playerDeck.Count < 4 || computerDeck.Count < 4)
            {
                Console.WriteLine("\nHeh, looks like somebody doesn't have enough cards for the big war! ");
                if (playerDeck.Count < 4)
                {
                    Console.WriteLine("\nWhat happened man? You ran out of cards. Dude you totally blew it, this is a permanent loss. You lost the game man.");
                    playerDeck.Clear();
                }
                if (computerDeck.Count < 4)
                {
                    Console.WriteLine("\nReally sad day for EVIL COMPUTERS THAT ARE BAD AT GAMES!! YOU WIN, PLAYER!!!");
                    computerDeck.Clear();
                }
                return;
            }

            Console.WriteLine("\nThe two of you place 3 face-down cards for the sake of the war...");
            for (int i = 0; i < 3; i++)
            {
                warPile.Add(playerDeck.Dequeue()); 
                warPile.Add(computerDeck.Dequeue());
            }

            Console.WriteLine("\nPress that 'enter' key to draw your weapon...");
            Console.ReadLine();

            Card playerWarCard = playerDeck.Dequeue();
            Card aiWarCard = computerDeck.Dequeue();
            warPile.Add(playerWarCard);
            warPile.Add(aiWarCard);

            Console.WriteLine($"\nYour beautiful war card -----------------------> {playerWarCard}");
            Console.WriteLine($"This evil computer's less beautiful war card --> {aiWarCard}");

            if (playerWarCard.getPointValue() > aiWarCard.getPointValue())
            {
                Console.WriteLine("\nANOTHER DAY ANOTHER DOLLAR! YOU WON THE WAR!");
                Console.WriteLine("\n----------------------------------------------------------------");
                AddCardsToDeck(playerDeck, warPile);
            }
            else if (aiWarCard.getPointValue() > playerWarCard.getPointValue())
            {
                Console.WriteLine("\nComputer really put you in your place! You REALLY lost the war");
                Console.WriteLine("\n----------------------------------------------------------------");
                AddCardsToDeck(computerDeck, warPile);
            }
            else
            {
                Console.WriteLine("\nOh, oh, that's a tie! Yeah, no, this war continues...");
                Console.ReadLine();
                War(warPile);
            }
        }

        private void AddCardsToDeck(Queue<Card> playerDeck, List<Card> wonCards)
        {
            foreach (var card in wonCards)
            {
                playerDeck.Enqueue(card);
            }
        }

        static void Main(string[] args)
        {
            WarGame game = new WarGame();
            game.Play();
        }
    }
}
