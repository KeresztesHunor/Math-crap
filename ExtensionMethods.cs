using System.Numerics;

namespace MathCrap
{
    internal static class ExtensionMethods
    {
        public static T Pow<T>(this T num, int exp) where T : struct, IBinaryInteger<T>
        {
            T result = T.MultiplicativeIdentity;
            for (int i = 0; i < exp; i++)
            {
                result *= num;
            }
            return result;
        }

        public static bool Then(this bool a, bool b) => a ? b : true;
    }
}
