using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给你两个二进制字符串，返回它们的和（用二进制表示）。</para>
	/// <para>输入为 非空 字符串且只包含数字 1 和 0。</para>
	/// </summary>
	public class Q67 : IQuestion
	{
		public string AddBinary(string a, string b)
		{
			string large, small;
			if (a.Length > b.Length)
			{
				small = b;
				large = a;
			}
			else
			{
				small = a;
				large = b;
			}
			StringBuilder @string = new StringBuilder();
			StringBuilder smallPad = new StringBuilder();
			smallPad.Append('0', large.Length - small.Length);
			smallPad.Append(small);
			bool isUp = false;
			for (int i = large.Length - 1; i >= 0; i--)
			{
				var temp = (large[i] - '0') + (smallPad[i] - '0') + (isUp ? 1 : 0);
				isUp = temp >= 2;
				@string.Append(temp % 2);
			}
			if (isUp)
			{
				@string.Append(1);
			}

			return string.Join(null, @string.ToString().Reverse());
		}
		public void Go()
		{
			Console.WriteLine(AddBinary("11", "1"));
			Console.WriteLine(AddBinary("1010", "1011"));
		}

	}
}
