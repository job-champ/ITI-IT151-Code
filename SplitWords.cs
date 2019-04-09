using System;
using System.Collections;

class Chapter7 
{
	static void Main() 
	{
		string astring = "now is the time for all good people ";
		ArrayList words = new ArrayList();
		words = SplitWords(astring);

		foreach (string word in words)
			Console.Write(word + " ");
		Console.Read();
	}

	static ArrayList SplitWords(string astring) 
	{
		ArrayList words = new ArrayList();

		int pos;
		string word;
		pos = astring.IndexOf(" ");

		while (pos > 0) 
		{
			word = astring.Substring(0, pos);
			words.Add(word);
			astring = astring.Substring(pos + 1, astring.Length - (pos + 1));
			pos = astring.IndexOf(" ");

			if (pos == -1) 
			{
				word = astring.Substring(0, astring.Length);
				words.Add(word);
			}
		}
		return words;
	}
}
