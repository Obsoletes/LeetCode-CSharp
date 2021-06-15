using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>请你来实现一个 myAtoi(string s) 函数，使其能将字符串转换成一个 32 位有符号整数（类似 C/C++ 中的 atoi 函数）。</para>
	/// <para>函数 myAtoi(string s) 的算法如下：</para>
	/// <list type="bullet">
	///		<item>读入字符串并丢弃无用的前导空格</item>
	///		<item>检查下一个字符（假设还未到字符末尾）为正还是负号，读取该字符（如果有）。 确定最终结果是负数还是正数。 如果两者都不存在，则假定结果为正。</item>
	///		<item>读入下一个字符，直到到达下一个非数字字符或到达输入的结尾。字符串的其余部分将被忽略。</item>
	///		<item>将前面步骤读入的这些数字转换为整数（即，"123" -> 123， "0032" -> 32）。如果没有读入数字，则整数为 0 。必要时更改符号（从步骤 2 开始）。</item>
	///		<item>如果整数数超过 32 位有符号整数范围 [−231,  231 − 1] ，需要截断这个整数，使其保持在这个范围内。具体来说，小于 −231 的整数应该被固定为 −231 ，大于 231 − 1 的整数应该被固定为 231 − 1 。</item>
	///		<item>返回整数作为最终结果。</item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// <para>本题中的空白字符只包括空格字符 ' ' 。</para>
	/// <para>除前导空格或数字后的其余字符串外，请勿忽略 任何其他字符。</para>
	/// </remarks>
	public class Q8 : IQuestion
	{
		public int MyAtoi(string s)
		{
			bool isNeg = false;
			int res = 0;
			int i;
			for (i = 0; i < s.Length; i++)
			{
				if (s[i] == ' ')
					continue;
				else if (char.IsNumber(s[i]))
				{
					break;
				}
				else if (s[i] == '-')
				{
					isNeg = true;
					i++;
					break;
				}
				else if (s[i] == '+')
				{
					isNeg = false;
					i++;
					break;
				}
				else
				{
					return 0;
				}
			}
			try
			{
				for (; i < s.Length; i++)
				{
					if (char.IsNumber(s[i]))
					{
						checked
						{
							res = res * 10 + (s[i] - '0');
						}
					}
					else
					{
						break;
					}
				}
				return isNeg ? -1 * (int)res : (int)res;

			}
			catch (OverflowException)
			{
				return isNeg ? int.MinValue : int.MaxValue;
			}
		}
		public void Go()
		{
			Console.WriteLine(MyAtoi("42"));
			Console.WriteLine(MyAtoi("   -42"));
			Console.WriteLine(MyAtoi("4193 with words"));
			Console.WriteLine(MyAtoi("words and 987"));
			Console.WriteLine(MyAtoi("-91283472332"));
		}
	}
}
