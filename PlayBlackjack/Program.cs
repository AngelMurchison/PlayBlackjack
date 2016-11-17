using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayBlackjack
{

    class Program
    {
        // Functions for hitting and printing. Might consolidate, might need to remake
        // with new understanding of pre-written code.
        public static List<int> HitMe(List<int> hitHand, List<string> randomDeck)
        {
            int newCard = 0;
            randomDeck.ToString();
            int.TryParse(randomDeck.First(), out newCard);
            hitHand.Add(newCard);
            return hitHand;
        }

        public static int PrintTotal(List<int> hand)
        {
            Console.WriteLine(hand.Sum());
            return hand.Sum();
        }
        //

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
            
            // Creates a method for finding the Blackjack value of a card
            // Based on its rank.
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
        } // Card.toString
                             // Card.GetCardValue


        static void Main(string[] args)
        {
            // Declaring variables, deck and hands. //

            var deck = new List<Card>();
            var playersHand = new List<Card>();
            var dealersHand = new List<Card>();

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

            // Need to print rules and put randomDeck[0, 1] into playersHand;
            // [3, 4] into dealersHand.

            Console.WriteLine("Lets play Blackjack!");

            
            // Debugging.
            randomDeck.ForEach(i => Console.Write("{0}\n", i));
            Console.ReadLine();
            Console.WriteLine($"{randomDeck.Count}");
            Console.ReadLine();
            Console.WriteLine(randomDeck[0].GetCardValue());
            Console.ReadLine();
        }
    }
}
