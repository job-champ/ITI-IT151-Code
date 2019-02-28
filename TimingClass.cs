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

class chapter1 
{
	static void Main() 
	{
		int[] nums = new int[100000];

		BuildArray(nums);

		Timing tObj = new Timing();

		tObj.startTime();

		DisplayNums(nums);

		tObj.stopTime();

		Console.WriteLine("time (.NET): " + tObj.Result());

		Console.WriteLine("IsHighResolution = " + Stopwatch.IsHighResolution);
	}

	static void BuildArray(int[] arr) 
	{
		for(int i = 0; i <= arr.GetUpperBound(0); i++)
			arr[i] = i;
	}

	static void DisplayNums(int[] arr) 
	{
		for(int i = 0; i <= arr.GetUpperBound(0); i++)
			Console.Write(arr[i] + " ");
	}	
}
