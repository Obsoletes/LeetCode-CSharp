using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给你一个字符串 s，由若干单词组成，单词之间用空格隔开。返回字符串中最后一个单词的长度。如果不存在最后一个单词，请返回 0 。</para>
	/// <para>单词 是指仅由字母组成、不包含任何空格字符的最大子字符串。</para>
	/// </summary>
	public class Q58 : IQuestion
	{
		public int LengthOfLastWord(string s)
		{
			ReadOnlySpan<char> span = s.AsSpan();
			while (span.Length != 0 && span[^1] == ' ')
			{
				span = span[..^1];
			}
			int length = 0;
			while (span.Length != 0 && span[^1] != ' ')
			{
				length++;
				span = span[..^1];
			}
			return length;
		}
		public void Go()
		{
			Console.WriteLine(LengthOfLastWord("Hello World"));
			Console.WriteLine(LengthOfLastWord(" "));
		}
	}
}
