using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个非负整数数组，你最初位于数组的第一个位置。</para>
	/// <para>数组中的每个元素代表你在该位置可以跳跃的最大长度。</para>
	/// <para>你的目标是使用最少的跳跃次数到达数组的最后一个位置。</para>
	/// <para>假设你总是可以到达数组的最后一个位置。</para>
	/// </summary>
	public class Q45 : IQuestion
	{
		public int Jump(int[] nums)
		{
			if (nums.Length == 1)
				return 0;
			ReadOnlySpan<int> span = nums;
			int step = 0;
			while (span.Length > span[0] + 1)
			{
				step++;
				int[] arr = span[1..(span[0] + 1)].ToArray();
				for (int i = 0; i < span[0]; i++)
				{
					arr[i] -= span[0] - i - 1;
				}
				int maxPos = 0;
				int max = 0;
				for (int i = 0; i < span[0]; i++)
				{
					if (arr[i] > max)
					{
						maxPos = i + 1;
						max = arr[i];
					}
				}
				span = span[maxPos..];
			}
			return step + 1;
		}
		public void Go()
		{
			Console.WriteLine(Jump(Helper.GetArray(7, 0, 9, 6, 9, 6, 1, 7, 9, 0, 1, 2, 9, 0, 3)));
			Console.WriteLine(Jump(Helper.GetArray(2, 3, 1, 1, 4)));
			Console.WriteLine(Jump(Helper.GetArray(2, 3, 0, 1, 4)));
		}
	}
}
