using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>	n 皇后问题 研究的是如何将 n 个皇后放置在 n×n 的棋盘上，并且使皇后彼此之间不能相互攻击。</para>
	/// <para>	给你一个整数 n ，返回所有不同的 n 皇后问题 的解决方案。</para>
	/// <para>	每一种解法包含一个不同的 n 皇后问题 的棋子放置方案，该方案中 'Q' 和 '.' 分别代表了皇后和空位。</para>
	/// </summary>
	public class Q51 : IQuestion
	{
		public void DFS(List<int> pos, List<IList<string>> result, int current)
		{
			if (current == pos.Count - 1)
			{
				for (int i = 0; i < pos.Count; i++)
				{
					pos[current] = i;
					if (IsVaild(pos, current))
					{
						result.Add(PosToString(pos));
						return;
					}
				}
				return;
			}
			for (int i = 0; i < pos.Count; i++)
			{
				pos[current] = i;
				if (IsVaild(pos, current))
					DFS(pos, result, current + 1);
			}
		}
		public List<string> PosToString(List<int> pos)
		{
			int count = pos.Count;
			StringBuilder sb = new StringBuilder(count);
			List<string> result = new List<string>();
			foreach (var item in pos)
			{
				sb.Append('.', item);
				sb.Append('Q');
				if (count >= 2)
					sb.Append('.', count - item - 1);
				result.Add(sb.ToString());
				sb.Clear();
			}
			return result;
		}
		public bool IsVaild(List<int> pos, int current)
		{
			int j = current;
			for (int i = 0; i < current; i++)
			{
				if ((i != j) && (pos[i] == pos[j] || (i - j == pos[i] - pos[j]) || (j - i == pos[i] - pos[j])))
					return false;
			}
			return true;
		}
		public IList<IList<string>> SolveNQueens(int n)
		{
			List<IList<string>> result = new List<IList<string>>();
			List<int> pos = new List<int>(n);
			for (int i = 0; i < n; i++)
			{
				pos.Add(0);
			}
			DFS(pos, result, 0);
			return result;
		}
		public void Go()
		{
			Console.WriteLine(SolveNQueens(4).ToArrayString2());
			Console.WriteLine(SolveNQueens(1).ToArrayString2());
		}
	}
}
