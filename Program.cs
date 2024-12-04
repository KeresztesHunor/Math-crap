namespace MathCrap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*PrimeNumberGenerator<sbyte> primes = new PrimeNumberGenerator<sbyte>();
            foreach (sbyte prime in primes)
            {
                Console.WriteLine(prime);
            }*/
            Console.WriteLine(IsContradiction(3, (bool[] inputs) => !(inputs[0] && inputs[1]),
                (bool[] inputs) => (inputs[0] && inputs[1]).Then(!inputs[2]),
                (bool[] inputs) => !inputs[1],
                (bool[] inputs) => inputs[0].Then(inputs[2]),
                (bool[] inputs) => (inputs[0] || inputs[1]).Then(inputs[2])
            ));
            Console.ReadLine();
        }

        static bool IsContradiction(int numVariables, Func<bool[], bool> conclusion, params Func<bool[], bool>[] predicates)
        {
            if (predicates.Length == 0)
            {
                return false;
            }
            int numCombinations = 2.Pow(numVariables);
            bool[] inputs = new bool[numVariables];
            bool contradiction = false;
            int i = 0;
            while (i++ < numCombinations && !contradiction)
            {
                int ii = 0;
                while (ii < predicates.Length && predicates[ii](inputs))
                {
                    ii++;
                }
                if (ii >= predicates.Length && !conclusion(inputs))
                {
                    contradiction = true;
                }
                else
                {
                    int iii = 0;
                    bool carry = true;
                    while (iii < inputs.Length && carry)
                    {
                        inputs[iii] = !inputs[iii];
                        carry = !inputs[iii++];
                    }
                }
            }
            return contradiction;
        }
    }
}
