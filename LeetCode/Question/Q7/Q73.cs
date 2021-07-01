using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给定一个 m x n 的矩阵，如果一个元素为 0 ，则将其所在行和列的所有元素都设为 0 。请使用 原地 算法。
	/// </summary>
	public class Q73 : IQuestion
	{
		public void SetZeroes(int[][] matrix)
		{
			bool fRow, fCol = false;
			fRow = matrix[0].Any(i => i == 0);
			for (int i = 0; i < matrix.Length && !fCol; i++)
			{
				if (matrix[i][0] == 0)
					fCol = true;
			}
			for (int i = 0; i < matrix.Length; i++)
			{
				for (int j = 0; j < matrix[0].Length; j++)
				{
					if (matrix[i][j] == 0) matrix[i][0] = matrix[0][j] = 0;
				}
			}
			for (int i = 1; i < matrix.Length; i++)
			{
				if (matrix[i][0] == 0)
				{
					Array.Fill(matrix[i], 0);
				}
			}
			for (int i = 1; i < matrix[0].Length; i++)
			{
				if (matrix[0][i] == 0)
				{
					for (int j = 1; j < matrix.Length; j++)
					{
						matrix[j][i] = 0;
					}
				}
			}
			if (fRow) Array.Fill(matrix[0], 0);
			if (fCol)
			{
				for (int j = 1; j < matrix.Length; j++)
				{
					matrix[j][0] = 0;
				}
			}
		}
		public void Go()
		{
			var m1 = Helper.GetArray(Helper.GetArray(1, 1, 1), Helper.GetArray(1, 0, 1), Helper.GetArray(1, 1, 1));
			SetZeroes(m1);
			Console.WriteLine(m1.ToArrayString2());
			var m2 = Helper.GetArray(Helper.GetArray(0, 1, 2, 0), Helper.GetArray(3, 4, 5, 2), Helper.GetArray(1, 3, 1, 5));
			SetZeroes(m2);
			Console.WriteLine(m2.ToArrayString2());
		}
	}
}
