using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	 给你一个 32 位的有符号整数 x ，返回将 x 中的数字部分反转后的结果。

	 如果反转后整数超过 32 位的有符号整数的范围 [−231,  231 − 1] ，就返回 0。

	 假设环境不允许存储 64 位整数（有符号或无符号）。
	 */
	public class Q7 : IQuestion
	{
		public int Reverse(int x)
		{
			try
			{
				bool isNeg = x < 0;
				x = Math.Abs(x);
				int res = 0;
				while (x != 0)
				{
					var c = x % 10;
					x = x / 10;
					checked
					{
						res = res * 10 + c;

					}
				}
				return isNeg ? -res : res;
			}
			catch (OverflowException)
			{
				return 0;
			}
		}
		public void Go()
		{
			Console.WriteLine(Reverse(123));
			Console.WriteLine(Reverse(-123));
			Console.WriteLine(Reverse(120));
			Console.WriteLine(Reverse(0));
		}
	}
}
