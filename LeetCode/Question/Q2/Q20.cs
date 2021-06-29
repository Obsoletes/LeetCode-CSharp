using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串 s ，判断字符串是否有效。</para>
	/// <para>有效字符串需满足：</para>
	/// <list type="number">
	///		<item>左括号必须用相同类型的右括号闭合。</item>
	///		<item>左括号必须以正确的顺序闭合。</item>
	/// </list>
	/// </summary>
	public class Q20 : IQuestion
	{
		public bool IsValid(string s)
		{
			var stack = new Stack<char>();
			try
			{
				foreach (var item in s)
				{
					if (item == '(' || item == '[' || item == '{')
					{
						stack.Push(item);
					}
					if (item == ')')
					{
						if (stack.Pop() != '(')
							return false;
					}
					if (item == ']')
					{
						if (stack.Pop() != '[')
							return false;
					}
					if (item == '}')
					{
						if (stack.Pop() != '{')
							return false;
					}
				}
				return stack.Count == 0;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public void Go()
		{
			Console.WriteLine(IsValid("()"));
			Console.WriteLine(IsValid("()[]{}"));
			Console.WriteLine(IsValid("(]"));
			Console.WriteLine(IsValid("([)]"));
			Console.WriteLine(IsValid("{[]}"));
		}
	}
}
