using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>夏日炎炎，小男孩 Tony 想买一些雪糕消消暑。</para>
	/// <para>商店中新到 n 支雪糕，用长度为 n 的数组 costs 表示雪糕的定价，其中 costs[i] 表示第 i 支雪糕的现金价格。Tony 一共有 coins 现金可以用于消费，他想要买尽可能多的雪糕。</para>
	/// <para>给你价格数组 costs 和现金量 coins ，请你计算并返回 Tony 用 coins 现金能够买到的雪糕的 最大数量 。</para>
	/// </summary>
	/// <remarks>注意：Tony 可以按任意顺序购买雪糕。</remarks>
	public class Q1833 : IQuestion
	{
		public int MaxIceCream(int[] costs, int coins)
		{
			Array.Sort(costs);
			int i;
			for (i = 0; i < costs.Length && coins >= costs[i]; i++)
			{
				coins -= costs[i];
			}
			return i;
		}
		public void Go()
		{
			Console.WriteLine(MaxIceCream(Helper.GetArray(1, 3, 2, 4, 1), 7));
			Console.WriteLine(MaxIceCream(Helper.GetArray(10, 6, 8, 7, 7, 8), 5));
			Console.WriteLine(MaxIceCream(Helper.GetArray(1, 6, 3, 1, 2, 5), 20));
		}
	}
}
