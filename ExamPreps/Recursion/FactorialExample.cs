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

        }


    }
}
