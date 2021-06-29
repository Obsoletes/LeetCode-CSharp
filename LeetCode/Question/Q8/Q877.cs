using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>亚历克斯和李用几堆石子在做游戏。偶数堆石子排成一行，每堆都有正整数颗石子 piles[i] 。</para>
	/// <para>游戏以谁手中的石子最多来决出胜负。石子的总数是奇数，所以没有平局。</para>
	/// <para>亚历克斯和李轮流进行，亚历克斯先开始。 每回合，玩家从行的开始或结束处取走整堆石头。 
	/// 这种情况一直持续到没有更多的石子堆为止，此时手中石子最多的玩家获胜。</para>
	/// <para>假设亚历克斯和李都发挥出最佳水平，当亚历克斯赢得比赛时返回 true ，当李赢得比赛时返回 false 。</para>
	/// </summary>
	public class Q877 : IQuestion
	{
		public bool StoneGame(int[] piles)
		{
			var dp = new int[piles.Length];
			piles.CopyTo(dp, 0);
			for (int i = dp.Length - 2; i >= 0; i--)
			{
				for (int j = i + 1; j < dp.Length; j++)
				{
					dp[j] = Math.Max(piles[i] - dp[j], piles[j] - dp[j - 1]);
				}
			}
			return dp[dp.Length - 1] > 0;
		}
		public void Go()
		{
			Console.WriteLine(StoneGame(Helper.GetArray(5, 3, 4, 5)));
		}
	}
}
