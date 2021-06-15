using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	给你两个整数 left 和 right ，表示区间 [left, right] ，返回此区间内所有数字 按位与 的结果（包含 left 、right 端点）。
	 */
	public class Q201 : IQuestion
	{
		public int RangeBitwiseAnd(int left, int right)
		{
			if (left < (right / 2))
			{
				return 0;
			}
			long pow = 1;
			int i = 0;
			long res = left;
			var t = left;
			while (t != 0)
			{
				t >>= 1;
				i++;
				pow *= 2;
			}
			if (right - left > pow)
			{
				left >>= i;
				right >>= i;
				res = left;
				for (int j = left; j <= right; j++)
				{
					res &= j;
				}
				res <<= i;
			}
			else
			{
				for (long j = left; j <= right; j++)
				{
					res &= j;
				}
			}
			return (int)res;
		}
		public void Go()
		{
			Console.WriteLine(RangeBitwiseAnd(5, 7));
			Console.WriteLine(RangeBitwiseAnd(0, 0));
			Console.WriteLine(RangeBitwiseAnd(1, 2147483647));
		}
	}
}
