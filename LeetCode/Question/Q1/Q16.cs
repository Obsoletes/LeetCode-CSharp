using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给定一个包括 n 个整数的数组 nums 和 一个目标值 target。
	/// 找出 nums 中的三个整数，使得它们的和与 target 最接近。返回这三个数的和。
	/// </summary>
	/// <remarks>假定每组输入只存在唯一答案。</remarks>
	public class Q16 : IQuestion
	{
		public int ThreeSumClosest(int[] nums, int target)
		{
			Array.Sort(nums);
			var close = nums[0] + nums[1] + nums[2];
			for (int i = 0; i < nums.Length; i++)
			{
				int j = i + 1, k = nums.Length - 1;
				while (j < k)
				{
					var current = Check(i, j, k);
					if (current > target)
					{
						k--;
					}
					else
					{
						j++;
					}
				}
			}
			return close;
			int Check(int i, int j, int k)
			{
				var current = nums[i] + nums[j] + nums[k];
				if (Math.Abs(current - target) < Math.Abs(close - target))
				{
					close = current;
				}
				return current;
			}
		}
		public void Go()
		{
			Console.WriteLine(ThreeSumClosest(Helper.GetArray(-1, 2, 1, -4), 1));
		}
	}
}
