using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>对于给定的整数 n, 如果n的k（k>=2）进制数的所有数位全为1，则称 k（k>=2）是 n 的一个好进制。</para>
	/// <para>以字符串的形式给出 n, 以字符串的形式返回 n 的最小好进制。</para>
	/// </summary>
	public class Q483 : IQuestion
	{
		public string SmallestGoodBase(string n)
		{
			long number = long.Parse(n);
			//为什么LeetCode没有Math.Log2?
			int maxM = (int)Math.Floor(Math.Log(number) / Math.Log(2));
			for (int m = maxM; m > 1; m--)
			{
				var k = new BigInteger(Math.Pow(number, 1.0 / m));
				var sum = (1 - BigInteger.Pow(k, m + 1)) / (1 - k);

				if (sum == number)
					return k.ToString();
			}
			return (number - 1).ToString();
		}
		public void Go()
		{
			Console.WriteLine(SmallestGoodBase("16035713712910627"));
			Console.WriteLine(SmallestGoodBase("13"));
			Console.WriteLine(SmallestGoodBase("4681"));
			Console.WriteLine(SmallestGoodBase("1000000000000000000"));
		}
	}
}
