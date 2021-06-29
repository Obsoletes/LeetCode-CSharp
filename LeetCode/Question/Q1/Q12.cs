using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>罗马数字包含以下七种字符： I， V， X， L，C，D 和 M。</para>
	/// <list type="table">
	///		<listheader>
	///			<term>字符</term>
	///			<description>数值</description>
	///		</listheader>
	///		<item>
	///			<term>I</term>
	///			<description>1</description>
	///		</item>
	///		<item>
	///			<term>V</term><description>5</description>
	///		</item>
	///		<item>
	///			<term>X</term><description>10</description>
	///		</item>
	///		<item>
	///			<term>L</term><description>50</description>
	///		</item>
	///		<item>
	///			<term>C</term><description>100</description>
	///		</item>
	///		<item>
	///			<term>D</term><description>500</description>
	///		</item>
	///		<item>
	///			<term>M</term><description>1000</description>
	///		</item>
	/// </list>
	/// <para>例如， 罗马数字 2 写做 II ，即为两个并列的 1。12 写做 XII ，即为 X + II 。 27 写做  XXVII, 即为 XX + V + II 。</para>
	/// <para>通常情况下，罗马数字中小的数字在大的数字的右边。但也存在特例，例如 4 不写做 IIII，而是 IV。</para>
	/// <para>数字 1 在数字 5 的左边，所表示的数等于大数 5 减小数 1 得到的数值 4 。同样地，数字 9 表示为 IX。这个特殊的规则只适用于以下六种情况：</para>
	/// <list type="bullet">
	///		<item>I 可以放在 V(5) 和 X(10) 的左边，来表示 4 和 9。</item>
	///		<item>X 可以放在 L(50) 和 C(100) 的左边，来表示 40 和 90。 </item>
	///		<item>C 可以放在 D(500) 和 M(1000) 的左边，来表示 400 和 900。</item>
	/// </list>
	/// <para>给你一个整数，将其转为罗马数字。</para>
	/// </summary>
	public class Q12 : IQuestion
	{
		public string IntToRoman(int num)
		{
			StringBuilder sb = new StringBuilder();
			Dictionary<int, string> dic = new Dictionary<int, string>{
				{ 1000, "M" },
				{ 900, "CM" },
				{ 500, "D" },
				{ 400, "CD" },
				{ 100, "C" },
				{ 90, "XC" },
				{ 50, "L" },
				{ 40, "XL" },
				{ 10, "X" },
				{ 9, "IX" },
				{ 5, "V" },
				{ 4, "IV" },
				{ 1, "I" },
			};
			foreach (var item in dic)
			{
				while (num >= item.Key)
				{
					num -= item.Key;
					sb.Append(item.Value);
				}
			}
			return sb.ToString();
		}
		public void Go()
		{
			Console.WriteLine(IntToRoman(3));
			Console.WriteLine(IntToRoman(4));
			Console.WriteLine(IntToRoman(9));
			Console.WriteLine(IntToRoman(58));
			Console.WriteLine(IntToRoman(1994));
		}
	}
}
