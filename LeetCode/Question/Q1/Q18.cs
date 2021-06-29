using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给定一个包含 n 个整数的数组 nums 和一个目标值 target，
	/// 判断 nums 中是否存在四个元素 a，b，c 和 d ，使得 a + b + c + d 的值与 target 相等？
	/// 找出所有满足条件且不重复的四元组。
	/// </summary>
	/// <remarks>注意：答案中不可以包含重复的四元组。</remarks>
	public class Q18 : IQuestion
	{
		public IList<IList<int>> FourSum(int[] nums, int target)
		{
			List<IList<int>> list = new List<IList<int>>();
			if (nums.Length < 4)
				return list;
			Array.Sort(nums);
			var length = nums.Length;
			for (int i = 0; i < length - 3; i++)
			{
				if (i > 0 && nums[i] == nums[i - 1])
					continue;
				if (nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3] > target)
				{
					break;
				}
				if (nums[i] + nums[length - 3] + nums[length - 2] + nums[length - 1] < target)
				{
					continue;
				}
				for (int j = i + 1; j < length - 2; j++)
				{
					if (j > i + 1 && nums[j] == nums[j - 1])
						continue;
					if (nums[i] + nums[j] + nums[j + 1] + nums[j + 2] > target)
					{
						break;
					}
					if (nums[i] + nums[j] + nums[length - 2] + nums[length - 1] < target)
					{
						continue;
					}
					int left = j + 1, right = length - 1;
					while (left < right)
					{
						var sum = nums[i] + nums[j] + nums[left] + nums[right];
						if (sum == target)
						{
							list.Add(Helper.GetArray(nums[i], nums[j], nums[left], nums[right]));
							while (left < right && nums[left] == nums[left + 1])
							{
								left++;
							}
							left++;
							while (left < right && nums[right] == nums[right - 1])
							{
								right--;
							}
							right--;
						}
						else if (sum < target)
						{
							left++;
						}
						else
						{
							right--;
						}
					}
				}
			}
			return list;
		}
		public void Go()
		{
			Console.WriteLine(FourSum(Helper.GetArray(1, 0, -1, 0, -2, 2), 0).ToArrayString2());
			Console.WriteLine(FourSum(Helper.GetArray<int>(), 0).ToArrayString2());
		}
		private string ToString(IList<IList<int>> list)
		{
			return string.Join(',', list.Select(l => $"[{string.Join(',', l)}]"));
		}
	}
}
