using System;

public class Node 
{
	public int Data;
	public Node Left;
	public Node Right;

	public void DisplayNode() 
	{
		Console.Write(Data + " ");
	}
}

public class BinarySearchTree 
{
	public Node root;

	public BinarySearchTree() 
	{
		root = null;
	}

	public void Insert(int i) 
	{
		Node newNode = new Node();
		newNode.Data = i;

		if (root == null)
			root = newNode;
		else 
		{
			Node current = root;
			Node parent;
			while (true) 
			{
				parent = current;
				if (i < current.Data) 
				{
					current = current.Left;
					if (current == null) {
						parent.Left = newNode;
						break;
					}
				}
				else 
				{
					current = current.Right;
					if (current == null) 
					{
						parent.Right = newNode;
						break;
					}
				}
			}
		}
	}

	public void InOrder(Node theRoot) 
	{
		if (!(theRoot == null)) 
		{
			InOrder(theRoot.Left);
			theRoot.DisplayNode();
			InOrder(theRoot.Right);
		}
	}

	public void PreOrder(Node theRoot) 
	{
		if (!(theRoot == null)) 
		{
			theRoot.DisplayNode();
			PreOrder(theRoot.Left);
			PreOrder(theRoot.Right);
		}
	}

	public void PostOrder(Node theRoot) 
	{
		if (!(theRoot == null)) 
		{
			PostOrder(theRoot.Left);
			PostOrder(theRoot.Right);
			theRoot.DisplayNode();
		}
	}

	public int FindMin() 
	{
		Node current = root;

		while (!(current.Left == null))
			current = current.Left;

		return current.Data;
	}

	public int FindMax() 
	{
		Node current = root;

		while (!(current.Right == null))
			current = current.Right;

		return current.Data;
	}

	public Node Find(int key) 
	{
		Node current = root;

		while (current.Data != key) 
		{
			if (key < current.Data)
				current = current.Left;
			else
				current = current.Right;
			if (current == null)
				return null;
		}
		return current;
	}

	public Node GetSuccessor(Node delNode) 
	{
		Node successorParent = delNode;
		Node successor = delNode;
		Node current = delNode.Right;

		while (!(current == null)) 
		{
			successorParent = current;
			successor = current;
			current = current.Left;
		}

		if (!(successor == delNode.Right)) 
		{
			successorParent.Left = successor.Right;
			successor.Right = delNode.Right;
		}
		return successor;
	}

	public bool Delete(int key) 
	{
		Node current = root;
		Node parent = root;
		Node successor = root;

		bool isLeftChild = true;
		while (current.Data != key) 
		{
			parent = current;

			if (key < current.Data) 
			{
				isLeftChild = true;
				current = current.Right;
			} 
			else 
			{
				isLeftChild = false;
				current = current.Right;
			}
			if (current == null)
				return false;
		}
			if ((current.Left == null) && (current.Right == null))
				if (current == root)
					root = null;
				else if (isLeftChild)
					parent.Left = null;
				else
					parent.Right = null;
			else if (current.Right == null)
				if (current == root)
					root = current.Left;
				else if (isLeftChild)
					parent.Left = current.Left;
				else
					parent.Right = current.Right;
			else if (current.Left == null)
				if (current == root)
					root = current.Right;
				else if (isLeftChild)
					parent.Left = parent.Right;
				else
					parent.Right = current.Right;
			else
				successor = GetSuccessor(current);

			if (current == root)
				root = successor;
			else if (isLeftChild)
				parent.Left = successor;
			else
				parent.Right = successor;
			successor.Left = current.Left;
		return true;
	}
}	

public class chapter12
{
	static void Main() 
	{
		BinarySearchTree nums = new BinarySearchTree();
		nums.Insert(23);
		nums.Insert(45);
		nums.Insert(16);
		nums.Insert(37);
		nums.Insert(3);
		nums.Insert(99);
		nums.Insert(22);
		Console.WriteLine("Inorder traversal: ");
		nums.InOrder(nums.root);
		Console.WriteLine("\nPreorder traversal: ");
		nums.PreOrder(nums.root);
		Console.WriteLine("\nPostorder traversal: ");
		nums.PostOrder(nums.root);
		Console.WriteLine("\nMin Value is: " + nums.FindMin());
		Console.WriteLine("Max Value is: " + nums.FindMax());
		nums.Delete(45);
		Console.WriteLine("Inorder traversal: ");
		nums.InOrder(nums.root);
		Console.WriteLine("\nPreorder traversal: ");
		nums.PreOrder(nums.root);
		Console.WriteLine("\nPostorder traversal: ");
		nums.PostOrder(nums.root);
		Console.WriteLine("\nMin Value is: " + nums.FindMin());
		Console.WriteLine("Max Value is: " + nums.FindMax());
		Console.ReadKey();
	}
}
