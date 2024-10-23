namespace MathCrap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrimeNumberGenerator<sbyte> primes = new PrimeNumberGenerator<sbyte>();
            foreach (sbyte prime in primes)
            {
                Console.WriteLine(prime);
            }
            Console.ReadLine();
        }
    }
}
