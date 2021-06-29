using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个字符串 s 和一些 长度相同 的单词 words 。找出 s 中恰好可以由 words 中所有单词串联形成的子串的起始位置。</para>
	/// <para>注意子串要与 words 中的单词完全匹配，中间不能有其他字符 ，但不需要考虑 words 中单词串联的顺序。</para>
	/// </summary>
	public class Q30 : IQuestion
	{
		public IList<int> FindSubstring(string s, string[] words)
		{
			List<int> res = new List<int>();
			if (words.Length == 0)
				return res;
			var span = s.AsSpan();
			Dictionary<string, int> wordDic = new Dictionary<string, int>();
			var wordLength = words[0].Length;
			var wordsSpan = string.Join('\0', words).AsSpan();
			foreach (var word in words)
			{
				if (wordDic.ContainsKey(word))
					wordDic[word]++;
				else
					wordDic.Add(word, 1);
			}
			var start = 0;
			Dictionary<string, int> result = new Dictionary<string, int>();

			while (span.Length >= wordLength * words.Length)
			{
				int count = 0;
				for (int i = 0; i < words.Length; i++)
				{
					var w = span.Slice(i * wordLength, wordLength).ToString();
					if (wordDic.ContainsKey(w))
					{
						if (result.ContainsKey(w))
							result[w]++;
						else
							result.Add(w, 1);
						if (result[w] <= wordDic[w])
							count++;
						else
							break;
					}
				}
				if (count == words.Length)
					res.Add(start);
				span = span.Slice(1);
				start++;
				result.Clear();
			}
			return res;
		}
		public void Go()
		{
			Console.WriteLine(FindSubstring("wordgoodgoodgoodbestword", Helper.GetArray("word", "good", "best", "good")).ToArrayString());
			Console.WriteLine(FindSubstring("ababababab", Helper.GetArray("ababa", "babab")).ToArrayString());
			Console.WriteLine(FindSubstring("barfoothefoobarman", Helper.GetArray("bar", "foo")).ToArrayString());
			Console.WriteLine(FindSubstring("barfoofoobarthefoobarman", Helper.GetArray("bar", "foo", "the")).ToArrayString());
			Console.WriteLine(FindSubstring("aaaaaaaaaaaaaa", Helper.GetArray("aa", "aa")).ToArrayString());

		}

	}
}
