using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Console_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //var startingDeck = from s in Suits()
            //                   from r in Ranks()
            //                   select new { Suit = s, Rank = r };

            //等同于

            //var startingDeck = Suits().SelectMany(suit => Ranks().Select(rank => new { Suit = suit, Rank = rank }));

            //foreach (var card in startingDeck)
            //{
            //    Console.WriteLine(card);
            //}

            // 52 cards in a deck, so 52 / 2 = 26
            //var top = startingDeck.Take(26);
            //var bottom = startingDeck.Skip(26);

            //var shuffle = top.InterleaveSequenceWith(bottom);

            //foreach (var c in shuffle)
            //{
            //    Console.WriteLine(c);
            //}

            //var timers = 0;
            //var shuffle = startingDeck;
            //do
            //{
            //    //shuffle = shuffle.Take(26).InterleaveSequenceWith(shuffle.Skip(26));
            //    shuffle = shuffle.Skip(26).InterleaveSequenceWith(shuffle.Take(26));

            //    foreach (var card in shuffle)
            //    {
            //        Console.WriteLine(card);
            //    }
            //    Console.WriteLine();
            //    timers++;
            //} while (!startingDeck.SequenceEquals(shuffle));

            //Console.WriteLine(timers);


            var startingDeck = (from s in Suits().LogQuery("Suit Generation")
                                from r in Ranks().LogQuery("Rank Generation")
                                select new { Suit = s, Rank = r }).LogQuery("Starting Deck").ToArray();

            foreach (var c in startingDeck)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine();


            var times = 0;
            var shuffle = startingDeck;

            do
            {
                //向内洗牌
                shuffle = shuffle.Skip(26).LogQuery("Bottom Half").InterleaveSequenceWith(shuffle.Take(26).LogQuery("Top Half")).LogQuery("Shuffle").ToArray();
                //向外洗牌
                //shuffle = shuffle.Take(26).LogQuery("Bottom Half").InterleaveSequenceWith(shuffle.Skip(26).LogQuery("Top Half")).LogQuery("Shuffle").ToArray();
                foreach (var c in shuffle)
                {
                    Console.WriteLine(c);
                }

                times++;
                Console.WriteLine(times);

            } while (!startingDeck.SequenceEquals(shuffle));
        }

        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamands";
            yield return "hearts";
            yield return "spades";

        }
        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }
    }

    public static class Extensions
    {
        public static IEnumerable<T> InterleaveSequenceWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            // Your implementation will go here soon enough

            var firstIter = first.GetEnumerator();
            var secondIter = second.GetEnumerator();

            while (firstIter.MoveNext() && secondIter.MoveNext())
            {
                yield return firstIter.Current;
                yield return secondIter.Current;
            }
        }

        public static bool SequenceEquals<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstIter = first.GetEnumerator();
            var secondIter = second.GetEnumerator();

            while (firstIter.MoveNext() && secondIter.MoveNext())
            {
                if (!firstIter.Current.Equals(secondIter.Current))
                {
                    return false;
                }
            }
            return true;
        }

        public static IEnumerable<T> LogQuery<T>(this IEnumerable<T> sequence, string tag)
        {
            using (var writer=File.AppendText("debug.log"))
            {
                writer.WriteLine($"Executing Query {tag}");
            }
            return sequence;
        }
    }
}
