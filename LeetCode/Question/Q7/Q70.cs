using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>假设你正在爬楼梯。需要 n 阶你才能到达楼顶。</para>
	/// <para>每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？</para>
	/// </summary>
	/// <remarks>给定 n 是一个正整数。</remarks>
	public class Q70 : IQuestion
	{
		public int ClimbStairs(int n)
		{
			List<int> result = new List<int>(n);
			result.Add(1);
			result.Add(2);
			for (int i = 2; i < n; i++)
			{
				result.Add(result[i - 1] + result[i - 2]);
			}
			return result[n - 1];
		}
		public void Go()
		{
			Console.WriteLine(ClimbStairs(2));
			Console.WriteLine(ClimbStairs(3));
		}
	}
}
