using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。
	/// </summary>
	public class Q42 : IQuestion
	{
		public int Trap(int[] height)
		{
			ReadOnlySpan<int> span = height;
			int leftMax, rightMax;
			int res = 0;
			leftMax = rightMax = 0;
			while (span.Length != 0)
			{
				leftMax = Math.Max(leftMax, span[0]);
				rightMax = Math.Max(rightMax, span[^1]);
				if (span[0] < span[^1])
				{
					res += leftMax - span[0];
					span = span[1..];
				}
				else
				{
					res += rightMax - span[^1];
					span = span[0..^1];
				}
			}
			return res;
		}
		public void Go()
		{
			Console.WriteLine(Trap(Helper.GetArray(0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1)));
			Console.WriteLine(Trap(Helper.GetArray(4, 2, 0, 3, 2, 5)));
		}
	}
}
