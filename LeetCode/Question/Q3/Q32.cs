using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给你一个只包含 '(' 和 ')' 的字符串，找出最长有效（格式正确且连续）括号子串的长度。
	/// </summary>
	public class Q32 : IQuestion
	{
		public int LongestValidParentheses(string s)
		{
			Stack<int> stack = new Stack<int>();
			int max = 0;
			stack.Push(-1);
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '(')
				{
					stack.Push(i);
				}
				else
				{
					stack.Pop();
					if (stack.Count == 0)
					{
						stack.Push(i);
					}
					else
					{
						max = Math.Max(max, i - stack.First());

					}
				}
			}

			return max;
		}
		public void Go()
		{
			Console.WriteLine(LongestValidParentheses("(()"));
			Console.WriteLine(LongestValidParentheses("(()"));
			Console.WriteLine(LongestValidParentheses(")()())"));
			Console.WriteLine(LongestValidParentheses(""));
		}
	}
}
