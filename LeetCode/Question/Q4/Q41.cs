using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给你一个未排序的整数数组 nums ，请你找出其中没有出现的最小的正整数。
	/// </summary>
	/// <remarks>请你实现时间复杂度为 O(n) 并且只使用常数级别额外空间的解决方案。</remarks>
	public class Q41 : IQuestion
	{
		public int FirstMissingPositive(int[] nums)
		{
			for (int i = 0; i < nums.Length; i++)
			{
				while (nums[i] > 0 && nums[i] < nums.Length && nums[i] != nums[nums[i] - 1])
				{
					int temp = nums[nums[i] - 1];
					nums[nums[i] - 1] = nums[i];
					nums[i] = temp;
				}
			}
			for (int i = 0; i < nums.Length; i++)
			{
				if (i + 1 != nums[i])
				{
					return i + 1;
				}
			}
			return nums.Length + 1;
		}
		public void Go()
		{
			Console.WriteLine(FirstMissingPositive(Helper.GetArray(-1, 4, 2, 1, 9, 10)));
			Console.WriteLine(FirstMissingPositive(Helper.GetArray(2, 1)));
			Console.WriteLine(FirstMissingPositive(Helper.GetArray(1, 2, 0)));
			Console.WriteLine(FirstMissingPositive(Helper.GetArray(3, 4, -1, 1)));
			Console.WriteLine(FirstMissingPositive(Helper.GetArray(7, 8, 9, 11, 12)));
		}
	}
}
