using System;
using System.Diagnostics;

public class Timing 
{
	//TimeSpan startingTime;
	//TimeSpan duration;
	
	static Stopwatch timer = new Stopwatch();

	public Timing() 
	{
		//startingTime = new TimeSpan(0);
		//duration = new TimeSpan(0);
	}

	public void stopTime() 
	{
		timer.Stop(); //Stop timer
		//duration = Process.GetCurrentProcess().UserProcessorTime.CurrentThread.Subtract(startingTime);
		//duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(startingTime);
	}

	public void startTime() 
	{
		GC.Collect();
		GC.WaitForPendingFinalizers();
		timer.Reset(); //reset timer to 0
  		timer.Start(); //start timer
		//startingTime = Process.GetCurrentProcess().CurrentThread.UserProcessorTime;
		//startingTime = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
	}

	public TimeSpan Result() 
	{
		//get time elapsed in seconds
  		return TimeSpan.FromSeconds(timer.Elapsed.TotalSeconds);

		//return duration;
	}
}

class sortArray
{
	
	
	// Perform insertion sort on arr[]
	// Overloaded insertion sort to use with quick sort
	public static void InsertionSort(int[] arr, int low, int n)
	{
		// Start from second element (element at index 0
		// is already sorted)
		for (int i = low + 1; i <= n; i++)
		{
			int val = arr[i];
			int j = i;

			// Find the index j within the sorted subset arr[0..i-1]
			// where element arr[i] belongs
			while (j > low && arr[j - 1] > val)
			{
				arr[j] = arr[j - 1];
				j--;
			}
			// Note that subarray arr[j..i-1] is shifted to
			// the right by one position i.e. arr[j+1..i]

			arr[j] = val;

			//Console.WriteLine("Using Insertion Sort pass {0}: ", i);
			//chapter1.DisplayNums(arr);
		}
	}
	
	// Partition data around a pivot for the quicksort algorithm
	// to recurse around
	public static int Partition (int[] a, int low, int high)
	{
		// Pick the rightmost element as pivot from the array
		int pivot = a[high];

		// elements less than pivot will be pushed to the left of pIndex
		// elements more than pivot will be pushed to the right of pIndex
		// equal elements can go either way
		int pIndex = low;

		// each time we find an element less than or equal to pivot,
		// pIndex is incremented and that element would be placed 
		// before the pivot.
		for (int i = low; i < high; i++)
		{
			if (a[i] <= pivot)
			{
				int temp = a[i];
				a[i] = a[pIndex];
				a[pIndex] = temp;

				pIndex++;
			}
		}

		// swap pIndex with Pivot
		int temp2 = a[high];
		a[high] = a[pIndex];
		a[pIndex] = temp2;

		// return pIndex (index of pivot element)
		return pIndex;
	}
	
	// Add insertion sort for subproblems of 10 or smaller
	public static void optimizedQuickSort(int[] A, int low, int high)
	{
		const int THRESHOLD = 10;

		while (low < high)
		{
			// do insertion sort if 10 or smaller
			if(high - low <= THRESHOLD)
			{
				InsertionSort(A, low, high);
				break;
			}
			else
			{
				int pivot = Partition(A, low, high);

				// tail call optimizations - recurse on smaller sub-array
				if (pivot - low < high - pivot) {
					optimizedQuickSort(A, low, pivot - 1);
					low = pivot + 1;
				} else {
					optimizedQuickSort(A, pivot + 1, high);
					high = pivot - 1;
				}

			}
			

		}

	}

}

class chapter4
{

      	// Class variables for generating random numbers
      	private static readonly Random random = new Random(); 
     	private static readonly object syncLock = new object(); 

