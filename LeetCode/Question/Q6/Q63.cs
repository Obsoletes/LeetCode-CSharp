using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为“Start” ）。</para>
	/// <para>机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为“Finish”）。</para>
	/// <para>现在考虑网格中有障碍物。那么从左上角到右下角将会有多少条不同的路径？</para>
	/// </summary>
	public class Q63 : IQuestion
	{
		public int UniquePathsWithObstacles(int[][] obstacleGrid)
		{
			int m = obstacleGrid.Length, n = obstacleGrid[0].Length;
			var dp = new int[m, n];
			for (int i = 0; i < m; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (obstacleGrid[i][j] == 1)
						dp[i, j] = 0;
					else
					{
						if (i == 0 && j == 0) dp[i, j] = 1;
						else if (i == 0) dp[i, j] = dp[i, j - 1];
						else if (j == 0) dp[i, j] = dp[i - 1, j];
						else dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
					}
				}
			}
			return dp[m - 1, n - 1];
		}
		public void Go()
		{
			Console.WriteLine(UniquePathsWithObstacles(Helper.GetArray<int[]>(Helper.GetArray(0, 0))));
			Console.WriteLine(UniquePathsWithObstacles(Helper.GetArray(Helper.GetArray(0, 0, 0), Helper.GetArray(0, 1, 0), Helper.GetArray(0, 0, 0))));
			Console.WriteLine(UniquePathsWithObstacles(Helper.GetArray(Helper.GetArray(0, 1), Helper.GetArray(0, 0))));
		}
	}
}
