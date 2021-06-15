using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	 请你设计一个数据结构，支持 添加新单词 和 查找字符串是否与任何先前添加的字符串匹配 。

	实现词典类 WordDictionary ：

	WordDictionary() 初始化词典对象
	void addWord(word) 将 word 添加到数据结构中，之后可以对它进行匹配
	bool search(word) 如果数据结构中存在字符串与 word 匹配，则返回 true ；否则，返回  false 。word 中可能包含一些 '.' ，每个 . 都可以表示任何一个字母。
	*/
	public class Q211 : IQuestion
	{
		public class WordDictionary
		{
			class Node
			{
				public Node()
				{
					Next = new Dictionary<char, Node>();
				}
				public Dictionary<char, Node> Next { get; set; }
			}
			public WordDictionary()
			{
				Root = new Node();
			}

			public void AddWord(string word)
			{
				InternalAddWord(Root, word.AsSpan());
			}

			public bool Search(string word)
			{
				return InternalSearch(Root, word.AsSpan());
			}
			private static void InternalAddWord(Node node, ReadOnlySpan<char> word)
			{
				if (word.Length == 0)
				{
					if (!node.Next.ContainsKey('\0')) node.Next.Add('\0', null);
					return;
				}
				if (node.Next.ContainsKey(word[0]))
				{
					InternalAddWord(node.Next[word[0]], word.Slice(1));
				}
				else
				{
					Node next = new Node();
					node.Next.Add(word[0], next);
					InternalAddWord(next, word.Slice(1));
				}
			}

			private static bool InternalSearch(Node node, ReadOnlySpan<char> word)
			{
				if (node == null)
					return false;
				if (word.Length == 0)
					return node.Next.ContainsKey('\0');
				if (word[0] == '.')
				{
					foreach (var next in node.Next)
					{
						if (InternalSearch(next.Value, word.Slice(1)))
						{
							return true;
						}
					}
				}
				else
				{
					if (node.Next.ContainsKey(word[0]))
					{
						return InternalSearch(node.Next[word[0]], word.Slice(1));
					}
				}
				return false;
			}
			private Node Root { get; set; }
		}
		public void Go()
		{
			WordDictionary wordDictionary = new WordDictionary();
			wordDictionary.AddWord("bad");
			wordDictionary.AddWord("dad");
			wordDictionary.AddWord("mad");
			Console.WriteLine(wordDictionary.Search("pad")); // return False
			Console.WriteLine(wordDictionary.Search("bad")); // return True
			Console.WriteLine(wordDictionary.Search(".ad")); // return True
			Console.WriteLine(wordDictionary.Search("b..")); // return True

		}
	}
}
