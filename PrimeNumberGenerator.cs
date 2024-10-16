using System.Collections;

namespace MathCrap
{
    internal struct PrimeNumberGenerator() : IEnumerable<int>
    {
        int currentIndex { get; set; } = 0;

        public static IReadOnlyList<int> Cache => cache;

        static List<int> cache { get; }

        static PrimeNumberGenerator()
        {
            cache = [2, 3];
        }

        public IEnumerator<int> GetEnumerator()
        {
            int potentialNextPrime = 5;
            while (potentialNextPrime > 0)
            {
                if (currentIndex < cache.Count)
                {
                    yield return cache[currentIndex++];
                }
                else
                {
                    potentialNextPrime = cache[^1] + 2;
                    bool newPrimeFound = false;
                    while (!newPrimeFound)
                    {
                        int denominatorIndex = 2;
                        int denominator = 3;
                        int flooredSqrtOfPotentialNextPrime = (int)Math.Sqrt(potentialNextPrime);
                        while (denominator <= flooredSqrtOfPotentialNextPrime && potentialNextPrime % denominator != 0)
                        {
                            denominator = denominatorIndex < cache.Count ? cache[denominatorIndex++] : denominator + 2;
                        }
                        if (denominator > flooredSqrtOfPotentialNextPrime)
                        {
                            cache.Add(potentialNextPrime);
                            newPrimeFound = true;
                        }
                        else
                        {
                            potentialNextPrime += 2;
                        }
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
