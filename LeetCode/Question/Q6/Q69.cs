using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>实现 int sqrt(int x) 函数。</para>
	/// <para>计算并返回 x 的平方根，其中 x 是非负整数。</para>
	/// <para>由于返回类型是整数，结果只保留整数的部分，小数部分将被舍去。</para>
	/// </summary>
	public class Q69 : IQuestion
	{
		public int MySqrt(int x)
		{
			double r = x;
			while (r * r - x > 1e-5)
			{
				r = (r + x / r) / 2;
			}
			return (int)r;
		}
		public void Go()
		{
			Console.WriteLine(MySqrt(4));
			Console.WriteLine(MySqrt(8));
		}
	}
}
