using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给你一个整数 columnNumber ，返回它在 Excel 表中相对应的列名称。
	/// </summary>
	public class Q168 : IQuestion
	{
		public string ConvertToTitle(int columnNumber)
		{
			StringBuilder sb = new StringBuilder();
			while (columnNumber != 0)
			{
				columnNumber--;
				sb.Append((char)(columnNumber % 26 + 'A'));
				columnNumber /= 26;
			}
			return string.Join(null, sb.ToString().Reverse());
		}
		public void Go()
		{
			Console.WriteLine(ConvertToTitle(52));
			Console.WriteLine(ConvertToTitle(1));
			Console.WriteLine(ConvertToTitle(28));
			Console.WriteLine(ConvertToTitle(701));
			Console.WriteLine(ConvertToTitle(2147483647));
		}
	}
}
