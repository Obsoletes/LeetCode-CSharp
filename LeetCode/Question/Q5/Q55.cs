using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个非负整数数组 nums ，你最初位于数组的 第一个下标 。</para>
	/// <para>数组中的每个元素代表你在该位置可以跳跃的最大长度。</para>
	/// <para>判断你是否能够到达最后一个下标。</para>
	/// </summary>
	public class Q55 : IQuestion
	{
		public bool CanJump(int[] nums)
		{
			if (nums.Length == 1)
				return true;
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
				if (maxPos < 1)
					return false;
				span = span[maxPos..];
			}
			return true;
		}
		public void Go()
		{
			Console.WriteLine(CanJump(Helper.GetArray(2, 3, 1, 1, 4)));
			Console.WriteLine(CanJump(Helper.GetArray(3, 2, 1, 0, 4)));
		}
	}
}
