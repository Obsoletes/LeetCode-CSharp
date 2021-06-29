using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给你一个字符串表达式 s ，请你实现一个基本计算器来计算并返回它的值。
	/// </summary>
	public class Q224 : IQuestion
	{
		class Scanner
		{
			public Scanner(string str)
			{
				pos = 0;
				Str = str;
			}
			public string Str { get; set; }
			private int pos;
			public int Calc()
			{
				return Expr();
			}
			public char Op()
			{
				Skip();
				char ch = Next();
				if (ch == '+')
				{
					Accept('+');
					return '+';
				}
				if (ch == '-')
				{
					Accept('-');
					return '-';
				}
				else
				{
					return ' ';
				}
			}
			public int Number()
			{
				Skip();
				var res = 0;
				var isNeg = false;
				var hasOp = false;
				var noNum = true;
				while (true)
				{
					var ch = Next();
					if (noNum && ch == '+')
					{
						isNeg = false;
						hasOp = true;
						Accept('+');
					}
					if (noNum && ch == '-')
					{
						isNeg = true;
						hasOp = true;
						Accept('-');
					}
					if (char.IsNumber(ch))
					{
						res = res * 10 + ch - '0';
						noNum = false;
						Accept(ch);
					}
					else
					{
						if (hasOp)
							Back();
						break;
					}
				}
				return isNeg ? -res : res;
			}
			public int Factor()
			{
				Skip();
				char ch = Next();
				if (ch == '(')
				{
					Accept('(');
					var num = Expr();
					Accept(')');
					return num;
				}
				if (char.IsNumber(ch) || ch == '+' || ch == '-')
				{
					return Number();
				}
				return Error();
			}
			public int Expr()
			{
				Skip();
				var n1 = Factor();
				var op = Op();
				while (op != ' ')
				{
					var n2 = Factor();
					if (op == '-')
						n1 -= n2;
					else if (op == '+')
						n1 += n2;
					else
						break;
					op = Op();
				}
				return n1;
			}
			private void Skip()
			{
				while (Next() == ' ') { Accept(' '); };
			}
			private char Next(int p = 0)
			{
				if ((pos + p) >= Str.Length)
				{
					return '\0';
				}
				return Str[pos + p];
			}
			private void Accept(char ch)
			{
				if (Next() == ch)
					pos++;
				else
					Error();
			}
			private void Back()
			{
				pos--;
			}
			private static int Error()
			{
				throw new Exception("语法错误");
			}
		}
		public int Calculate(string s)
		{
			return new Scanner(s).Calc();
		}
		public void Go()
		{
			Console.WriteLine(Calculate("1 + 1"));
			Console.WriteLine(Calculate(" 2-1 + 2 "));
			Console.WriteLine(Calculate("(1+(4+5+2)-3)+(6+8)"));
		}
	}
}
