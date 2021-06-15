using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	 罗马数字包含以下七种字符: I， V， X， L，C，D 和 M。

	字符          数值
	I             1
	V             5
	X             10
	L             50
	C             100
	D             500
	M             1000
	例如， 罗马数字 2 写做 II ，即为两个并列的 1。12 写做 XII ，即为 X + II 。 27 写做  XXVII, 即为 XX + V + II 。

	通常情况下，罗马数字中小的数字在大的数字的右边。
	但也存在特例，例如 4 不写做 IIII，而是 IV。数字 1 在数字 5 的左边，所表示的数等于大数 5 减小数 1 得到的数值 4 。
	同样地，数字 9 表示为 IX。这个特殊的规则只适用于以下六种情况：

	I 可以放在 V (5) 和 X (10) 的左边，来表示 4 和 9。
	X 可以放在 L (50) 和 C (100) 的左边，来表示 40 和 90。 
	C 可以放在 D (500) 和 M (1000) 的左边，来表示 400 和 900。
	给定一个罗马数字，将其转换成整数。输入确保在 1 到 3999 的范围内。
	 */
	public class Q13 : IQuestion
	{
		public int RomanToInt(string s)
		{
			int res = 0;
			for (int i = 0; i < s.Length; i++)
			{
				if (i == s.Length - 1)
					res += s[i] switch
					{
						'M' => 1000,
						'D' => 500,
						'C' => 100,
						'L' => 50,
						'X' => 10,
						'V' => 5,
						'I' => 1,
						_ => 0,
					};
				else
				{
					res += s[i] switch
					{
						'M' => 1000,
						'D' => 500,
						'L' => 50,
						'V' => 5,
						_ => 0,
					};
					if (s[i] == 'C')
					{
						if (s[i + 1] == 'M')
						{
							i++;
							res += 900;
						}
						else if (s[i + 1] == 'D')
						{
							i++;
							res += 400;
						}
						else
							res += 100;
					}
					if (s[i] == 'X')
					{
						if (s[i + 1] == 'L')
						{
							i++;
							res += 40;
						}
						else if (s[i + 1] == 'C')
						{
							i++;
							res += 90;
						}
						else
							res += 10;
					}
					if (s[i] == 'I')
					{
						if (s[i + 1] == 'V')
						{
							i++;
							res += 4;
						}
						else if (s[i + 1] == 'X')
						{
							i++;
							res += 9;
						}
						else
							res += 1;
					}
				}
			}
			return res;
		}
		public void Go()
		{
			Console.WriteLine(RomanToInt("III"));
			Console.WriteLine(RomanToInt("IV"));
			Console.WriteLine(RomanToInt("IV"));
			Console.WriteLine(RomanToInt("LVIII"));
			Console.WriteLine(RomanToInt("MCMXCIV"));
		}
	}
}
