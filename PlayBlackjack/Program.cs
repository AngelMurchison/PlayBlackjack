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
                Hand.ForEach(i => Console.Write("{0}\n", i));
                randomDeck.RemoveAt(0);
            }

            // Method for dealing. Currently unused
            public static void Deal(List<Card> randomDeck, List<Card> Hand)
            {
                Hand.Insert(0, randomDeck[0]);
                Hand.Insert(0, randomDeck[1]);
                Hand.ForEach(i => Console.Write("{0}\n", i));
                randomDeck.RemoveAt(0);
                randomDeck.RemoveAt(1);
            }



            /* public static void PrintTotal(List<Card> hand)
               {
                   hand[0].GetCardValue();
                   Hand.ForEach(i => Hand[i].GetCardValue());
               } Shelved for now */

        }

        static void Main(string[] args)
        {
            // Declaring variables, deck and hands. //
            var deck = new List<Card>();
            var playersHand = new List<Card>();
            var dealersHand = new List<Card>();
            int playersTotal = 0;
            int dealersTotal = 0;

            // Make a fresh deck, stored in deck.
            // For each rank r, attach each suit s
            // add all the cards you made to the list deck
            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    deck.Add(new Card(s, r));
                }

            }
            // Shuffling deck, stored in randomDeck //
            var randomDeck = deck.OrderBy(x => Guid.NewGuid()).ToList();

            // Game start.
            Console.WriteLine("We're gonna play Blackjack. Get as close to 21 points as you can, but don't go over!");
            Console.WriteLine("I'm going to deal you two cards now.");
            {   // deal for player.
                playersHand.Insert(0, randomDeck[0]);
                int cv0 = playersHand[0].GetCardValue();
                playersHand.Insert(0, randomDeck[1]);
                int cv1 = playersHand[0].GetCardValue() + cv0;
                playersTotal = playersTotal + cv1;

                playersHand.ForEach(i => Console.Write("{0}\n", i));
                Console.WriteLine(playersTotal);
                randomDeck.RemoveAt(0);
                randomDeck.RemoveAt(1);
            }
            Console.ReadLine();
            Console.WriteLine("The dealer gets two cards as well, but he's only going to show you one of them.");
            {   // deal for dealer.
                dealersHand.Add(randomDeck[0]);
                dealersHand.ForEach(i => Console.Write("{0}\n", i));
                int cv = dealersHand[0].GetCardValue();
                dealersHand.Add(randomDeck[1]);
                randomDeck.RemoveAt(0);
                randomDeck.RemoveAt(1);
            }
            Console.ReadLine();
            Console.WriteLine("Remember! Aces are always worth 11.");
            Console.WriteLine("Lets play Blackjack!");
            Console.ReadLine();

            // ^^^^ consolidate this shit. //

            // Create a control flow.
            playersHand.ForEach(i => Console.Write("{0}\n", i));
            Console.WriteLine("Will you [H]it or [S]tay?");
            while (playersTotal < 21)
            {
                if (Console.ReadKey().Key == ConsoleKey.H)
                {
                    Card.Hit(randomDeck, playersHand);
                    int cv = playersHand[0].GetCardValue();
                    playersTotal = playersTotal + cv;
                    Console.WriteLine($"{playersTotal}");
                }
                else if (Console.ReadKey().Key == ConsoleKey.S)
                {
                    break;
                }
                else
                {

                }
            }
            Console.Clear();





            //Card.Hit(randomDeck, dealersHand);
            //Card.Hit(randomDeck, dealersHand);

            //Debugging.
            //randomDeck.ForEach(i => Console.Write("{0}\n", i));
            //Console.WriteLine($"{randomDeck.Count}");
            //Console.ReadLine();
            //Console.WriteLine(randomDeck[0].GetCardValue());
            //Console.ReadLine();
            //randomDeck.RemoveAt(0);
            //randomDeck.ForEach(i => Console.Write("{0}\n", i));
            //Console.ReadLine();
            //Console.WriteLine($"{randomDeck.Count}");
            Console.ReadLine();
        }
    }
}
