using System;
using System.Text;

class chapter7 
{
	static void Main() 
	{
		StringBuilder stBuff = new StringBuilder();
		String[] words = new string[] {"now ", "is ", "the ", "time ", "for ", "all ", "good ", "men ", "to ", "come ", "to ", "the ", "aid ", "of ", "their ", "party"};
		for(int i = 0; i <= words.GetUpperBound(0); i++)
			stBuff.Append(words[i]);
		Console.WriteLine(stBuff);
	}
}
