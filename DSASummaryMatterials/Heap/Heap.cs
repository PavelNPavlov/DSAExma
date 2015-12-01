namespace Heap
{
    using System;
    using System.Collections.Generic;

    //source: http://allanrbo.blogspot.bg/2011/12/simple-heap-implementation-priority.html
    public class MinHeap<T> where T : IComparable
    {
        private List<T> data = new List<T>();

        public void Insert(T o)
        {
            data.Add(o);

            //Last Index, initial possition of added element
            int i = data.Count - 1;
            while (i > 0)
            {
                //Callculate location of parrent
                int j = (i + 1) / 2 - 1;

                //Parrent value
                T v = data[j];

                //See if parrent i smaller or eaqual to the newly added member
                if (v.CompareTo(data[i]) < 0 || v.CompareTo(data[i]) == 0)
                {
                    //If so element is in correct possition
                    break;
                }

                // Swap the elements when parrent is bigger than new element
                T tmp = data[i];
                data[i] = data[j];
                data[j] = tmp;

                // Set current index to that of former parrent possition
                i = j;
                // Repeat untill top is reached, or parrent is smaller
            }
        }

        public T ExtractMin()
        {
            if (data.Count < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            //Select first element
            T min = data[0];
            //Set last element as first
            data[0] = data[data.Count - 1];
            //Remove last element
            data.RemoveAt(data.Count - 1);
            //Heapfy the the list from the 0th element
            this.MinHeapify(0);
            //returnt the formaly first element
            return min;
        }

        public T Peek()
        {
            return data[0];
        }

        public int Count
        {
            get { return data.Count; }
        }

        //recursive heapify
        private void MinHeapify(int i)
        {
            //index of smallest od the two
            int smallest;
            int l = 2 * (i + 1) - 1;
            int r = 2 * (i + 1) - 1 + 1;

            //check if left child is smaller, if not set i index as min
            if (l < data.Count && (data[l].CompareTo(data[i]) < 0))
            {
                smallest = l;
            }
            else
            {
                smallest = i;
            }

            //Check if right child is smaller, if not set keep ith index as min
            if (r < data.Count && (data[r].CompareTo(data[smallest]) < 0))
            {
                smallest = r;
            }

            //if i is not the smallest swap with smallest index
            if (smallest != i)
            {
                T tmp = data[i];
                data[i] = data[smallest];
                data[smallest] = tmp;
                this.MinHeapify(smallest);
            }
        }
    }
}
