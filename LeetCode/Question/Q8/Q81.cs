using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>已知存在一个按非降序排列的整数数组 nums ，数组中的值不必互不相同。</para>
	/// <para>在传递给函数之前，nums 在预先未知的某个下标 k（0 <= k<nums.length）上进行了 旋转 ，
	/// 使数组变为[nums[k], nums[k + 1], ..., nums[n - 1], nums[0], nums[1], ..., nums[k - 1]]（下标 从 0 开始 计数）。
	/// 例如， [0, 1, 2, 4, 4, 4, 5, 6, 6, 7] 在下标 5 处经旋转后可能变为[4, 5, 6, 6, 7, 0, 1, 2, 4, 4] 。</para>
	/// <para>给你 旋转后 的数组 nums 和一个整数 target ，请你编写一个函数来判断给定的目标值是否存在于数组中。
	/// 如果 nums 中存在这个目标值 target ，则返回 true ，否则返回 false 。</para>
	/// </summary>
	public class Q81 : IQuestion
	{
		public bool Search(int[] nums, int target)
		{
			return Search(new ReadOnlySpan<int>(nums), target);
		}
		public bool Search(ReadOnlySpan<int> nums, int target)
		{
			if (nums.Length == 0)
				return false;
			if (nums.Length == 1)
				if (nums[0] == target)
					return true;
				else
					return false;
			var mid = nums.Length / 2;
			if (nums[mid] == target)
			{
				return true;
			}
			while (nums.Length > 1 && nums[0] == nums[mid] && nums[^1] == nums[mid])
			{
				nums = nums[1..^1];
				mid--;
			}
			if (nums.Length == 0)
				return false;
			if (nums[0] <= nums[mid])
			{
				if (target < nums[mid] && target >= nums[0])
					return Search(nums[0..mid], target);
				else
					return Search(nums[mid..], target);
			}
			else
			{
				if (target > nums[mid] && target <= nums[^1])
					return Search(nums[mid..], target);
				else
					return Search(nums[0..mid], target);
			}
		}
		public void Go()
		{
			//	Console.WriteLine(Search(Helper.GetArray(2, 5, 6, 0, 0, 1, 2), 0));
			//	Console.WriteLine(Search(Helper.GetArray(2, 5, 6, 0, 0, 1, 2), 3));
			Console.WriteLine(Search(Helper.GetArray(1, 1, 1), 0));
		}
	}
}
