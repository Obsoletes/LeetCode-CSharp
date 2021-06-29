using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个无重复元素的数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。</para>
	/// <para>candidates 中的每个数字在每个组合中只能使用一次。</para>
	/// </summary>
	/// <remarks>
	/// <para>所有数字（包括 target）都是正整数。</para>
	/// <para>解集不能包含重复的组合。 </para>
	/// </remarks>
	public class Q40 : IQuestion
	{
		public IList<IList<int>> CombinationSum2(int[] candidates, int target)
		{
			Dictionary<int, List<IList<int>>> dic = new Dictionary<int, List<IList<int>>>();
			Dictionary<int, int> count = new Dictionary<int, int>();
			var distinctSet = candidates.Distinct().ToList();
			foreach (var item in candidates)
			{
				if (count.ContainsKey(item))
				{
					count[item]++;
				}
				else
				{
					count.Add(item, 1);
				}
			}
			for (int i = 0; i <= target; i++)
			{
				dic.Add(i, new List<IList<int>>());
			}
			for (int i = 1; i <= target; i++)
			{
				foreach (var item in distinctSet)
				{
					if (item > i) { }
					else if (item == i)
					{
						dic[i].Add(new List<int> { i });
					}
					else
					{
						var currentList = dic[i];
						foreach (var list in dic[i - item])
						{
							if (list.Count == 0 || list.Last() <= item)
							{
								if (list.Where(l => l == item).Count() <= count[item] - 1)
								{
									var temp = new List<int>(list);
									temp.Add(item);
									currentList.Add(temp);
								}
							}

						}
					}
				}
			}
			return dic[target];
		}
		public void Go()
		{
			Console.WriteLine(CombinationSum2(Helper.GetArray(10, 1, 2, 7, 6, 1, 5), 8).ToArrayString2());
			Console.WriteLine(CombinationSum2(Helper.GetArray(2, 5, 2, 1, 2), 5).ToArrayString2());
		}
	}
}
