using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定两个以字符串形式表示的非负整数 num1 和 num2，返回 num1 和 num2 的乘积，它们的乘积也表示为字符串形式。</para>
	/// </summary>
	public class Q43 : IQuestion
	{
		public string Multiply(string num1, string num2)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append('0', num1.Length + num2.Length);
			int up = 0;
			for (int i = 0; i < num2.Length; i++)
			{
				for (int j = 0; j < num1.Length; j++)
				{
					int res = (num1[^(j + 1)] - '0') * (num2[^(i + 1)] - '0') + up + (sb[i + j] - '0');
					up = res / 10;
					res %= 10;
					sb[i + j] = (char)(res + '0');
				}
				if (up != 0)
				{
					sb[i + num1.Length] = (char)(up + '0');
					up = 0;
				}
			}
			var result = string.Join(null, sb.ToString().Reverse()).TrimStart('0');
			return result.Length == 0 ? "0" : result;
		}
		public void Go()
		{
			Console.WriteLine(Multiply("999", "999"));
			Console.WriteLine(Multiply("2", "3"));
			Console.WriteLine(Multiply("123", "456"));
		}
	}
}
