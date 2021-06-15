using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。
	*/
	public class Q3 : IQuestion
	{
		public int LengthOfLongestSubstring(string s)
		{
			ReadOnlySpan<char> span = s.AsSpan();
			ReadOnlySpan<char> sub = new ReadOnlySpan<char>();
			int max = 0;
			int start = 0;
			for (int i = 0; i < span.Length; i++)
			{
				int index = -1;
				for (int j = 0; j < sub.Length; j++)
				{
					if (sub[j] == span[i])
					{
						index = j;
						break;
					}
				}
				if (index != -1)
				{
					var length = sub.Length;
					if (length > max)
						max = length;
					start = start + index + 1;
					sub = span.Slice(start, i - start + 1);
				}
				else
				{

					sub = span.Slice(start, i - start + 1);
				}
			}
			if (sub.Length > max)
				max = sub.Length;
			return max;
		}
		public void Go()
		{
			Console.WriteLine(LengthOfLongestSubstring("abcabcbb"));
			Console.WriteLine(LengthOfLongestSubstring("bbbbb"));
			Console.WriteLine(LengthOfLongestSubstring("pwwkew"));
			Console.WriteLine(LengthOfLongestSubstring(""));
		}
	}
}
