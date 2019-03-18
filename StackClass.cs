using System;
using System.Collections;

class CStack
{
	private int p_index;
	private ArrayList list;

	public CStack()
	{
		list = new ArrayList();
		p_index = -1;
	}

	public int count
	{
		get
		{
			return list.Count;
		}
	}

	public void push(object item)
	{
		list.Add(item);
		p_index++;
	}

	public object pop()
	{
		object obj = list[p_index];
		list.RemoveAt(p_index);
		p_index--;
		return obj;
	}

	public void clear()
	{
		list.Clear();
		p_index = -1;
	}

	public object peek()
	{
		return list[p_index];
	}

	public static void Main(string[] args)
	{

		while(true)
		{
			CStack alist = new CStack();
			string ch;			
			
			Console.WriteLine("Please enter a word to check if it is a palindrome. Enter the letter \"x\" to exit the program.");
			string word = Console.ReadLine();
			if(word.Equals("X") || word.Equals("x"))
			{
				break;
			}
			else
			{
				//string word = "seen";
				bool isPalindrome = true;
				for(int x = 0; x < word.Length; x++)
					alist.push(word.ToLower().Substring(x, 1));

				int pos = 0;
				while (alist.count > 0)
				{
					ch = alist.pop().ToString();
					if (ch != word.ToLower().Substring(pos,1))
					{
						isPalindrome = false;
						break;
					}
					pos++;
				}

				if (isPalindrome && !word.Trim().Equals(""))
					Console.WriteLine(word + " is a palindrome.");
				else
					Console.WriteLine(word + " is not a palindrome.");

				Console.ReadKey();
			}
		}
	}
}