	static void Main() 
	{
		int[] nums1 = new int[10000];

		int searchNumber;

		bool isInputNumeric;

		// Load Array with random integers

		loadArray(nums1);
		
		Timing tObj = new Timing();

		Timing tObj2 = new Timing();

		DisplayArray(nums1);

		//Console.WriteLine(nums1[nums1.Length - 1]);

		while(true)
		{

			Console.WriteLine("Please enter a number to search for.");

			isInputNumeric = Int32.TryParse(Console.ReadLine(), out searchNumber);

			if(isInputNumeric == true)
				 break;
			else
			 	 Console.WriteLine("You entered non numeric character(s). Please enter a numeric character to continue.");
						

		}
		
		tObj.startTime();

		if(SeqSearch(nums1, searchNumber) == true)
			Console.WriteLine("Sequential Search found {0} in the array!", searchNumber);
		else
			Console.WriteLine("Sequential Search did not find {0} in the array.", searchNumber);

		tObj.stopTime();
		
		string seqSearchTime = tObj.Result().ToString();

		Console.WriteLine("Time of Sequential Search (.NET): " + seqSearchTime);

		// Sort array with optimized quick sort before performing binary search

		sortArray.optimizedQuickSort(nums1, 0, nums1.Length - 1);

		tObj2.startTime();

		if(binSearch(nums1, searchNumber) == -1)
			Console.WriteLine("Binary Search did not find {0} in the array.", searchNumber);
		else
			Console.WriteLine("Binary Search found {0} in the array at position {1}!", searchNumber, binSearch(nums1, searchNumber));

		tObj2.stopTime();
		
		string binSearchTime = tObj2.Result().ToString();

		Console.WriteLine("Time of Binary Search (.NET): " + binSearchTime);

		Console.ReadKey();

		//Console.WriteLine("IsHighResolution = " + Stopwatch.IsHighResolution);
	}

	public static void BuildArray(int[] arr) 
	{
		for(int i = 0; i < arr.Length; i++)
			arr[i] = i;
	}

	public static void DisplayArray(int[] arr) 
	{
		for(int i = 0; i < arr.Length; i++)
			Console.Write(arr[i] + " ");
		Console.WriteLine("");
	}

	// This method loads up the array with random integers
      	public static void loadArray(int[] arr)
      	{
		int Min = 0;
		int Max = arr.Length * 10;

		for (int i = 0; i < arr.Length; i++)
		{

			int next = 0;
		        while (true)
            		{
				next = RandomNumber(Min, Max);
				if (!Contains(arr, next)) 
					break;                    
           		}

		    	arr[i] = next;	
        	}
        }

	//Function to get a random number 
        public static int RandomNumber(int min, int max)
        {
      		lock(syncLock) 
        	{ // synchronize
        	  return random.Next(min, max);
        	}
        }
	
	// Using this to get unique numbers into the array
	public static bool Contains(int[] array, int val)
    	{
		for (int i = 0; i < array.Length; i++)
		{
		    if (array[i] == val) 
			return true;
		}
		return false;
    	}

	public static bool SeqSearch(int[] arr, int sValue) 
	{
		for (int i = 0; i < arr.Length; i++)
			if (arr[i] == sValue)
				return true;

		return false;
	}

	public static int FindMin(int[] arr) 
	{
		int min = arr[0];
		for(int i = 1; i < arr.Length - 1; i++)
			if (arr[i] < min)
				min = arr[i];
			return min;
	}

	public static int FindMax(int[] arr) 
	{
		int max = arr[0];
		for(int i = 1; i < arr.Length - 1; i++)
			if (arr[i] > max)
				max = arr[i];
			return max;
	}

	public static int SeqSearchSelfOrdering(int[] arr, int sValue) 
	{
		for(int i = 0; i < arr.Length - 1; i++)
			if (arr[i] == sValue && i > (arr.Length * 0.2)) 
			{
				swap(ref arr[i], ref arr[i - 1]);
				return i;
			} else
			    if (arr[i] == sValue)
				return i;
		return -1;
	}

	public static int binSearch(int[] arr, int sValue) 
	{
		int upperBound, lowerBound, mid;
		upperBound = arr.Length - 1;
		lowerBound = 0;

		while(lowerBound <= upperBound) 
		{
			mid = (int)(upperBound + lowerBound) / 2;

			if (arr[mid] == sValue)
				return mid;
			else
			if (sValue < arr[mid])
				upperBound = mid - 1;
			else
				lowerBound = mid + 1;
		}
		return -1;
	}

	public int RbinSearch(int[] arr, int sValue, int lower, int upper)
	{
		if (lower > upper)
			return -1;
		else {
			int mid;
			mid = (int)(upper + lower) / 2;

			if (sValue < arr[mid])
				return RbinSearch(arr, sValue, lower, mid - 1);
			else if (sValue == arr[mid])
				return mid;
			else
				return RbinSearch(arr, sValue, mid + 1, upper);
		     }
	}

	public static void swap(ref int item1, ref int item2) 
	{
		int temp = item1;
		item1 = item2;
		item2 = temp;
	}
}
