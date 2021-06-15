using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	 数字 n 代表生成括号的对数，请你设计一个函数，用于能够生成所有可能的并且 有效的 括号组合。
	 */
	public class Q22 : IQuestion
	{
		public void GenerateParenthesis(List<string> list, string str, int left, int right)
		{
			if (left == 0 && right == 0)
			{
				list.Add(str);
				return;
			}
			if (left == right)
			{
				GenerateParenthesis(list, str + '(', left - 1, right);
				return;
			}
			if (left < right)
			{
				if (left > 0)
				{
					GenerateParenthesis(list, str + '(', left - 1, right);
				}
				GenerateParenthesis(list, str + ')', left, right - 1);
			}
		}
		public IList<string> GenerateParenthesis(int n)
		{
			List<string> list = new List<string>();

			GenerateParenthesis(list, "", n, n);
			return list;
		}
		public void Go()
		{
			Console.WriteLine($"[{string.Join(',', GenerateParenthesis(3))}]");
			Console.WriteLine($"[{string.Join(',', GenerateParenthesis(1))}]");
		}
	}
}
