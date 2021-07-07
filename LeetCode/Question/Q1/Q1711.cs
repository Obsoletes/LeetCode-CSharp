using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>大餐 是指 恰好包含两道不同餐品 的一餐，其美味程度之和等于 2 的幂。</para>
	/// <para>你可以搭配 任意 两道餐品做一顿大餐。</para>
	/// <para>给你一个整数数组 deliciousness ，其中 deliciousness[i] 是第 i​​​​​​​​​​​​​​ 道餐品的美味程度，返回你可以用数组中的餐品做出的不同 大餐 的数量。结果需要对 10e9 + 7 取余。</para>
	/// <para>注意，只要餐品下标不同，就可以认为是不同的餐品，即便它们的美味程度相同。</para>
	/// </summary>
	public class Q1711 : IQuestion
	{
		public int CountPairs(int[] deliciousness)
		{
			int max = 0;
			long result = 0;
			Dictionary<int, int> dic = new Dictionary<int, int>();
			foreach (var item in deliciousness)
			{
				if (item > max)
					max = item;
				if (!dic.ContainsKey(item))
					dic.Add(item, 0);
			}
			int maxDelicious = max * 2;
			int[] pow = new int[(int)(Math.Log(maxDelicious) / Math.Log(2)) + 1];
			pow[0] = 1;
			for (int i = 1; i < pow.Length; i++)
			{
				pow[i] = pow[i - 1] * 2;
			}
			foreach (var item in deliciousness)
			{
				for (int i = 0; i < pow.Length; i++)
					result += dic.GetValueOrDefault(pow[i] - item, 0);
				dic[item]++;
			}
			return (int)(result % 1000000007);
		}
		public void Go()
		{
			Console.WriteLine(CountPairs(Helper.GetArray(1, 3, 5, 7, 9)));
			Console.WriteLine(CountPairs(Helper.GetArray(1, 1, 1, 3, 3, 3, 7)));
			Console.WriteLine(CountPairs(Helper.GetArray(149, 107, 1, 63, 0, 1, 6867, 1325, 5611, 2581, 39, 89, 46, 18, 12, 20, 22, 234)));
			//[]
		}
	}
}
