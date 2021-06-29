using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个字符串 (s) 和一个字符模式 (p) ，实现一个支持 '?' 和 '*' 的通配符匹配。</para>
	/// <list type="bullet">
	/// <item>'?' 可以匹配任何单个字符。</item>
	/// <item>'*' 可以匹配任意字符串（包括空字符串）。</item>
	/// </list>
	/// <para>两个字符串完全匹配才算匹配成功。</para>
	/// </summary>
	/// <remarks>
	/// <para>s 可能为空，且只包含从 a-z 的小写字母。</para>
	/// <para>p 可能为空，且只包含从 a-z 的小写字母，以及字符? 和 *。</para>
	/// </remarks>
	public class Q44 : IQuestion
	{
		public bool IsMatch(string s, string p)
		{
			s = ' ' + s;
			p = ' ' + p;
			var dp = new bool[s.Length + 1, p.Length + 1];
			dp[0, 0] = true;
			for (int i = 1; i < s.Length + 1; i++)
			{
				for (int j = 1; j < p.Length + 1; j++)
				{
					if (s[i - 1] == p[j - 1] || p[j - 1] == '?')
					{
						dp[i, j] = dp[i - 1, j - 1];
					}
					if (p[j - 1] == '*')
					{
						dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
					}
				}
			}
			return dp[s.Length, p.Length];
		}
		public void Go()
		{
			Console.WriteLine(IsMatch("aa", "a"));
			Console.WriteLine(IsMatch("aa", "*"));
			Console.WriteLine(IsMatch("cb", "?a"));
			Console.WriteLine(IsMatch("adceb", "*a*b"));
			Console.WriteLine(IsMatch("acdcb", "a*c?b"));
			Console.WriteLine(IsMatch("aaabbbaabaaaaababaabaaabbabbbbbbbbaabababbabbbaaaaba", "a*******b"));
			Console.WriteLine(IsMatch("aab", "c*a*b"));
		}
	}
}
