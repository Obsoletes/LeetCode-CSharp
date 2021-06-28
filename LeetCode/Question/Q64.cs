using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个包含非负整数的 m x n 网格 grid ，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。</para>
	/// </summary>
	/// <remarks>说明：每次只能向下或者向右移动一步。</remarks>
	public class Q64 : IQuestion
	{
		public int MinPathSum(int[][] grid)
		{
			int col = grid.Length;
			int row = grid[0].Length;
			int[,] map = new int[col, row];
			map[0, 0] = grid[0][0];
			for (int i = 1; i < col; i++)
			{
				map[i, 0] = map[i - 1, 0] + grid[i][0];
			}
			for (int i = 1; i < row; i++)
			{
				map[0, i] = map[0, i - 1] + grid[0][i];
			}
			for (int i = 1; i < col; i++)
			{
				for (int j = 1; j < row; j++)
				{
					map[i, j] = Math.Min(map[i - 1, j], map[i, j - 1]) + grid[i][j];
				}
			}
			return map[col - 1, row - 1];
		}
		public void Go()
		{
			Console.WriteLine(MinPathSum(Helper.GetArray(Helper.GetArray(1, 3, 1), Helper.GetArray(1, 5, 1), Helper.GetArray(4, 2, 1))));
			Console.WriteLine(MinPathSum(Helper.GetArray(Helper.GetArray(1, 2, 3), Helper.GetArray(4, 5, 6))));
		}
	}
}
