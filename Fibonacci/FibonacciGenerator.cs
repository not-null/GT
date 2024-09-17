using System.Numerics;

namespace Fibonacci
{
    public class FibonacciGenerator
    {
        public static BigInteger GetNthFibonacciNumber(int n)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(n, 1);

            // a and b represents two subsequent values in a fib sequence. Eg. 0, 1, 1, a, b, 5...
            BigInteger a = 0, b = 1;

            while (--n > 1)
            {
                (a, b) = (b, a + b);
            }

            return b;
        }


        // Extra recursive solution that is cleaner, but not as performant
        public static BigInteger GetNthFibonacciNumberRec(int n)
        {
            // F(n) gives the (n+1)th number, so we need to subtract 1 (https://en.wikipedia.org/wiki/Fibonacci_sequence)
            return GetNthFibonacciNumberRecHelper(new BigInteger(n - 1));
        }

        private static BigInteger GetNthFibonacciNumberRecHelper(BigInteger n)
        {
            if (n == 0 || n == 1)
                return n;

            return GetNthFibonacciNumberRecHelper(n - 1) + GetNthFibonacciNumberRecHelper(n - 2);
        }
    }
}
