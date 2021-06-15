using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	 给你一个字符串 s 和一个字符规律 p，请你来实现一个支持 '.' 和 '*' 的正则表达式匹配。

	'.' 匹配任意单个字符
	'*' 匹配零个或多个前面的那一个元素
	所谓匹配，是要涵盖 整个 字符串 s的，而不是部分字符串。

	 */
	public class Q10 : IQuestion
	{
		public bool IsMatch(ReadOnlySpan<char> s, ReadOnlySpan<char> p)
		{
			if (p.Length == 0)
			{
				return s.Length == 0;
			}
			bool match = (s.Length != 0) && ((s[0] == p[0]) || p[0] == '.');
			if (p.Length > 1 && p[1] == '*')
			{
				if (IsMatch(s, p.Slice(2)))
				{
					return true;
				}
				else
				{
					return match && IsMatch(s.Slice(1), p);
				}
			}
			if (match)
			{
				return IsMatch(s.Slice(1), p.Slice(1));
			}
			return false;
		}
		public bool IsMatch(string s, string p)
		{
			return IsMatch(s.AsSpan(), p.AsSpan());
		}
		public void Go()
		{
			Console.WriteLine(IsMatch("aa", "a"));
			Console.WriteLine(IsMatch("aa", "a*"));
			Console.WriteLine(IsMatch("ab", ".*"));
			Console.WriteLine(IsMatch("aab", "c*a*b"));
			Console.WriteLine(IsMatch("mississippi", "mis*is*p*."));
		}
	}
}
