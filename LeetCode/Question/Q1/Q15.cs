using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给你一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？请你找出所有和为 0 且不重复的三元组。
	/// </summary>
	/// <remarks>答案中不可以包含重复的三元组</remarks>
	public class Q15 : IQuestion
	{
		public IList<IList<int>> ThreeSum(int[] nums)
		{
			if (nums.Length < 3)
				return new List<IList<int>>();
			var result = new List<IList<int>>();
			Dictionary<int, int> dic = new Dictionary<int, int>();
			foreach (var item in nums)
			{
				if (dic.ContainsKey(item))
				{
					dic[item]++;
				}
				else
				{
					dic.Add(item, 1);
				}
			}
			if (dic.ContainsKey(0) && dic[0] >= 3)
			{
				result.Add(new List<int> { 0, 0, 0 });
			}
			foreach (var item in dic)
			{
				foreach (var item2 in dic)
				{
					if (item.Key <= item2.Key)
					{
						if (item.Key == item2.Key)
						{
							if (item.Value == 1)
								continue;
						}
						var thridKey = 0 - item.Key - item2.Key;
						if (item.Key == item2.Key && thridKey == 0 && item.Key == thridKey)
							continue;
						if (dic.ContainsKey(thridKey))
						{
							if (item2.Key <= thridKey)
							{
								var thrid = dic[thridKey];
								if (thridKey == item.Key || thridKey == item2.Key)
								{
									if (thrid != 1)
										result.Add(new List<int> { item.Key, item2.Key, thridKey });
								}
								else
									result.Add(new List<int> { item.Key, item2.Key, thridKey });
							}
						}
					}
				}
			}
			return result;
		}
		public void Go()
		{
			Console.WriteLine(ThreeSum(Helper.GetArray(-1, 0, 1, 2, -1, -4)).ToArrayString2());
			Console.WriteLine(ThreeSum(Helper.GetArray(0)).ToArrayString2());
			Console.WriteLine(ThreeSum(Helper.GetArray<int>()).ToArrayString2());
		}
	}
}
