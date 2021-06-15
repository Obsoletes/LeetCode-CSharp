using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	 统计所有小于非负整数 n 的质数的数量。
	 */
	public class Q204 : IQuestion
	{
		public int CountPrimes(int n)
		{
			List<int> prime = new List<int>();
			bool[] isP = new bool[n];
			for (int i = 2; i < n; i++)
			{
				if (!isP[i])
				{
					prime.Add(i);
				}
				for (int j = 0; j < prime.Count && i * prime[j] < n; j++)
				{
					isP[i * prime[j]] = true;
					if (i % prime[j] == 0)
					{
						break;
					}
				}
			}
			return prime.Count;
		}
		public void Go()
		{
			Console.WriteLine(CountPrimes(10));
			Console.WriteLine(CountPrimes(0));
			Console.WriteLine(CountPrimes(1));
		}
	}
}
