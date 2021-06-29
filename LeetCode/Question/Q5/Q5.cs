using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给你一个字符串 s，找到 s 中最长的回文子串。
	/// </summary>
	public class Q5 : IQuestion
	{
		public bool IsPalindrome(ReadOnlySpan<char> span)
		{
			while (span.Length >= 2)
			{
				if (span[0] == span[span.Length - 1])
				{
					span = span.Slice(1, span.Length - 2);
				}
				else
					return false;
			}
			return true;
		}
		public ReadOnlySpan<char> LongestPalindrome(ReadOnlySpan<char> span)
		{
			var max = span.Slice(0, 1);
			while (span.Length >= max.Length + 1)
			{
				var t = span;
				while (t.Length >= max.Length + 1)
				{
					if (IsPalindrome(t))
					{
						if (t.Length > max.Length)
							max = t;
						break;
					}
					else
						t = t.Slice(0, t.Length - 1);
				}
				span = span.Slice(1);
			}
			return max;
		}
		public string LongestPalindrome(string s)
		{
			int[,] dp = new int[s.Length, s.Length];
			var r = string.Join(null, s.Reverse());
			int maxLen = 0;
			int maxEnd = 0;
			for (int i = 0; i < s.Length; i++)
			{
				for (int j = 0; j < s.Length; j++)
				{
					if (s[i] == r[j])
					{
						if (i == 0 || j == 0)
							dp[i, j] = 1;
						else
							dp[i, j] = dp[i - 1, j - 1] + 1;
					}
					if (dp[i, j] > maxLen)
					{
						int beforeRev = s.Length - 1 - j;
						if (beforeRev + dp[i, j] - 1 == i)
						{
							maxLen = dp[i, j];
							maxEnd = i;
						}

					}

				}
			}
			return s.Substring(maxEnd - maxLen + 1, maxLen);
		}
		public void Go()
		{
			Console.WriteLine(LongestPalindrome("a"));
			Console.WriteLine(LongestPalindrome("ac"));
		}
	}
}
