using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给你一个数组 nums 和一个值 val，你需要 原地 移除所有数值等于 val 的元素，并返回移除后数组的新长度。</para>
	/// <para>不要使用额外的数组空间，你必须仅使用 O(1) 额外空间并 原地 修改输入数组。</para>
	/// <para>元素的顺序可以改变。你不需要考虑数组中超出新长度后面的元素。</para>
	/// </summary>
	public class Q27 : IQuestion
	{
		public int RemoveElement(int[] nums, int val)
		{
			if (nums.Length == 0)
				return 0;
			int pos = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] != val)
				{
					nums[pos] = nums[i];
					pos++;
				}
			}
			return pos;
		}
		public void Go()
		{
			Console.WriteLine(RemoveElement(Helper.GetArray(3, 2, 2, 3), 3));
			Console.WriteLine(RemoveElement(Helper.GetArray(0, 1, 2, 2, 3, 0, 4, 2), 2));
		}
	}
}
