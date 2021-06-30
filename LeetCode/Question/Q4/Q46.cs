using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给定一个不含重复数字的数组 nums ，返回其 所有可能的全排列 。你可以 按任意顺序 返回答案。
	/// </summary>
	public class Q46 : IQuestion
	{
		public IList<IList<int>> Permute(int[] nums)
		{
			Array.Sort(nums);
			List<IList<int>> result = new List<IList<int>>();
			result.Add(nums.ToList());
			while (NextPermutation(nums))
			{
				result.Add(nums.ToList());
			}
			return result;
		}
		public bool NextPermutation(int[] nums)
		{
			int i = nums.Length - 2;
			while (i >= 0 && nums[i] >= nums[i + 1])
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
				Swap(nums, i, j);
				Reverse(nums, i + 1);
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Swap(int[] nums, int i, int j)
		{
			int temp = nums[i];
			nums[i] = nums[j];
			nums[j] = temp;
		}

		public void Reverse(int[] nums, int start)
		{
			int left = start, right = nums.Length - 1;
			while (left < right)
			{
				Swap(nums, left, right);
				left++;
				right--;
			}
		}
		public void Go()
		{
			Console.WriteLine(Permute(Helper.GetArray(1, 2, 3)).ToArrayString2());
			Console.WriteLine(Permute(Helper.GetArray(0, 1)).ToArrayString2());
			Console.WriteLine(Permute(Helper.GetArray(1)).ToArrayString2());
		}
	}
}
