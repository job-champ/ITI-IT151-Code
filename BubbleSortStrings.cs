using System;
using System.Text;
	
class sortStringArray
{
	// Class variables for generating random numbers
      	private static readonly Random random = new Random(); 
     	private static readonly object syncLock = new object(); 

	static void Main() 
	{
		string[] alpha = new string[100];

		BuildArray(alpha);

		DisplayArray(alpha);

		BubbleSort(alpha);

		Console.WriteLine();
		
		Console.WriteLine();

		DisplayArray(alpha);

		Console.ReadKey();

	}

	// Bubble Sort Algorithm string edition
	public static void BubbleSort(string[] arr) 
	{
		string temp;

		for(int outer = arr.Length - 1; outer >= 1; outer--) 
		{
			for(int inner = 0; inner <= outer - 1; inner++)
				if (arr[inner].CompareTo(arr[inner + 1]) == 1) 
				{
					temp = arr[inner];
					arr[inner] = arr[inner + 1];
					arr[inner + 1] = temp;
				}
		}
	}

	// Build array with different size random strings from 
	// small subset of ASCII strings
	static void BuildArray(string[] arr) 
	{

		for(int i = 0; i < 100; i++)
		{
			if(i % 3 == 0)
				arr[i] = RandomString(3);
			else if(i % 4 == 0) 
				arr[i] = RandomString(4);
			else if (i % 5 == 0)
				arr[i] = RandomString(5);
			else 
				arr[i] = RandomString(2);
		}
	}

	// Method to generate random strings from a pool
	public static string RandomString(int length)
	{
	    const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
	    var builder = new StringBuilder();

	    for (var i = 0; i < length; i++)
	    {
		var c = pool[RandomNumber(0, pool.Length)];
		builder.Append(c);
	    }

	    return builder.ToString();
	}

	// Display Method
	static void DisplayArray(string[] arr) 
	{
		for(int i = 0; i < arr.Length; i++)
			Console.Write(arr[i] + " ");
		Console.WriteLine("");
	}

	//Function to get a random number 
        public static int RandomNumber(int min, int max)
        {
      		lock(syncLock) 
        	{ // synchronize
        	  return random.Next(min, max);
        	}
        }
}


