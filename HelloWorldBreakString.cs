using System;

class Chapter7
{
	static void Main() 
	{
		string string1 = "Hello, world!";
		int len = string1.Length;
		int pos = string1.IndexOf(" ");

		string firstWord, secondWord;
		firstWord = string1.Substring(0, pos);
		secondWord = string1.Substring(pos+1,
		(len-1)-(pos+1));

		Console.WriteLine("First word: " + firstWord);
		Console.WriteLine("Second word: " + secondWord);
		Console.Read();
	}
}
