using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给你一个 m 行 n 列的矩阵 matrix ，请按照 顺时针螺旋顺序 ，返回矩阵中的所有元素。
	/// </summary>
	public class Q54 : IQuestion
	{
		public IList<int> SpiralOrder(int[][] matrix)
		{
			var maxLayer = (int)Math.Ceiling(Math.Min(matrix.Length, matrix[0].Length) / 2.0);
			var n = matrix.Length;
			var m = matrix[0].Length;
			List<int> result = new List<int>(m * n);

			for (int layer = 0; layer < maxLayer; layer++)
			{
				int cm = m - 2 * layer, cn = n - 2 * layer;
				for (int i = layer; i <= m - layer - 1; i++)
				{
					result.Add(matrix[layer][i]);
				}
				for (int i = layer + 1; i < n - layer - 1; i++)
				{
					result.Add(matrix[i][m - layer - 1]);
				}
				if (cn != 1)
					for (int i = layer; i <= m - layer - 1; i++)
					{
						result.Add(matrix[n - layer - 1][m - i - 1]);
					}
				if (cm != 1)
					for (int i = layer + 1; i < n - layer - 1; i++)
					{
						result.Add(matrix[n - i - 1][layer]);
					}
			}
			return result;
		}
		public void Go()
		{
			Console.WriteLine(SpiralOrder(Helper.GetArray<int[]>(Helper.GetArray(1, 2, 3))).ToArrayString());
			Console.WriteLine(SpiralOrder(Helper.GetArray(Helper.GetArray(1, 2, 3), Helper.GetArray(4, 5, 6), Helper.GetArray(7, 8, 9))).ToArrayString());
			Console.WriteLine(SpiralOrder(Helper.GetArray(Helper.GetArray(1, 2, 3, 4), Helper.GetArray(5, 6, 7, 8), Helper.GetArray(9, 10, 11, 12))).ToArrayString());
			Console.WriteLine(SpiralOrder(Helper.GetArray(Helper.GetArray(1, 2, 3, 4), Helper.GetArray(5, 6, 7, 8), Helper.GetArray(9, 10, 11, 12), Helper.GetArray(13, 14, 15, 16))).ToArrayString());
		}
	}
}
