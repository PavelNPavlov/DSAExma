using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationVariationPetrubations
{
    using System;
    using System.Numerics;

    class BinaryTreesExample
    {
        static int[] balls;
        static int count;
        static BigInteger[] factorials;
        static BigInteger[] memo;

        static BigInteger TreeVariation(int n)
        {
            //bottme of recursion
            if (n == 0)
            {
                return 1;
            }
            //memo optimization
            if (memo[n] != 0)
            {
                return memo[n];
            }

            BigInteger result = 0;

            for (int i = 0; i < n; i++)
            {
                result += TreeVariation(i) * TreeVariation(n - i - 1);
            }
            memo[n] = result;
            return result;
        }

        static void Main()
        {
            //read input;
            var input = Console.ReadLine();

            //static initializations
            count = input.Length;
            balls = new int[26];
            factorials = new BigInteger[count + 1];
            memo = new BigInteger[count + 1];

            for (int i = 0; i < count; i++)
            {
                var index = input[i] - 'A';
                balls[index]++;
            }

            //Facotiral Calculations
            Factoriel();
            
            //Dived and conquer Approach

            //Callculate different combination of collors as a sqeunce
            var colorCombinations = Combinations();
            //Callculate different ways to distribute nodes in a tree
            var TreeCombinations = TreeVariation(count);
            var result = Combinations() * TreeVariation(count);

            //result printing
            Console.WriteLine(result);
        }

        static BigInteger Combinations()
        {
            var result = factorials[count];

            foreach (var item in balls)
            {
                result /= factorials[item];
            }

            return result;
        }

        static void Factoriel()
        {
            factorials[0] = 1;

            for (int i = 1; i <= count; i++)
            {
                factorials[i] = factorials[i - 1] * i;
            }
        }
    }
}
