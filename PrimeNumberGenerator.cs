using System.Collections;
using System.Numerics;

namespace MathCrap
{
    internal struct PrimeNumberGenerator<T>() : IReadOnlyList<T> where T : struct,
        IComparable,
        IConvertible,
        ISpanFormattable,
        IComparable<T>,
        IEquatable<T>,
        IBinaryInteger<T>,
        IMinMaxValue<T>,
        IUtf8SpanFormattable
    {
        static readonly List<ulong> cache = [2, 3];

        int IReadOnlyCollection<T>.Count => Count;

        public static int Count
        {
            get
            {
                int index = cache.FindIndex((ulong number) => number > T.MaxValue.ToUInt64(null));
                return index > 0 ? index : cache.Count;
            }
        }

        public T this[int index] => Get(index);

        public static T Get(int index) => T.CreateChecked(cache[index]);

        public IEnumerator<T> GetEnumerator()
        {
            ulong maxValue = T.MaxValue.ToUInt64(null);
            int currentIndex = 0;
            bool reachedLimit = false;
            while (!reachedLimit)
            {
                if (currentIndex < cache.Count)
                {
                    if (cache[currentIndex] <= maxValue)
                    {
                        yield return T.CreateChecked(cache[currentIndex++]);
                    }
                    else
                    {
                        reachedLimit = true;
                    }
                }
                else
                {
                    try
                    {
                        ulong potentialNextPrime = cache[^1] + 2;
                        bool newPrimeFound = false;
                        while (!newPrimeFound)
                        {
                            int denominatorIndex = 2;
                            ulong denominator = 3;
                            ulong flooredSqrtOfPotentialNextPrime = (ulong)Math.Sqrt(potentialNextPrime);
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
                                checked
                                {
                                    potentialNextPrime += 2;
                                }
                            }
                        }
                    }
                    catch (OverflowException)
                    {
                        reachedLimit = true;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
