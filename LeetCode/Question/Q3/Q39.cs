using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个无重复元素的数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。</para>
	/// <para>candidates 中的数字可以无限制重复被选取。</para>
	/// </summary>
	/// <remarks>
	/// <para>所有数字（包括 target）都是正整数。</para>
	/// <para>解集不能包含重复的组合。 </para>
	/// </remarks>
	public class Q39 : IQuestion
	{
		public IList<IList<int>> CombinationSum(int[] candidates, int target)
		{
			Dictionary<int, List<IList<int>>> dic = new Dictionary<int, List<IList<int>>>();
			for (int i = 0; i <= target; i++)
			{
				dic.Add(i, new List<IList<int>>());
			}
			for (int i = 1; i <= target; i++)
			{
				foreach (var item in candidates)
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
								var temp = new List<int>(list);
								temp.Add(item);
								currentList.Add(temp);
							}

						}
					}
				}
			}
			return dic[target];
		}
		public void Go()
		{
			Console.WriteLine(CombinationSum(Helper.GetArray(2, 3, 6, 7), 7).ToArrayString2());
			Console.WriteLine(CombinationSum(Helper.GetArray(2, 3, 5), 8).ToArrayString2());
		}
	}
}
