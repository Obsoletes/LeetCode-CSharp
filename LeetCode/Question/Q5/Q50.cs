using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 实现 pow(x, n) ，即计算 x 的 n 次幂函数（即，x^n）。
	/// </summary>
	public class Q50 : IQuestion
	{
		public double MyPow(double x, int n)
		{
			long y = Math.Abs((long)n);
			double res = 1;
			for (long i = y; i != 0; i /= 2)
			{
				if (i % 2 != 0)
				{
					res *= x;
				}
				x *= x;
			}
			return n < 0 ? 1 / res : res;
		}
		public void Go()
		{
			Console.WriteLine(MyPow(2.00000, 10));
			Console.WriteLine(MyPow(2.10000, 3));
			Console.WriteLine(MyPow(2.00000, -2));
		}
	}
}
