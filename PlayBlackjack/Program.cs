using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayBlackjack
{

    class Program
    {
        public enum Suit
        {
            Hearts,
            Clubs,
            Diamonds,
            Spades
        } // All suits. There are 4.

        public enum Rank
        {
            Ace,
            Deuce,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        } // All ranks. There are 13.

        public class Card
        {
            // allows for suit and rank to have values applied to them. (inherently hardcoded int)
            public Suit suit { get; set; }
            public Rank rank { get; set; }

            // creates a variable that = each individual suit or rank
            public Card(Suit s, Rank r)
            {
                this.suit = s;
                this.rank = r;
            }

            // Creates a string value for each Card.
            public override string ToString()
            {
                return $"The {this.rank} of {this.suit}";
            }

            // Method for getting a single cards Blackjack value. Called with Card.GetCardValue
            public int GetCardValue()
            {
                var rv = 0;
                switch (this.rank)
                {
                    case Rank.Ace:
                        rv = 11;
                        break;
                    case Rank.Deuce:
                        rv = 2;
                        break;
                    case Rank.Three:
                        rv = 3;
                        break;
                    case Rank.Four:
                        rv = 4;
                        break;
                    case Rank.Five:
                        rv = 5;
                        break;
                    case Rank.Six:
                        rv = 6;
                        break;
                    case Rank.Seven:
                        rv = 7;
                        break;
                    case Rank.Eight:
                        rv = 8;
                        break;
                    case Rank.Nine:
                        rv = 9;
                        break;
                    case Rank.Ten:
                        rv = 10;
                        break;
                    case Rank.Jack:
                        rv = 10;
                        break;
                    case Rank.Queen:
                        rv = 10;
                        break;
                    case Rank.King:
                        rv = 10;
                        break;
                    default:
                        break;
                }
                return rv;

            }

            // Method for hitting.
            public static void Hit(List<Card> randomDeck, List<Card> Hand)
            {
                Hand.Insert(0, randomDeck[0]);
                Hand.ForEach(i => Console.Write("\n{0}\n", i));
                randomDeck.RemoveAt(0);
            }

            static void Main(string[] args)
            {
                // Declaring variables for deck, hands, and hand values. //
                var deck = new List<Card>();
                var playersHand = new List<Card>();
                var dealersHand = new List<Card>();
                int playersTotal = 0;
                int dealersTotal = 0;
                bool stay = false;

                // Make a fresh deck.
                foreach (Rank r in Enum.GetValues(typeof(Rank)))
                {
                    foreach (Suit s in Enum.GetValues(typeof(Suit)))
                    {
                        deck.Add(new Card(s, r));
                    }

                }
                // Shuffling deck.
                var randomDeck = deck.OrderBy(x => Guid.NewGuid()).ToList();

                // Game start.
                Console.WriteLine("We're gonna play Blackjack. Get as close to 21 points as you can, but don't go over! \nI'm going to deal you two cards now.");
                {   // Deal to player.
                    playersHand.Insert(0, randomDeck[0]);
                    playersHand.Insert(0, randomDeck[1]);
                    int cv = playersHand[0].GetCardValue() + playersHand[1].GetCardValue();
                    playersTotal = playersTotal + cv;
                    randomDeck.RemoveAt(0);
                    randomDeck.RemoveAt(0);
                    playersHand.ForEach(i => Console.Write("{0}\n", i));
                    Console.WriteLine(playersTotal);
                }
                Console.ReadLine();
                Console.WriteLine("The dealer gets two cards as well, but he's only going to show you one of them.");
                {   // Deal to dealer.
                    dealersHand.Insert(0, randomDeck[0]);
                    dealersHand.ForEach(i => Console.Write("{0}\n", i));
                    dealersHand.Insert(0, randomDeck[1]);
                    int dv = dealersHand[0].GetCardValue() + dealersHand[1].GetCardValue();
                    dealersTotal = dealersTotal + dv;
                    randomDeck.RemoveAt(1);
                    randomDeck.RemoveAt(0);
                }
                Console.ReadLine();
                Console.WriteLine("Remember! Aces are always worth 11. \nPress H to hit or S to stay! Lets play Blackjack!");
                // ^^^^ consolidate this shit. //

                playersHand.ForEach(i => Console.Write("{0}\n", i));


                // Players turn to hit and stay.
                while (playersTotal < 21)
                {
                    if (playersTotal < 21 && Console.ReadKey().Key == ConsoleKey.S)
                    {
                        Console.WriteLine("\nAlright, then its the dealer's turn.");
                        Console.ReadLine();
                        stay = true;
                        break;
                    }
                    else if (playersTotal < 21 && Console.ReadKey().Key == ConsoleKey.H)
                    {
                        Card.Hit(randomDeck, playersHand);
                        int cv = playersHand[0].GetCardValue();
                        playersTotal = playersTotal + cv;
                        Console.WriteLine($"\nYour hand is worth {playersTotal}.");
                        ;
                    }
                    
                }

                // Players gets 21 or busts.
                if (playersTotal > 21)
                {
                    Console.WriteLine("You lose!");
                    Console.ReadLine();

                }
                else if (playersTotal == 21)
                {
                    Console.WriteLine("You win!");
                    Console.ReadLine();
                }

                // Dealers turn to hit until his hand is worth 15 points.
                while (dealersTotal < 15 && playersTotal < 21)
                {
                    Card.Hit(randomDeck, dealersHand);
                    int dv = dealersHand[0].GetCardValue();
                    dealersTotal = dealersTotal + dv;
                    Console.WriteLine($"The dealers hand is worth {dealersTotal}.");
                    Console.ReadLine();
                }
                if (dealersTotal > 21 && playersTotal < 21)
                {
                    Console.WriteLine($"The dealers hand is worth {dealersTotal} and yours is worth {playersTotal}. \nYou win!");
                    Console.ReadLine();
                }
                if (dealersTotal < playersTotal && playersTotal < 21)
                {
                    Console.WriteLine($"The dealers hand is worth {dealersTotal} and yours is worth {playersTotal}. \nYou win!");
                    Console.ReadLine();
                }
                if ((dealersTotal > playersTotal && dealersTotal < 21) && playersTotal < 21)
                {
                    Console.WriteLine($"The dealers hand is worth {dealersTotal} and yours is worth {playersTotal}.\n You lose!");
                    Console.ReadLine();
                }

            }
        }
    }
}

