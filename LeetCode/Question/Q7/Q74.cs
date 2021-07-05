using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>编写一个高效的算法来判断 m x n 矩阵中，是否存在一个目标值。该矩阵具有如下特性：</para>
	/// <list type="bullet">
	/// <item>每行中的整数从左到右按升序排列。</item>
	/// <item>每行的第一个整数大于前一行的最后一个整数。</item>
	/// </list>
	/// </summary>
	public class Q74 : IQuestion
	{
		public bool SearchMatrix(int[][] matrix, int target)
		{
			int m = matrix[0].Length, n = matrix.Length;
			int right = m * n - 1, left = 0; ;
			int mid;
			while (left <= right)
			{
				mid = (right + left) / 2;
				var center = matrix[mid / m][mid % m];
				if (center == target)
					return true;
				if (center > target)
				{
					right = mid - 1;
				}
				else
				{
					left = mid + 1;
				}
			}
			return false;
		}
		public void Go()
		{
			Console.WriteLine(SearchMatrix(Helper.GetArray(
			Helper.GetArray(1, 3, 5, 7),
			Helper.GetArray(10, 11, 16, 20),
			Helper.GetArray(23, 30, 34, 60)
			), 3));
			Console.WriteLine(SearchMatrix(Helper.GetArray(
			Helper.GetArray(1, 3, 5, 7),
			Helper.GetArray(10, 11, 16, 20),
			Helper.GetArray(23, 30, 34, 60)
			), 13));
		}
	}
}
