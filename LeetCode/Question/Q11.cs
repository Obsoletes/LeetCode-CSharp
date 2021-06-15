using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	 给你 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。
	 在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为 (i, ai) 和 (i, 0) 。
	 找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。

	说明：你不能倾斜容器。
	 */
	public class Q11 : IQuestion
	{
		public int MaxArea(int[] height)
		{
			ReadOnlySpan<int> span = height;
			int max = calc(span);
			while (span.Length >= 2)
			{
				if (span[0] > span[span.Length - 1])
				{
					span = span.Slice(0, span.Length - 1);
				}
				else span = span.Slice(1);
				int t = calc(span);
				if (t > max)
					max = t;
			}
			return max;
			static int calc(ReadOnlySpan<int> s)
			{
				return (s.Length - 1) * Math.Min(s[0], s[s.Length - 1]);
			}
		}
		public void Go()
		{
			Console.WriteLine(MaxArea(Helper.GetArray(1, 8, 6, 2, 5, 4, 8, 3, 7)));
			Console.WriteLine(MaxArea(Helper.GetArray(1, 1)));
			Console.WriteLine(MaxArea(Helper.GetArray(4, 3, 2, 1, 4)));
			Console.WriteLine(MaxArea(Helper.GetArray(1, 2, 1)));
		}
	}
}
