using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个 n × n 的二维矩阵 matrix 表示一个图像。请你将图像顺时针旋转 90 度。</para>
	/// <para>你必须在 原地 旋转图像，这意味着你需要直接修改输入的二维矩阵。请不要 使用另一个矩阵来旋转图像。</para>
	/// </summary>
	public class Q48 : IQuestion
	{
		public void Rotate(int[][] matrix)
		{
			var n = matrix.Length;
			var maxLayer = (int)Math.Ceiling(n / 2.0);
			for (int layer = 0; layer < maxLayer; layer++)
			{

				for (int i = 0; i < n - 2 * layer - 1; i++)
				{
					int leftTopX = layer + 0,
					leftTopY = layer + i,
					rightTopX = layer + i,
					rightTopY = n - 1 - layer,
					leftButtomX = n - i - 1 - layer,
					leftButtomY = 0 + layer,
					rightButtomX = n - 1 - layer,
					rightButtomY = n - i - 1 - layer;
					int first = matrix[leftTopX][leftTopY];
					matrix[leftTopX][leftTopY] = matrix[leftButtomX][leftButtomY];
					matrix[leftButtomX][leftButtomY] = matrix[rightButtomX][rightButtomY];
					matrix[rightButtomX][rightButtomY] = matrix[rightTopX][rightTopY];
					matrix[rightTopX][rightTopY] = first;
				}
			}
		}
		public void Go()
		{
			var matrix1 = Helper.GetArray(Helper.GetArray(1, 2, 3), Helper.GetArray(4, 5, 6), Helper.GetArray(7, 8, 9));
			Rotate(matrix1);
			Print(matrix1);
			var matrix2 = Helper.GetArray(Helper.GetArray(5, 1, 9, 11), Helper.GetArray(2, 4, 8, 10), Helper.GetArray(13, 3, 6, 7), Helper.GetArray(15, 14, 12, 16));
			Rotate(matrix2);
			Print(matrix2);
			var matrix3 = Helper.GetArray<int[]>(Helper.GetArray(1));
			Rotate(matrix3);
			Print(matrix3);
			var matrix4 = Helper.GetArray(Helper.GetArray(1, 2), Helper.GetArray(3, 4));
			Rotate(matrix4);
			Print(matrix4);
		}
		private void Print(int[][] board)
		{
			var n = board.Length;
			StringBuilder sb1, sb2, sb3;
			sb1 = new StringBuilder("\n┏");
			sb2 = new StringBuilder("\n┗");
			sb3 = new StringBuilder("\n┠");
			for (int i = 0; i < n; i++)
			{
				sb1.Append("━━━┯");
				sb2.Append("━━━┷");
				sb3.Append("───┼");
			}
			sb1[^1] = '┓';
			sb2[^1] = '┛';
			sb3[^1] = '┨';
			string e1, e2, e3;
			e1 = sb1.ToString();
			e2 = sb2.ToString();
			e3 = sb3.ToString();
			Console.WriteLine(e1);
			for (int i = 0; i < n; i++)
			{
				Console.Write("┃ ");
				for (int j = 0; j < n; j++)
				{
					Console.Write("{0,2}", board[i][j]);
					if (j == n - 1)
						Console.Write("┃ ");
					else
						Console.Write("│ ");
				}
				if (i == n - 1)
					Console.WriteLine(e2);
				else
					Console.WriteLine(e3);
			}
		}
	}
}
