using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>编写一个程序，通过填充空格来解决数独问题。</para>
	/// <para>数独的解法需 遵循如下规则：</para>
	/// <list type="number">
	///	<item>数字 1-9 在每一行只能出现一次。</item>
	///	<item>数字 1-9 在每一列只能出现一次。</item>
	///	<item>数字 1-9 在每一个以粗实线分隔的 3x3 宫内只能出现一次。（请参考示例图）</item>
	/// </list>
	/// <para>数独部分空格内已填入了数字，空白格用 '.' 表示。</para>
	/// </summary>
	public class Q37 : IQuestion
	{
		private bool DFS(char[][] board, bool[,] row, bool[,] col, bool[,,] block, int posI, int posJ)
		{
			while (board[posI][posJ] != '.')
			{
				posJ++;
				if (posJ == 9)
				{
					posJ = 0;
					posI++;
				}
				if (posI == 9)
					return true;
			}
			for (int i = 0; i < 9; i++)
			{
				if (row[posI, i] || col[posJ, i] || block[posI / 3, posJ / 3, i])
				{

				}
				else
				{
					row[posI, i] = col[posJ, i] = block[posI / 3, posJ / 3, i] = true;
					board[posI][posJ] = (char)(i + '1');
					if (DFS(board, row, col, block, posI, posJ))
					{
						return true;
					}
					else
					{
						row[posI, i] = col[posJ, i] = block[posI / 3, posJ / 3, i] = false;
						board[posI][posJ] = '.';
					}
				}
			}
			return false;
		}
		public void SolveSudoku(char[][] board)
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
						row[i, num] = col[j, num] = block[i / 3, j / 3, num] = true;
					}
				}
			}
			DFS(board, row, col, block, 0, 0);
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
			Print(board);
			SolveSudoku(board);
			Console.WriteLine();
			Print(board);
		}
		private void Print(char[][] board)
		{
			Console.WriteLine("\n┏━━━━━━━━┯━━━━━━━━┯━━━━━━━━┓");
			for (int i = 0; i < 9; i++)
			{
				Console.Write("┃ ");
				for (int j = 0; j < 9; j++)
				{
					Console.Write(board[i][j]);
					if (j == 8)
						Console.Write('┃');
					else
						Console.Write("│ ");
				}
				if (i == 8)
					Console.WriteLine("\n┗━━━━━━━━┷━━━━━━━━┷━━━━━━━━┛");
				else
					Console.WriteLine("\n┠────────┼────────┼────────┨");
			}
		}
	}
}
