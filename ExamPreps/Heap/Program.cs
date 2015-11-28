using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 1, 5, 2, 14, 5, 1, 0 };

            var heap = new MinHeap<int>();

            foreach (var item in numbers)
            {
                heap.Insert(item);
            }

            while (heap.Count>0)
            {
                Console.WriteLine(heap.ExtractMin());
            }
        }
    }
}
