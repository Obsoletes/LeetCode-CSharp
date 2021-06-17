using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>实现获取 下一个排列 的函数，算法需要将给定数字序列重新排列成字典序中下一个更大的排列。</para>
	/// <para>如果不存在下一个更大的排列，则将数字重新排列成最小的排列（即升序排列）。</para>
	/// </summary>
	/// <remarks>必须 原地 修改，只允许使用额外常数空间。</remarks>
	public class Q31 : IQuestion
	{
		public void NextPermutation(int[] nums)
		{
			int i = nums.Length - 2;
			while (i >= 0 && nums[i] > nums[i + 1])
			{
				i--;
			}
			if (i >= 0)
			{
				int j = nums.Length - 1;
				while (j >= 0 && nums[i] >= nums[j])
				{
					j--;
				}
				if (j >= 0)
				{
					var temp = nums[i];
					nums[i] = nums[j];
					nums[j] = temp;
				}
			}
			Array.Reverse(nums, i + 1, nums.Length - i - 1);
		}
		public void Go()
		{
			var arr = Helper.GetArray(1, 1);
			NextPermutation(arr);
			Console.WriteLine($"[{string.Join(',', arr)}]");
			arr = Helper.GetArray(3, 2, 1);
			NextPermutation(arr);
			Console.WriteLine($"[{string.Join(',', arr)}]");
			arr = Helper.GetArray(1, 1, 5);
			NextPermutation(arr);
			Console.WriteLine($"[{string.Join(',', arr)}]");
			arr = Helper.GetArray(1);
			NextPermutation(arr);
			Console.WriteLine($"[{string.Join(',', arr)}]");
		}
	}
}
