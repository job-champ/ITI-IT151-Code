using System;
using System.Collections;
using System.IO;

// ArrayList Example
namespace Main
{

    class ArrayListWork
    {

        public static void Main(string[] args)
        {
            ArrayList stopWordList = new ArrayList();

            LoadArrayList(stopWordList);

            PrintArrayList(stopWordList);

            CopyToArray(stopWordList, 30);

           

            Console.ReadKey();

        }

        // Load up the ArrayList from a text file full of stopwords
        static void LoadArrayList(ArrayList A)
        {
            TextReader tr;
            tr = File.OpenText("C:\\Users\\mharger020362\\Desktop\\Stopwords.txt");

            string stopWord;
            stopWord = tr.ReadLine();
            while (stopWord != null)
            {
                A.Add(stopWord);
                stopWord = tr.ReadLine();
            }
            //A.Add("whatever");

            //int[] array = { 1, 2, 3, 4, 5 };
            //A.AddRange(array);

        }

        // Print all the stopwords in the ArrayList
        static void PrintArrayList(ArrayList A)
        {
            foreach (string stopWord in A)
                Console.WriteLine(stopWord);
        }

        static void SearchArrayList(ArrayList A)
        {
            Console.WriteLine("Search: ");
            string input = Console.ReadLine();
            if (A.Contains(input) == true && input.Length > 0)
                Console.WriteLine("Found" + input + " in array list!");
            else
                Console.WriteLine("Could not find" + (String.IsNullOrEmpty(input) ? "no input" : input) + "in the array list"); 

        }

        //static void CopyToArray(ArrayList A, int numElements)
        //{
        //    Array array = new Array[A.Count];
        //    A.CopyTo(0, array, 0, numElements);

        //    foreach (Object o in array)
        //        Console.WriteLine(o);
        //}

    }
}