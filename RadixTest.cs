using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace csqueue
{
	public class RadixSort
	{
       enum DigitType {ones = 1, tens = 10}
        
	   public static void RSort(int[] target, int size, int n_digits)
       {

            Queue[] bins = new Queue[10];

            Console.WriteLine("in Radix.");
            n_digits=2;

            for(int d = 1; d <= n_digits; d++)
            {
               int pos;
               int tmp;

               Console.WriteLine("Sorting the "+ d + "-digit");

               for(int i=0; i<size; i++)
               {
                    tmp = target[i];

                    pos = ( (d == 1) ? tmp % 10 : tmp / 10 );
                   
                    bins[pos].Enqueue(tmp);
               }//for each item in target[]

               int j=0;

               for(int bin_num = 0; bin_num < 10; bin_num++)
                   while(bins[bin_num].Count > 0)
                    target[j++] = Int32.Parse(bins[bin_num].Dequeue().ToString());
            }
        }
        
        static void Main(string[] args)
        {
            //Queue [] numQueue = new Queue[10];
            int [] nums = new int[] {91, 46, 85, 15, 92, 35, 31, 22};
            
            // Display original list
            //for(int i = 0; i < 10; i++)
            //    numQueue[i] = new Queue();
            
            RSort(nums, nums.Length, (int) DigitType.ones);
            
            Console.WriteLine();
            Console.WriteLine("First pass results: ");
            DisplayArray(nums);
            
            // Second pass sort
            RSort(nums, nums.Length, (int) DigitType.tens);
            Console.WriteLine();
            Console.WriteLine("Second pass results: ");
            
            // Display final results
            DisplayArray(nums);
            Console.WriteLine();
            
            Console.Write("Press enter to quit");
            Console.ReadKey();
        }
        
        static void DisplayArray(int [] n)
        {
            for(int x = 0; x <= n.GetUpperBound(0); x++)
                Console.Write(n[x] + " ");
        }

	}
}
