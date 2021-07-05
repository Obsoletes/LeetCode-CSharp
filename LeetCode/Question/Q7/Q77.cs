using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给定两个整数 n 和 k，返回 1 ... n 中所有可能的 k 个数的组合。
	/// </summary>
	public class Q77 : IQuestion
	{
		public void Combine(int n, int k, int j, List<IList<int>> list, LinkedList<int> current)
		{
			if (k == 0)
			{
				list.Add(current.ToList());
				return;
			}
			for (int i = j; i < n; i++)
			{
				current.AddLast(i + 1);
				Combine(n, k - 1, i + 1, list, current);
				current.RemoveLast();
			}
		}
		public IList<IList<int>> Combine(int n, int k)
		{
			List<IList<int>> list = new List<IList<int>>();
			Combine(n, k, 0, list, new LinkedList<int>());
			return list.ToList();
		}
		public void Go()
		{
			Console.WriteLine(Combine(4, 2).ToArrayString2(true));
		}
	}
}
