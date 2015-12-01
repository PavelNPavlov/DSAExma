using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class FactorielExmaple
    {
        static long[] memo;

        static long RecursiveMethod(int member)
        {
            //bottom
            if (member == 1)
            {
                return 1;
            }
            //memo optimization
            if (memo[member] != 0)
            {
                return memo[member];
            }

            //recursiveBody
            long result = RecursiveMethod(member - 1) * member;

            //memorization
            memo[member] = result;

            return result;
        }

        static void Main(string[] args)
        {
            //input
            var numberOfMEmbers = 10;

            //init memorization array
            memo = new long[numberOfMEmbers];

            //call method for desired memeber
            Console.WriteLine(RecursiveMethod(5));

            GenerateCombinationsNoRepetitions(0, 0);

        }

        //Second example void, third exmaple is in tree class method dfs traversal
        const int n = 5;
        const int k = 3;
        static int[] arr = new int[k];
        static string[] objects = new string[n]
        {
        "banana", "apple", "orange", "strawberry", "raspberry"
        };

        static void GenerateCombinationsNoRepetitions(int index, int start)
        {
            //bottom
            if (index >= k)
            {
                PrintVariations();
            }
            //recursive body
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i;
                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }
        static void PrintVariations()
        {
            Console.Write("(" + String.Join(", ", arr) + ") --> ( ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(objects[arr[i]] + " ");
            }
            Console.WriteLine(")");
        }


    }
}
