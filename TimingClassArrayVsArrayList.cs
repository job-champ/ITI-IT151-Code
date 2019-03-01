using System;
using System.Diagnostics;
using System.Collections;

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
        int[] nums = new int[10000000];

        ArrayList A = new ArrayList();

        Timing tObj = new Timing();

        tObj.startTime();

        BuildArray(nums);

        //DisplayNums(nums);

        tObj.stopTime();

        string timeOfArray = tObj.Result().ToString();

        tObj.startTime();

        BuildArrayList(A);

        //DisplayArrayList(A);

        tObj.stopTime();

        Console.WriteLine("Time of Array (.NET): " + timeOfArray);

        Console.WriteLine("Time of ArrayList (.NET): " + tObj.Result());

        Console.WriteLine("IsHighResolution = " + Stopwatch.IsHighResolution);

        Console.ReadKey();
    }

    static void BuildArray(int[] arr)
    {
        for (int i = 0; i <= arr.GetUpperBound(0); i++)
            arr[i] = i;
    }

    static void DisplayNums(int[] arr)
    {
        for (int i = 0; i <= arr.GetUpperBound(0); i++)
            Console.Write(arr[i] + " ");
    }

    static void BuildArrayList(ArrayList A)
    {
        for(int i = 0; i < 10000000; i++)
        {
            A.Add(i);
        }
    }

    static void DisplayArrayList(ArrayList A)
    {
        foreach(int i in A)
            Console.Write(i + " ");
    }
}
