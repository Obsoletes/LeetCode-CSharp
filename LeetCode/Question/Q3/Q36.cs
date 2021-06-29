using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	///	<para> 请你判断一个 9x9 的数独是否有效。只需要 根据以下规则 ，验证已经填入的数字是否有效即可。</para>
	///	<list type='number'>
	///	<item>数字 1-9 在每一行只能出现一次。</item>
	///	<item>数字 1-9 在每一列只能出现一次。</item>
	///	<item>数字 1-9 在每一个以粗实线分隔的 3x3 宫内只能出现一次。（请参考示例图）</item>
	/// </list>
	/// <para>数独部分空格内已填入了数字</para>
	/// <para>注意：</para>
	///	<list type='bullet'>
	///	<item>一个有效的数独（部分已被填充）不一定是可解的。</item>
	///	<item>只需要根据以上规则，验证已经填入的数字是否有效即可。</item>
	/// </list>
	/// </summary>
	public class Q36 : IQuestion
	{
		public bool IsValidSudoku(char[][] board)
		{
			var row = new bool[9, 9];
			var col = new bool[9, 9];
			var block = new bool[3, 3, 9];
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					if (board[i][j] != '.')
					{
						var num = board[i][j] - '1';
						if (row[i, num] || col[j, num] || block[i / 3, j / 3, num])
						{
							return false;
						}
						row[i, num] = col[j, num] = block[i / 3, j / 3, num] = true;
					}
				}
			}
			return true;
		}
		public void Go()
		{
			var board = Helper.GetArray(
			Helper.GetArray('5', '3', '.', '.', '7', '.', '.', '.', '.'),
			Helper.GetArray('6', '.', '.', '1', '9', '5', '.', '.', '.'),
			Helper.GetArray('.', '9', '8', '.', '.', '.', '.', '6', '.'),
			Helper.GetArray('8', '.', '.', '.', '6', '.', '.', '.', '3'),
			Helper.GetArray('4', '.', '.', '8', '.', '3', '.', '.', '1'),
			Helper.GetArray('7', '.', '.', '.', '2', '.', '.', '.', '6'),
			Helper.GetArray('.', '6', '.', '.', '.', '.', '2', '8', '.'),
			Helper.GetArray('.', '.', '.', '4', '1', '9', '.', '.', '5'),
			Helper.GetArray('.', '.', '.', '.', '8', '.', '.', '7', '9')
			);
			Console.WriteLine(IsValidSudoku(board));
			board[0][0] = '8';
			Console.WriteLine(IsValidSudoku(board));
		}
	}
}
