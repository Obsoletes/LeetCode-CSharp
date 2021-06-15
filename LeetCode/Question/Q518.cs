using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给你一个整数数组 coins 表示不同面额的硬币，另给一个整数 amount 表示总金额。</para>
	/// <para>请你计算并返回可以凑成总金额的硬币组合数。如果任何硬币组合都无法凑出总金额，返回 0 。</para>
	/// <para>假设每一种面额的硬币有无限个。 </para>
	/// </summary>
	/// <remarks>题目数据保证结果符合 32 位带符号整数。</remarks>
	public class Q518 : IQuestion
	{
		public int Change(int amount, int[] coins)
		{
			int[] dp = new int[amount + 1];
			dp[0] = 1;
			foreach (var coin in coins)
			{
				for (int i = 0; i < amount; i++)
				{
					if (i + coin < amount + 1)
						dp[i + coin] += dp[i];
				}
			}
			return dp[amount];
		}
		public void Go()
		{
			Console.WriteLine(Change(5, Helper.GetArray(1, 2, 5)));
			Console.WriteLine(Change(3, Helper.GetArray(2)));
			Console.WriteLine(Change(10, Helper.GetArray(10)));
		}
	}
}
