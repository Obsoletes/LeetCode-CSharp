using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>一条包含字母 A-Z 的消息通过以下映射进行了 编码 ：</para>
	/// <para>要 解码 已编码的消息，所有数字必须基于上述映射的方法，反向映射回字母（可能有多种方法）。例如，"11106" 可以映射为：</para>
	/// <list type="bullet">
	/// <item>"AAJF" ，将消息分组为 (1 1 10 6)</item>
	/// <item>"KJF" ，将消息分组为 (11 10 6)</item>
	/// </list>
	/// <para>注意，消息不能分组为  (1 11 06) ，因为 "06" 不能映射为 "F" ，这是由于 "6" 和 "06" 在映射中并不等价。</para>
	/// <para>给你一个只含数字的 非空 字符串 s ，请计算并返回 解码 方法的 总数 。</para>
	/// <para>题目数据保证答案肯定是一个 32 位 的整数。</para>
	/// </summary>
	public class Q91 : IQuestion
	{
		public int NumDecodings(string s)
		{
			if (s[0] == '0')
				return 0;
			int[] dp = new int[s.Length+1];
			dp[0] = 1;
			for (int i = 1; i <= s.Length; i++)
			{
				if (s[i - 1] != '0')
					dp[i] += dp[i - 1];
				if (i > 1) if (s[i - 2] == '1' || (s[i - 2] == '2' && s[i - 1] <= '6'))
					{
						dp[i] += dp[i - 2];
					}
			}
			return dp[^1];
		}
		public void Go()
		{
			Console.WriteLine(NumDecodings("12"));
			Console.WriteLine(NumDecodings("226"));
			Console.WriteLine(NumDecodings("0"));
			Console.WriteLine(NumDecodings("06"));
		}
	}

}
