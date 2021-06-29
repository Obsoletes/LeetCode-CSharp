using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个正整数 n ，输出外观数列的第 n 项。</para>
	/// </summary>
	public class Q38 : IQuestion
	{
		public string CountAndSay(int n)
		{
			if (n == 1)
				return "1";
			var prev = CountAndSay(n - 1);
			StringBuilder @string = new StringBuilder();
			int left = 0, right = 0;
			while (right < prev.Length)
			{
				if (prev[left] != prev[right])
				{
					@string.Append(right - left).Append(prev[left]);
					left = right;
				}
				right++;
			}
			@string.Append(right - left).Append(prev[left]);
			return @string.ToString();
		}
		public void Go()
		{
			Console.WriteLine(CountAndSay(1));
			Console.WriteLine(CountAndSay(4));
		}
	}
}
