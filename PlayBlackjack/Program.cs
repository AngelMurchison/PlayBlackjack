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
        } // All suit values. There are 4.

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
        } // All rank values. There are 11.

        public class Card
        {
            public Suit Suit { get; set; }
            public Rank Rank { get; set; }

            public Card(Suit s, Rank r)
            {
                this.Suit = s;
                this.Rank = r;
            }

            public int GetCardValue()
            {
                var rv = 0;
                switch (this.Rank)
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

            public override string ToString()
            {
                return $"The {this.Rank} of {this.Suit}";
            }

        } /*  int GetCardValue() = rv
                              *  converting Card values into strings. */
        static void Main(string[] args)
        {
            // Deck and hands.
            var deck = new List<Card>();
            var playersHand = new List<Card>();
            var dealersHand = new List<Card>();

            // Make a fresh deck, stored in deck.
            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    deck.Add(new Card(s, r));
                }

            }
            // Randomize deck, stored in randomDeck
            var randomDeck = deck.OrderBy(x => Guid.NewGuid()).ToList();

            // Checking for accuracy.

            Console.WriteLine(randomDeck);
            randomDeck.ForEach(i => Console.Write("{0}\n", i));
            Console.ReadLine();
            Console.WriteLine($"{randomDeck.Count}");
            Console.ReadLine();
        }
    }
}
