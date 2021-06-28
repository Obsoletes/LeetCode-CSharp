using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为 “Start” ）。</para>
	/// <para>机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为 “Finish” ）。</para>
	/// <para>问总共有多少条不同的路径？</para>
	/// </summary>
	public class Q62 : IQuestion
	{
		public int UniquePaths(int m, int n)
		{
			int large, small;
			if (m > n)
			{
				large = m;
				small = n;
			}
			else
			{
				small = m;
				large = n;
			}
			BigInteger res = new BigInteger(1);
			for (int i = small + large - 2; i > large - 1; i--)
			{
				res *= i;
			}
			for (int i = 1; i <= small - 1; i++)
			{
				res /= i;
			}
			
			return (int)res;
		}
		public void Go()
		{
			Console.WriteLine(UniquePaths(3, 7));
			Console.WriteLine(UniquePaths(3, 2));
			Console.WriteLine(UniquePaths(3, 3));
		}
	}
}
