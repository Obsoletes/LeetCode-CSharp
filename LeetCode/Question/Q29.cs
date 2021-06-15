using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	 给定两个整数，被除数 dividend 和除数 divisor。将两数相除，要求不使用乘法、除法和 mod 运算符。

	返回被除数 dividend 除以除数 divisor 得到的商。

	整数除法的结果应当截去（truncate）其小数部分，例如：truncate(8.345) = 8 以及 truncate(-2.7335) = -2
	 */
	public class Q29 : IQuestion
	{
		public int SmallDivide(long n1, long n2)
		{
			int i = 0;
			while (n1 >= n2)
			{
				n1 -= n2;
				i++;
			}
			return i;
		}
		public int Divide(int dividend, int divisor)
		{
			if (dividend == int.MinValue && divisor == -1)
			{
				return int.MaxValue;
			}
			var isNeg = (dividend ^ divisor) < 0;
			var n1 = Math.Abs((long)dividend);
			var n2 = Math.Abs((long)divisor);
			var l1 = n1.ToString().Length;
			var l2 = n2.ToString().Length;
			if (l2 > l1)
				return 0;
			var i = 0;
			var res = 0;
			var up = 0;
			while (i <= l1 - l2)
			{
				/*
							tr[0]	tr[1]	res
				 -----------------------
				/	d[0]	d[1]	d[2]
				/	dd[0]	dd[1]
				---------------------------
					0		t[0]			up
					└──────────┘			t1
				 */
				var pow = (int)Math.Pow(10, l1 - l2 - i);
				var t = n1 / pow;
				var t1 = t + up * 10;
				var tr = SmallDivide(t1, n2);
				res = res * 10 + tr;
				up = (int)(t1 - tr * n2);
				i++;
				n1 -= t * pow;
			}
			return isNeg ? -res : res;
		}
		public void Go()
		{
			Console.WriteLine(Divide(-1021989372, -82778243));

			Console.WriteLine(Divide(2147483647, 2));
			Console.WriteLine(Divide(10, 3));
			Console.WriteLine(Divide(7, 3));
			Console.WriteLine(Divide(9, 5));
		}
	}
}
