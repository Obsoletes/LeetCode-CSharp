using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>将一个给定字符串 s 根据给定的行数 numRows ，以从上往下、从左到右进行 Z 字形排列。</para>
	/// <para>比如输入字符串为 "PAYPALISHIRING" 行数为 3 时，排列如下：</para>
	/// <para>P | A | H | N</para>
	/// <para>A P L S I I G</para>
	/// <para>Y | I | R</para>
	/// <para>之后，你的输出需要从左往右逐行读取，产生出一个新的字符串，比如："PAHNAPLSIIGYIR"。</para>
	/// <para>请你实现这个将字符串进行指定行数变换的函数：</para>
	/// </summary>
	public class Q6 : IQuestion
	{
		public string Convert(string s, int numRows)
		{
			StringBuilder sb = new StringBuilder(s.Length);
			var part = numRows * 2 - 2;
			if (part == 0)
			{
				return s;
			}
			var round = s.Length / part + 1;
			for (int i = 0; i < round; i++)
			{
				sb.Append(Try(i * part));
			}
			for (int i = 1; i < numRows - 1; i++)
			{
				for (int j = 0; j < round; j++)
				{
					sb.Append(Try(j * part + i));
					sb.Append(Try((j + 1) * part - i));
				}
			}
			for (int i = 0; i < round; i++)
			{
				sb.Append(Try(i * part + numRows - 1));
			}
			return sb.ToString();
			char? Try(int pos)
			{
				if (pos >= s.Length)
					return null;
				return s[pos];
			}
		}
		public void Go()
		{
			Console.WriteLine(Convert("PAYPALISHIRING", 3));
			Console.WriteLine(Convert("PAYPALISHIRING", 4));
			Console.WriteLine(Convert("A", 1));
		}
	}
}
