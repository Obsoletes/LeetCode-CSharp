using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给你一个 无重叠的 ，按照区间起始端点排序的区间列表。</para>
	/// <para>在列表中插入一个新的区间，你需要确保列表中的区间仍然有序且不重叠（如果有必要的话，可以合并区间）。</para>
	/// </summary>
	public class Q57 : IQuestion
	{
		class Compare : IComparer<int[]>
		{
			int IComparer<int[]>.Compare(int[] x, int[] y)
			{
				return x[0] - y[0];
			}
		}
		public int[][] Insert(int[][] intervals, int[] newInterval)
		{
			List<int[]> result = new List<int[]>();
			List<int[]> input = new List<int[]>(intervals);
			input.Add(newInterval);
			if (input.Count == 0)
				return Array.Empty<int[]>();
			input.Sort(new Compare());
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
			Console.WriteLine(Insert(Helper.GetArray(Helper.GetArray(1, 3), Helper.GetArray(6, 9)), Helper.GetArray(2, 5)).ToArrayString2());
			Console.WriteLine(Insert(Helper.GetArray(Helper.GetArray(1, 2), Helper.GetArray(3, 5),
			Helper.GetArray(6, 7), Helper.GetArray(8, 10), Helper.GetArray(12, 16)), Helper.GetArray(4, 8)).ToArrayString2());
			Console.WriteLine(Insert(Helper.GetArray<int[]>(Helper.GetArray(1, 5)), Helper.GetArray(2, 3)).ToArrayString2());
			Console.WriteLine(Insert(Helper.GetArray<int[]>(Helper.GetArray(1, 5)), Helper.GetArray(2, 7)).ToArrayString2());
		}
	}
}
