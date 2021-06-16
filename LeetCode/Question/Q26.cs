using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给你一个有序数组 nums ，请你 原地 删除重复出现的元素，使每个元素 只出现一次 ，返回删除后数组的新长度。</para>
	/// <para>不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成。</para>
	/// </summary>
	public class Q26 : IQuestion
	{
		public int RemoveDuplicates(int[] nums)
		{
			if (nums.Length <= 1)
				return nums.Length;
			int pos = 1;
			for (int i = 1; i < nums.Length; i++)
			{
				if (nums[i] > nums[i - 1])
				{
					nums[pos] = nums[i];
					pos++;
				}
			}
			return pos;
		}
		public void Go()
		{
			Console.WriteLine(RemoveDuplicates(Helper.GetArray(1, 1, 2)));
			Console.WriteLine(RemoveDuplicates(Helper.GetArray(0, 0, 1, 1, 1, 2, 2, 3, 3, 4)));
		}
	}
}
