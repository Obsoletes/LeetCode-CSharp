using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给定一个整数数组 nums ，找到一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。
	/// </summary>
	public class Q53 : IQuestion
	{
		public int MaxSubArray(int[] nums)
		{
			int pre = 0;
			int result = nums[0];
			foreach (var num in nums)
			{
				pre = Math.Max(num, pre + num);
				result = Math.Max(pre, result);
			}
			return result;
		}
		public void Go()
		{
			Console.WriteLine(MaxSubArray(Helper.GetArray(-2, 1, -3, 4, -1, 2, 1, -5, 4)));
			Console.WriteLine(MaxSubArray(Helper.GetArray(1)));
			Console.WriteLine(MaxSubArray(Helper.GetArray(0)));
			Console.WriteLine(MaxSubArray(Helper.GetArray(-1)));
			Console.WriteLine(MaxSubArray(Helper.GetArray(-100000)));
		}
	}
}
