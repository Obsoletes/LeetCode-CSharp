using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给出集合 [1,2,3,...,n]，其所有元素共有 n! 种排列。</para>
	/// <para>按大小顺序列出所有排列情况，并一一标记，当 n = 3 时, 所有排列如下：</para>
	/// <list type="number">
	/// <item>"123"</item>
	/// <item>"132"</item>
	/// <item>"213"</item>
	/// <item>"231"</item>
	/// <item>"312"</item>
	/// <item>"321"</item>
	/// </list>
	/// <para>给定 n 和 k，返回第 k 个排列。</para>
	/// </summary>
	public class Q60 : IQuestion
	{
		/// <summary>
		/// 逆康托展开
		/// </summary>
		/// <param name="n"></param>
		/// <param name="k"></param>
		/// <returns></returns>
		public string Decantor(int n, int k)
		{
			int[] factor = new int[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
			List<int> chs = new List<int>();
			StringBuilder sb = new StringBuilder();
			k--;
			for (int i = 0; i < n; i++)
			{
				chs.Add(i + 1);
			}
			for (int i = n - 1; i >= 0; i--)
			{
				int o = k / factor[i];
				sb.Append(chs[o]);
				chs.RemoveAt(o);
				k %= factor[i];
			}
			return sb.ToString();
		}
		public string GetPermutation(int n, int k)
		{
			return Decantor(n, k);
		}
		public void Go()
		{
			Console.WriteLine(GetPermutation(3, 3));
			Console.WriteLine(GetPermutation(4, 9));
			Console.WriteLine(GetPermutation(3, 1));
		}
	}
}
