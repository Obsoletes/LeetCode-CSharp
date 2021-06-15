using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	给定一个整数数组 nums 和一个整数目标值 target，请你在该数组中找出 和为目标值 target  的那 两个 整数，并返回它们的数组下标。

	你可以假设每种输入只会对应一个答案。但是，数组中同一个元素在答案里不能重复出现。

	你可以按任意顺序返回答案。
	*/
	public class Q1 : IQuestion
	{
		public static int[] TwoSum(int[] nums, int target)
		{
			Dictionary<int, int> dic = new Dictionary<int, int>(nums.Length);
			for (int i = 0; i < nums.Length; i++)
			{
				if (dic.ContainsKey(target - nums[i]))
				{
					return new int[] { i, dic[target - nums[i]] };
				}
				else
				{
					dic.Add(nums[i], i);
				}
			}
			return null;
		}
		public void Go()
		{
			Console.WriteLine(string.Join(',', TwoSum(new int[] { 2, 7, 11, 15 }, 9)));
			Console.WriteLine(string.Join(',', TwoSum(new int[] { 3, 2, 4 }, 6)));
			Console.WriteLine(string.Join(',', TwoSum(new int[] { 3, 3 }, 6)));
		}
	}
}
