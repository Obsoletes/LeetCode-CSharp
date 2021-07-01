using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 以数组 intervals 表示若干个区间的集合，其中单个区间为 intervals[i] = [starti, endi] 。请你合并所有重叠的区间，并返回一个不重叠的区间数组，该数组需恰好覆盖输入中的所有区间。
	/// </summary>
	public class Q56 : IQuestion
	{
		public int[][] Merge(int[][] intervals)
		{
			List<int[]> result = new List<int[]>();
			if (intervals.Length == 0)
				return Array.Empty<int[]>();
			var input = intervals.OrderBy(i => i[0]).ToList();
			result.Add(input[0]);
			for (int i = 1; i < input.Count; i++)
			{
				if (input[i][0] <= result[^1][1])
				{
					result[^1][1] = Math.Max(input[i][1], result[^1][1]);
					result[^1][0] = Math.Min(input[i][0], result[^1][0]);
				}
				else
				{
					result.Add(input[i]);
				}
			}
			return result.ToArray();
		}
		public void Go()
		{
			Console.WriteLine(Merge(Helper.GetArray(Helper.GetArray(1, 3), Helper.GetArray(2, 6),
			Helper.GetArray(8, 10), Helper.GetArray(15, 18))).ToArrayString2());
			Console.WriteLine(Merge(Helper.GetArray(Helper.GetArray(1, 4), Helper.GetArray(4, 5))).ToArrayString2());
		}
	}
}
