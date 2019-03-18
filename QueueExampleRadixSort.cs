using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace csqueue
{
	public class RadixSort
	{
	    static void Main(string[] args)
        {
            SortArrayWithRadixSort();
        }
        
        private static void SortArrayWithRadixSort()
        {
            int[] array = { 7, 5, 3, 6, 76, 45, 32, 27, 21, 55, 31, 47, 86, 25, 2, 0, 1};
            
            DisplayArray(array);
            
            int[] sortedArray = RSort(array);
    
            DisplayArray(sortedArray);
        }
        
        public static int[] RSort(int[] array)
        {
            bool isFinished = false;
            int digitPosition = 0;
    
            List<Queue<int>> buckets = new List<Queue<int>>();
            InitializeBuckets(buckets);
    
            while (!isFinished)
            {
                isFinished = true;
    
                foreach (int value in array)
                {
                    int bucketNumber = GetBucketNumber(value, digitPosition);
                    if (bucketNumber > 0)
                    {
                        isFinished = false;
                    }
    
                    buckets[bucketNumber].Enqueue(value);
                }
    
                int i = 0;
                foreach (Queue<int> bucket in buckets)
                {
                    while (bucket.Count > 0)
                    {
                        array[i] = bucket.Dequeue();
                        i++;
                    }
                }
    
                digitPosition++;
            }
    
            return array;
        }
    
        private static int GetBucketNumber(int value, int digitPosition)
        {
            int bucketNumber = (value / (int)Math.Pow(10, digitPosition)) % 10;
            return bucketNumber;
        }
    
        private static void InitializeBuckets(List<Queue<int>> buckets)
        {
            for (int i = 0; i < 10; i++)
            {
                Queue<int> q = new Queue<int>();
                buckets.Add(q);
            }
        }
        
        static void DisplayArray(int[] n)
        {
            for(int x = 0; x <= n.GetUpperBound(0); x++)
                Console.Write(n[x] + " ");
            
            Console.WriteLine();
        }

	}
}
