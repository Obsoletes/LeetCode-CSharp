using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给你一个整数数组 nums ，数组中的元素 互不相同 。返回该数组所有可能的子集（幂集）。</para>
	/// <para>解集 不能 包含重复的子集。你可以按 任意顺序 返回解集。</para>
	/// </summary>
	public class Q78 : IQuestion
	{
		public IList<IList<int>> Subsets(int[] nums)
		{
			int[] test = new int[nums.Length];
			List<IList<int>> result = new List<IList<int>>();
			for (int i = 0; i < nums.Length; i++)
			{
				test[i] = 1 << i;
			}
			int max = (1 << nums.Length) - 1;
			for (int i = 0; i <= max; i++)
			{
				List<int> temp = new List<int>();
				for (int j = 0; j < nums.Length; j++)
				{
					if ((i & test[j]) != 0)
					{
						temp.Add(nums[j]);
					}
				}
				result.Add(temp);
			}
			return result;
		}
		public void Go()
		{
			Console.WriteLine(Subsets(Helper.GetArray(1, 2, 3)).ToArrayString2(true));
			Console.WriteLine(Subsets(Helper.GetArray(0)).ToArrayString2(true));
		}
	}
}
