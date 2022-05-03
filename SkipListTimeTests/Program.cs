using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkipList2020;

namespace SkipListTimeTests
{
    class Program
    {
        static void Main(string[] args)
        {
            SkipList<int, int> ownCollection = new SkipList<int, int>();
            SkipList<int, int> dummyCollection = new SkipList<int, int>();
            SortedList<int, int> mcCollection = new SortedList<int, int>();
            int n = 10000;
            var elements = GenerateRandomIntegers(n);
            var watch = new Stopwatch();
            for (int i = 0; i < n; i++)
                dummyCollection.Add(elements[i], 1);
            for (int i = 5000; i <7000; i++)
                dummyCollection.Remove(elements[i]);
            for (int i = 0; i < n; i++)
                dummyCollection.Contains(elements[i]);
            watch.Restart();
            for (int i = 0; i < n; i++)
            {
                mcCollection.Add(elements[i], elements[i]);
            }
            watch.Stop();
            Console.WriteLine($"MC sorted list add time:{watch.ElapsedMilliseconds}");

            watch.Restart();
            for (int i = 5000; i <= 7000; i++)
            {
                mcCollection.Remove(elements[i]);
            }
            watch.Stop();
            Console.WriteLine($"MC sorted list remove time:{watch.ElapsedMilliseconds}");

            watch.Restart();
            for (int i = 0; i < n; i++)
            {
                mcCollection.ContainsKey(elements[i]);
            }
            watch.Stop();
            Console.WriteLine($"MC sorted list find time:{watch.ElapsedMilliseconds}");

            watch.Restart();
            for (int i = 0; i < n; i++)
            {
                ownCollection.Add(elements[i], elements[i]);
            }
            watch.Stop();
            Console.WriteLine($"Skip list add time:{watch.ElapsedMilliseconds}");

            watch.Restart();
            for (int i = 5000; i <= 7000; i++)
            {
                ownCollection.Remove(elements[i]);
            }
            watch.Stop();
            Console.WriteLine($"Skip list remove time:{watch.ElapsedMilliseconds}");

            watch.Restart();
            for (int i = 0; i < n; i++)
            {
                ownCollection.Contains(elements[i]);
            }
            watch.Stop();
            Console.WriteLine($"Skip list find time:{watch.ElapsedMilliseconds}");


        }

        private static List<int> GenerateRandomIntegers(int count)
        {
            List<int> randomIntegers = new List<int>();
            Random random = new Random(DateTime.Now.Millisecond);

            while (randomIntegers.Count < count)
            {
                int newRandomInteger = random.Next(-2 * count, 2 * count);

                if (!randomIntegers.Contains(newRandomInteger))
                    randomIntegers.Add(newRandomInteger);
            }
            Console.WriteLine("Integers generated");
            return randomIntegers;
        }

    }
}
