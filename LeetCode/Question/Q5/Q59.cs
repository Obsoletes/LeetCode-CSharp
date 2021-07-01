using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给你一个正整数 n ，生成一个包含 1 到 n2 所有元素，且元素按顺时针顺序螺旋排列的 n x n 正方形矩阵 matrix 。
	/// </summary>
	public class Q59 : IQuestion
	{
		public int[][] GenerateMatrix(int n)
		{
			var maxLayer = (int)Math.Ceiling(n / 2.0);
			int[][] result = new int[n][];
			for (int i = 0; i < n; i++)
			{
				result[i] = new int[n];
			}
			int num = 1;
			for (int layer = 0; layer < maxLayer; layer++)
			{
				int cn = n - 2 * layer;
				for (int i = layer; i <= n - layer - 1; i++)
				{
					result[layer][i] = num++;
				}
				for (int i = layer + 1; i < n - layer - 1; i++)
				{
					result[i][n - layer - 1] = num++;
				}
				if (cn != 1)
					for (int i = layer; i <= n - layer - 1; i++)
					{
						result[n - layer - 1][n - i - 1] = num++;
					}

				for (int i = layer + 1; i < n - layer - 1; i++)
				{
					result[n - i - 1][layer] = num++;
				}
			}
			return result;
		}
		public void Go()
		{
			Console.WriteLine(GenerateMatrix(3).ToArrayString2());
			Console.WriteLine(GenerateMatrix(1).ToArrayString2());
			Console.WriteLine(GenerateMatrix(4).ToArrayString2());
			Console.WriteLine(GenerateMatrix(5).ToArrayString2());
		}
	}
}
