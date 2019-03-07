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
	// Bubble Sort Algorithm
	public static void BubbleSort(int[] arr) 
	{
		int temp;

		for(int outer = arr.Length - 1; outer >= 1; outer--) 
		{
			for(int inner = 0; inner <= outer - 1; inner++)
				if ((int) arr[inner] > arr[inner + 1]) 
				{
					temp = arr[inner];
					arr[inner] = arr[inner + 1];
					arr[inner + 1] = temp;
				}
		//Console.WriteLine("During BubbleSort pass {0}: ", -1 * (outer - arr.Length - 1));
		//chapter1.DisplayNums(arr);
		}
		
	}
	
	// Selection Sort Algorithm
	public static void SelectionSort(int[] arr) 
	{
		int min, temp;
		for(int outer = 0; outer < arr.Length; outer++) 
		{
			min = outer;

			for(int inner = outer + 1; inner < arr.Length; inner++)
				if (arr[inner] < arr[min])
					min = inner;

			temp = arr[outer];
			arr[outer] = arr[min];
			arr[min] = temp;
		//Console.WriteLine("During SelectionSort pass {0}: ", outer + 1);
		//chapter1.DisplayNums(arr);
		}
	}
	
	// Insertion Sort algorithm
	public static void InsertionSort(int[] arr) 
	{
		int inner, temp;
		for(int outer = 1; outer < arr.Length; outer++)
		{
			temp = arr[outer];
			inner = outer;

			while(inner > 0 && arr[inner-1] >= temp) 
			{
				arr[inner] = arr[inner - 1];
				inner -= 1;
			}

			arr[inner] = temp;
		//Console.WriteLine("During InsertionSort pass {0}: ", outer);
		//chapter1.DisplayNums(arr);
		}
	}
	
	// Perform insertion sort on arr[]
	// Overloaded insertion sort to use with quick sort
	public static void InsertionSort(int[] arr, int low, int n)
	{
		// Start from second element (element at index 0
		// is already sorted)
		for (int i = low + 1; i <= n; i++)
		{
			int value = arr[i];
			int j = i;

			// Find the index j within the sorted subset arr[0..i-1]
			// where element arr[i] belongs
			while (j > low && arr[j - 1] > value)
			{
				arr[j] = arr[j - 1];
				j--;
			}
			// Note that subarray arr[j..i-1] is shifted to
			// the right by one position i.e. arr[j+1..i]

			arr[j] = value;

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
	
	static int quickSortCounter = 0;
	// Quick sort recursively on both sides of the pivot
	public static void QuickSort(int[] a, int low, int high)
	{
		// base condition
		if(low >= high)
			return;

		// rearrange the elements across pivot
		int pivot = Partition(a, low, high);
		
		// recurse on sub-array containing elements less than pivot
		QuickSort(a, low, pivot - 1);

		// recurse on sub-array containing elements more than pivot
		QuickSort(a, pivot + 1, high);

		//quickSortCounter++;

		//Console.WriteLine("During QuickSort pass {0}: ", quickSortCounter);
		//chapter1.DisplayNums(a);
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

	// Create two halves to sort
	public static void Merge(int[] input, int left, int middle, int right)
	{
	    int[] leftArray = new int[middle - left + 1];
	    int[] rightArray = new int[right - middle];
	 
	    Array.Copy(input, left, leftArray, 0, middle - left + 1);
	    Array.Copy(input, middle + 1, rightArray, 0, right - middle);
	 
	    int i = 0;
	    int j = 0;

	    for (int k = left; k < right + 1; k++)
	    {
		if (i == leftArray.Length)
		{
		    input[k] = rightArray[j];
		    j++;
		}
		else if (j == rightArray.Length)
		{
		    input[k] = leftArray[i];
		    i++;
		}
		else if (leftArray[i] <= rightArray[j])
		{
		    input[k] = leftArray[i];
		    i++;
		}
		else
		{
		    input[k] = rightArray[j];
		    j++;
		}
	    }
	}
 	
	static int mergeSortCounter = 0;
	// Merge the two halves back together recursively
	public static void MergeSort(int[] input, int left, int right)
	{
	    if (left < right)
	    {
		int middle = (left + right) / 2;
	 
		MergeSort(input, left, middle);
		MergeSort(input, middle + 1, right);
	 
		Merge(input, left, middle, right);
	    }

	    //mergeSortCounter++;
	    //Console.WriteLine("During Merge Sort pass {0}: ", mergeSortCounter);
	    //chapter1.DisplayNums(input);
	}    
 	
	// Merge the two halves back together recursively
	// Perform insertion sort on sub arrays of size 10 or smaller
	public static void optimizedMergeSort(int[] input, int left, int right)
	{
	    const int THRESHOLD = 10;

	    if (right - left <= THRESHOLD)
        	InsertionSort(input, left, right);
	    else
		    if (left < right)
		    {
			int middle = (left + right) / 2;
		 
			optimizedMergeSort(input, left, middle);
			optimizedMergeSort(input, middle + 1, right);
		 
			Merge(input, left, middle, right);


		    }
	}    
}

class chapter1 
{

      	// Class variables for generating random numbers
      	private static readonly Random random = new Random(); 
     	private static readonly object syncLock = new object(); 

	static void Main() 
	{
		int[] nums1 = new int[10000];

		loadArray(nums1);
		
		int[] nums2 = (int[]) nums1.Clone();

		int[] nums3 = (int[]) nums1.Clone();

		int[] nums4 = (int[]) nums1.Clone();

		int[] nums5 = (int[]) nums1.Clone();

		int[] nums6 = (int[]) nums1.Clone();

		int[] nums7 = (int[]) nums1.Clone();

		Timing tObj = new Timing();

		// Bubble Sort

		Console.WriteLine("Before Bubble Sort: ");

		DisplayNums(nums1);

		tObj.startTime();

		sortArray.BubbleSort(nums1);

		tObj.stopTime();

		string bubbleSortTime = tObj.Result().ToString();

		Console.WriteLine("After Bubble Sort: ");

		DisplayNums(nums1);

		Console.WriteLine();

		// Selection Sort

		Console.WriteLine("Before Selection Sort: ");

		DisplayNums(nums2);

		tObj.startTime();

		sortArray.SelectionSort(nums2);

		tObj.stopTime();

		string selectionSortTime = tObj.Result().ToString();

		Console.WriteLine("After Selection Sort: ");

		DisplayNums(nums2);

		Console.WriteLine();

		// Insertion Sort

		Console.WriteLine("Before Insertion Sort: ");

		DisplayNums(nums3);

		tObj.startTime();

		sortArray.InsertionSort(nums3);

		tObj.stopTime();

		string insertionSortTime = tObj.Result().ToString();

		Console.WriteLine("After Insertion Sort: ");

		DisplayNums(nums3);

		Console.WriteLine();

		// Quick Sort

		Console.WriteLine("Before Quick Sort: ");

		DisplayNums(nums4);

		tObj.startTime();

		sortArray.QuickSort(nums4, 0, nums4.Length - 1);

		tObj.stopTime();

		string quickSortTime = tObj.Result().ToString();

		Console.WriteLine("After Quick Sort: ");

		DisplayNums(nums4);

		Console.WriteLine();

		// Quick Sort with Insertion Sort and Tail recursion enhancehments

		Console.WriteLine("Before Optimized Quick Sort: ");

		DisplayNums(nums5);

		tObj.startTime();

		sortArray.optimizedQuickSort(nums5, 0, nums5.Length - 1);

		tObj.stopTime();

		string optimizedquickSortTime = tObj.Result().ToString();

		Console.WriteLine("After Optimized Quick Sort: ");

		DisplayNums(nums5);

		Console.WriteLine();

		// Merge Sort

		Console.WriteLine("Before Merge Sort: ");

		DisplayNums(nums6);

		tObj.startTime();

		sortArray.MergeSort(nums6, 0, nums6.Length - 1);

		tObj.stopTime();

		string mergeSortTime = tObj.Result().ToString();

		Console.WriteLine("After Merge Sort: ");

		DisplayNums(nums6);

		Console.WriteLine();

		// Optimized Merge Sort

		Console.WriteLine("Before Optimized Merge Sort: ");

		DisplayNums(nums7);

		tObj.startTime();

		sortArray.optimizedMergeSort(nums7, 0, nums7.Length - 1);

		tObj.stopTime();

		string optimizedMergeSortTime = tObj.Result().ToString();

		Console.WriteLine("After Optimized Merge Sort: ");

		DisplayNums(nums7);

		Console.WriteLine();

		Console.WriteLine("Time of Bubble Sort (.NET): " + bubbleSortTime);

		Console.WriteLine("Time of Selection Sort (.NET): " + selectionSortTime);

		Console.WriteLine("Time of Insertion Sort (.NET): " + insertionSortTime);

		Console.WriteLine("Time of Quick Sort (.NET): " + quickSortTime);

		Console.WriteLine("Time of Optimized Quick Sort (.NET): " + optimizedquickSortTime);

		Console.WriteLine("Time of Merge Sort (.NET): " + mergeSortTime);

		Console.WriteLine("Time of Optimized Merge Sort (.NET): " + optimizedMergeSortTime);

		Console.ReadKey();

		//Console.WriteLine("IsHighResolution = " + Stopwatch.IsHighResolution);
	}

	public static void BuildArray(int[] arr) 
	{
		for(int i = 0; i < arr.Length; i++)
			arr[i] = i;
	}

	public static void DisplayNums(int[] arr) 
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

}
