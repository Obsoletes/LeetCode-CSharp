using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	 Trie（发音类似 "try"）或者说 前缀树 是一种树形数据结构，用于高效地存储和检索字符串数据集中的键。
	 这一数据结构有相当多的应用情景，例如自动补完和拼写检查。

	请你实现 Trie 类：

	Trie() 初始化前缀树对象。
	void insert(String word) 向前缀树中插入字符串 word 。
	boolean search(String word) 如果字符串 word 在前缀树中，返回 true（即，在检索之前已经插入）；否则，返回 false 。
	boolean startsWith(String prefix) 如果之前已经插入的字符串 word 的前缀之一为 prefix ，返回 true ；否则，返回 false 。
	*/
	public class Q208 : IQuestion
	{
		public class Trie
		{
			class Node
			{
				public Node()
				{
					Next = new Dictionary<char, Node>();
				}
				public Dictionary<char, Node> Next { get; set; }
			}
			public Trie()
			{
				Root = new Node();
			}

			public void Insert(string word)
			{
				InternalInsert(Root, word.AsSpan());
			}
			public bool StartsWith(string prefix)
			{
				return InternalSearch(Root, prefix.AsSpan(), true);
			}
			public bool Search(string word)
			{
				return InternalSearch(Root, word.AsSpan(), false);
			}
			private static void InternalInsert(Node node, ReadOnlySpan<char> word)
			{
				if (word.Length == 0)
				{
					if (!node.Next.ContainsKey('\0')) node.Next.Add('\0', null);
					return;
				}
				if (node.Next.ContainsKey(word[0]))
				{
					InternalInsert(node.Next[word[0]], word.Slice(1));
				}
				else
				{
					Node next = new Node();
					node.Next.Add(word[0], next);
					InternalInsert(next, word.Slice(1));
				}
			}

			private static bool InternalSearch(Node node, ReadOnlySpan<char> word, bool isPrefix)
			{
				if (node == null)
					return false;
				if (word.Length == 0)
					return isPrefix || node.Next.ContainsKey('\0');
				if (node.Next.ContainsKey(word[0]))
				{
					return InternalSearch(node.Next[word[0]], word.Slice(1), isPrefix);
				}
				return false;
			}
			private Node Root { get; set; }
		}
		public void Go()
		{
			Trie trie = new();
			trie.Insert("apple");
			Console.WriteLine(trie.Search("apple"));   // 返回 True
			Console.WriteLine(trie.Search("app"));     // 返回 False
			Console.WriteLine(trie.StartsWith("app")); // 返回 True
			trie.Insert("app");
			Console.WriteLine(trie.Search("app"));     // 返回 True

		}
	}
}
