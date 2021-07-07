using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个 m x n 二维字符网格 board 和一个字符串单词 word 。如果 word 存在于网格中，返回 true ；否则，返回 false 。</para>
	/// <para>单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母不允许被重复使用。</para>
	/// </summary>
	public class Q79 : IQuestion
	{
		public bool Exist(char[][] board, string word)
		{
			bool[,] used = new bool[board.Length, board[0].Length];
			var span = word.AsSpan();
			for (int i = 0; i < board.Length; i++)
			{
				for (int j = 0; j < board[0].Length; j++)
				{
					if (board[i][j] == word[0])
					{
						if (Check(board, span, i, j, used))
						{
							return true;
						}
					}
				}
			}
			return false;
		}
		public bool Check(char[][] board, ReadOnlySpan<char> word, int x, int y, bool[,] used)
		{
			if (x < 0 || y < 0)
				return false;
			if (x >= board.Length || y >= board[0].Length)
				return false;
			if (used[x, y])
				return false;
			if (board[x][y] == word[0])
			{
				used[x, y] = true;
				var next = word[1..];
				if (next.Length == 0)
					return true;
				var res = Check(board, next, x + 1, y, used) ||
				Check(board, next, x - 1, y, used) ||
				Check(board, next, x, y + 1, used) ||
				Check(board, next, x, y - 1, used);
				if (res)
					return true;
				used[x, y] = false;
			}
			return false;
		}
		public void Go()
		{
			var board = Helper.GetArray(
				Helper.GetArray('A', 'B', 'C', 'E'),
				Helper.GetArray('S', 'F', 'C', 'S'),
				Helper.GetArray('A', 'D', 'E', 'E'));

			Console.WriteLine(Exist(board, "ABCCED"));
			Console.WriteLine(Exist(board, "SEE"));
			Console.WriteLine(Exist(board, "ABCB"));
		}
	}
}
