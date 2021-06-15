using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	 给你一个以字符串形式表述的 布尔表达式（boolean） expression，返回该式的运算结果。

	有效的表达式需遵循以下约定：

	"t"，运算结果为 True
	"f"，运算结果为 False
	"!(expr)"，运算过程为对内部表达式 expr 进行逻辑 非的运算（NOT）
	"&(expr1,expr2,...)"，运算过程为对 2 个或以上内部表达式 expr1, expr2, ... 进行逻辑 与的运算（AND）
	"|(expr1,expr2,...)"，运算过程为对 2 个或以上内部表达式 expr1, expr2, ... 进行逻辑 或的运算（OR）
	 */
	public class Q1106 : IQuestion
	{
		class Scanner
		{
			public Scanner(string exp)
			{
				Expression = exp;
				Postion = 0;
			}
			public bool Calc()
			{
				return Expr();
			}
			private bool Expr()
			{
				char ch = Next();
				switch (ch)
				{
					case 'f': case 't': return Lex();
					case '!': return Not();
					case '|': return Or();
					case '&': return And();
					default: return Error();
				}
			}
			private bool Lex()
			{
				Skip();
				char ch = Next();
				if (ch == 'f')
				{
					Accept('f');
					return false;
				}
				if (ch == 't')
				{
					Accept('t');
					return true;
				}
				return Error();
			}
			private bool Not()
			{
				Skip();
				Accept('!');
				Accept('(');
				var exp = Expr();
				Accept(')');
				return !exp;
			}
			private bool Or()
			{
				Skip();
				Accept('|');
				Accept('(');
				var exp1 = Expr();
				while (true)
				{
					var ch = Next();
					if (ch == ',')
					{
						Accept(',');
						var exp2 = Expr();
						exp1 = exp1 || exp2;
					}
					else
					{
						Accept(')');
						break;
					}
				}
				return exp1;
			}
			private bool And()
			{
				Skip();
				Accept('&');
				Accept('(');
				var exp1 = Expr();
				while (true)
				{
					var ch = Next();
					if (ch == ',')
					{
						Accept(',');
						var exp2 = Expr();
						exp1 = exp1 && exp2;
					}
					else
					{
						Accept(')');
						break;
					}
				}
				return exp1;
			}

			private void Skip()
			{
				while (Next() == ' ') { Accept(' '); };
			}
			private char Next(int p = 0)
			{
				if ((Postion + p) >= Expression.Length)
				{
					return '\0';
				}
				return Expression[Postion + p];
			}
			private void Accept(char ch)
			{
				if (Next() == ch)
					Postion++;
				else
					Error();
			}
			private static bool Error()
			{
				throw new Exception("语法错误");
			}
			public string Expression { get; set; }
			public int Postion { get; set; }
		}
		public bool ParseBoolExpr(string expression)
		{
			return new Scanner(expression).Calc();
		}
		public void Go()
		{
			Console.WriteLine(ParseBoolExpr("!(f)"));
			Console.WriteLine(ParseBoolExpr("|(f,t)"));
			Console.WriteLine(ParseBoolExpr("&(t,f)"));
			Console.WriteLine(ParseBoolExpr("|(&(t,f,t),!(t))"));
		}
	}
}
