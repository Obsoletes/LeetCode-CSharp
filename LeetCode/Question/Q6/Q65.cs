using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>有效数字（按顺序）可以分成以下几个部分：</para>
	/// <list type="number">
	/// <item>一个 小数 或者 整数</item>
	/// <item>（可选）一个 'e' 或 'E' ，后面跟着一个 整数</item>
	/// </list>
	/// <para>小数（按顺序）可以分成以下几个部分：</para>
	/// <list type="number">
	/// <item>（可选）一个符号字符（'+' 或 '-'）</item>
	/// <item>
	/// 下述格式之一：
	///		<list type="number">
	///			<item>（至少一位数字，后面跟着一个点 '.'</item>
	///			<item>至少一位数字，后面跟着一个点 '.' ，后面再跟着至少一位数字</item>
	///			<item>一个点 '.' ，后面跟着至少一位数字</item>
	///		</list>
	///	</item>
	/// </list>
	/// <para>整数（按顺序）可以分成以下几个部分：</para>
	/// <list type="number">
	/// <item>（可选）一个符号字符（'+' 或 '-'）</item>
	/// <item>至少一位数字</item>
	/// </list>
	/// <para>部分有效数字列举如下：</para>
	/// <para>["2", "0089", "-0.1", "+3.14", "4.", "-.9", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789"]</para>
	/// <para>部分无效数字列举如下：</para>
	/// <para>["abc", "1a", "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53"]</para>
	/// <para>给你一个字符串 s ，如果 s 是一个 有效数字 ，请返回 true 。</para>
	/// </summary>
	/**
	 * ValidNumber ::= <Integer> [<ESign> <Number>] | <Float> [<ESign> <Number>]
	 * Sign ::= '+' | '-'
	 * ESign ::= 'e' | 'E'
	 * Integer ::= [Sign] <Number>
	 * Float ::=  [Sign] <FloatDetail>
	 * FloatDetail ::= <Number> '.' | <Number> '.' <Number> | '.' <Number>
	 * Number ::= {N}
	 * N ::= '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' 
	 */
	public class Q65 : IQuestion
	{
		class Scanner
		{
			public Scanner(string exp)
			{
				Expression = exp;
				Postion = 0;
			}
			public bool IsValid()
			{
				return ValidNumber() && End();
			}
			public bool ValidNumber()
			{
				bool succ = false;
				if (Float())
				{
					succ = true;
				}
				else
				{
					Postion = 0;
					if (Integer())
						succ = true;
				}
				if (succ)
				{
					if (ESign())
					{
						return Integer();
					}
					return true;
				}
				else
					return false;
			}
			public bool Sign()
			{
				char ch = Next();
				if (ch == '+' || ch == '-')
					return Accept(ch);
				else
					return Error();
			}
			public bool ESign()
			{
				char ch = Next();
				if (ch == 'e' || ch == 'E')
					return Accept(ch);
				else
					return Error();
			}
			public bool Integer()
			{
				Sign();
				return Number();
			}
			public bool Float()
			{
				Sign();
				return FloatDetail();
			}
			public bool FloatDetail()
			{
				char ch = Next();
				if (ch == '.')
				{
					Accept('.');
					return Number();
				}
				bool res = Number();
				if (!res)
					return false;
				ch = Next();
				if (ch == '.')
				{
					Accept('.');
					Number();
					return true;
				}
				else
					return false;
			}
			public bool Number()
			{
				bool has = false;
				while (true)
				{
					if (!N())
						break;
					else
						has = true;
				}
				return has;
			}
			public bool N()
			{
				char ch = Next();
				if (char.IsNumber(ch))
					return Accept(ch);
				else
					return Error();
			}
			private bool End()
			{
				return Postion == Expression.Length;
			}
			private char Next()
			{
				if (Postion >= Expression.Length)
				{
					return '\0';
				}
				return Expression[Postion];
			}
			private bool Accept(char ch)
			{
				if (Next() == ch)
					Postion++;
				else
					return Error();
				return true;
			}
			private static bool Error()
			{
				return false;
			}
			public string Expression { get; set; }
			public int Postion { get; set; }
		}
		public bool IsNumber(string s)
		{
			return new Scanner(s).IsValid();
		}
		public void Go()
		{
			Console.WriteLine(IsNumber("005047e+6"));
			Console.WriteLine(IsNumber("0.."));
			Console.WriteLine(IsNumber("0"));
			Console.WriteLine(IsNumber("e"));
			Console.WriteLine(IsNumber("."));
			Console.WriteLine(IsNumber(".1"));
		}

	}
}
