using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个排序数组和一个目标值，在数组中找到目标值，并返回其索引。
	/// 如果目标值不存在于数组中，返回它将会被按顺序插入的位置。</para>
	/// <para>你可以假设数组中无重复元素。</para>
	/// </summary>
	public class Q35 : IQuestion
	{

		public int SearchInsert(int[] nums, int target)
		{
			int left = 0, right = nums.Length - 1;
			while (left <= right)
			{
				var mid = (left + right) / 2;
				if (nums[mid] == target)
					return mid;
				if (target > nums[mid])
				{
					left = mid + 1;
				}
				if (target < nums[mid])
				{
					right = mid - 1;
				}
			}
			return left;
		}
		public void Go()
		{
			Console.WriteLine(SearchInsert(Helper.GetArray(1), 0));
			Console.WriteLine(SearchInsert(Helper.GetArray(1, 3, 5, 6), 5));
			Console.WriteLine(SearchInsert(Helper.GetArray(1, 3, 5, 6), 2));
			Console.WriteLine(SearchInsert(Helper.GetArray(1, 3, 5, 6), 7));
			Console.WriteLine(SearchInsert(Helper.GetArray(1, 3, 5, 6), 0));
		}
	}
}
