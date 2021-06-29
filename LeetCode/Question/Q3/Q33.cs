using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>整数数组 nums 按升序排列，数组中的值 互不相同 。</para>
	/// <para>在传递给函数之前，nums 在预先未知的某个下标 k（0 <= k<nums.length）上进行了 旋转，
	/// 使数组变为[nums[k], nums[k + 1], ..., nums[n - 1], nums[0], nums[1], ..., nums[k - 1]]（下标 从 0 开始 计数）。
	/// 例如， [0, 1, 2, 4, 5, 6, 7] 在下标 3 处经旋转后可能变为[4, 5, 6, 7, 0, 1, 2] 。</para>
	/// <para>给你 旋转后 的数组 nums 和一个整数 target ，如果 nums 中存在这个目标值 target ，则返回它的下标，否则返回 -1 。</para>
	/// </summary>
	public class Q33 : IQuestion
	{
		public int Search(ReadOnlySpan<int> nums, int target, int start)
		{
			if (nums.Length == 0)
				return -1;
			if (nums.Length == 1)
				if (nums[0] == target)
					return start;
				else
					return -1;
			var mid = nums.Length / 2;
			if (nums[mid] == target)
			{
				return start + mid;
			}
			if (nums[0] < nums[mid])
			{
				if (target < nums[mid] && target >= nums[0])
					return Search(nums.Slice(0, mid), target, start);
				else
					return Search(nums.Slice(mid), target, start + mid);
			}
			if (nums[mid] <= nums[nums.Length - 1])
			{
				if (target > nums[mid] && target <= nums[nums.Length - 1])
					return Search(nums.Slice(mid), target, start + mid);
				else
					return Search(nums.Slice(0, mid), target, start);
			}
			return -1;
		}

		public int Search(int[] nums, int target)
		{
			return Search(new ReadOnlySpan<int>(nums), target, 0);
		}
		public void Go()
		{
			Console.WriteLine(Search(Helper.GetArray(3, 1), 3));
			Console.WriteLine(Search(Helper.GetArray(4, 5, 6, 7, 0, 1, 2), 0));
			Console.WriteLine(Search(Helper.GetArray(4, 5, 6, 7, 0, 1, 2), 3));
			Console.WriteLine(Search(Helper.GetArray(1), 0));
		}
	}
}
