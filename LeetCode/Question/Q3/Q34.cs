using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个按照升序排列的整数数组 nums，和一个目标值 target。找出给定目标值在数组中的开始位置和结束位置。</para>
	/// <para>如果数组中不存在目标值 target，返回[-1, -1]。</para>
	/// </summary>
	/// <remarks>你可以设计并实现时间复杂度为 O(log n) 的算法解决此问题吗？</remarks>

	public class Q34 : IQuestion
	{
		public int[] SearchRange(int[] nums, int target)
		{
			var index = Array.BinarySearch(nums, target);
			if (index < 0)
				return new int[] { -1, -1 };
			int start, end;
			start = end = index;
			while (start >= 0)
			{
				if (nums[start] == target) start--; else break;
			}
			start++;
			while (end < nums.Length)
			{
				if (nums[end] == target) end++; else break;
			}
			end--;
			return new int[] { start, end };
		}
		public void Go()
		{
			Console.WriteLine(SearchRange(Helper.GetArray(5, 7, 7, 8, 8, 10), 8).ToArrayString());
			Console.WriteLine(SearchRange(Helper.GetArray(5, 7, 7, 8, 8, 10), 6).ToArrayString());
			Console.WriteLine(SearchRange(Helper.GetArray<int>(), 0).ToArrayString());
		}
	}
}
