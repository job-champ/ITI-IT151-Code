using System;
using System.Collections;
using System.IO;

// ArrayList Example
namespace Main
{

   class ArrayListWork
   {
      
      public static void Main( string[] args )
      {
	ArrayList stopWordList = new ArrayList();

	LoadArrayList(stopWordList);

	PrintArrayList(stopWordList);

	Console.ReadKey();

      }

      // Load up the ArrayList from a text file full of stopwords
      static void LoadArrayList(ArrayList A)
      {
      	TextReader tr;
    	tr = File.OpenText("//home//job//Desktop//ITI_Stuff//StopWords.txt");

    	string stopWord;
    	stopWord = tr.ReadLine();
    	while (stopWord != null)
    	{
        	A.Add(stopWord);
        	stopWord = tr.ReadLine();
    	}

      }

      // Print all the stopwords in the ArrayList
      static void PrintArrayList(ArrayList A)
      {
      	foreach(string stopWord in A)
		Console.WriteLine(stopWord);
      }

   }
}
