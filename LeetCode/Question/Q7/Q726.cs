using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个化学式formula（作为字符串），返回每种原子的数量。</para>
	/// <para>原子总是以一个大写字母开始，接着跟随0个或任意个小写字母，表示原子的名字。</para>
	/// <para>如果数量大于 1，原子后会跟着数字表示原子的数量。如果数量等于 1 则不会跟数字。例如，H2O 和 H2O2 是可行的，但 H1O2 这个表达是不可行的。</para>
	/// <para>两个化学式连在一起是新的化学式。例如 H2O2He3Mg4 也是化学式。</para>
	/// <para>一个括号中的化学式和数字（可选择性添加）也是化学式。例如(H2O2) 和(H2O2)3 是化学式。</para>
	/// <para>给定一个化学式，输出所有原子的数量。格式为：第一个（按字典序）原子的名子，跟着它的数量（如果数量大于 1），然后是第二个原子的名字（按字典序），跟着它的数量（如果数量大于 1），以此类推。</para>
	/// </summary>
	public class Q726 : IQuestion
	{
		void AddOrUpdate(IDictionary<string, int> dic, string key, int value)
		{
			if (dic.ContainsKey(key))
			{
				dic[key] += value;
			}
			else
			{
				dic.Add(key, value);
			}
		}
		SortedDictionary<string, int> CountOfAtoms(ReadOnlySpan<char> span)
		{
			SortedDictionary<string, int> dic = new SortedDictionary<string, int>();
			while (span.Length > 0)
			{
				if (char.IsUpper(span[0]))
				{
					int i = 0;
					while (i + 1 < span.Length && char.IsLower(span[i + 1]))
					{
						i++;
					}
					i++;
					string key = new string(span[..i]);
					span = span[i..];
					i = 0;
					int value = 0;
					while (span.Length > 0 && char.IsNumber(span[0]))
					{
						value = value * 10 + (span[0] - '0');
						span = span[1..];
					}
					value = value == 0 ? 1 : value;
					AddOrUpdate(dic, key, value);
				}
				else if (span[0] == '(')
				{
					int count = 0;
					int i = 0;
					while (i < span.Length)
					{
						if (span[i] == '(')
						{
							count++;
						}
						else if (span[i] == ')')
						{
							count--;
						}
						if (count == 0)
							break;
						i++;
					}
					var last = i;
					var res = CountOfAtoms(span[1..last]);
					int radio;
					span = span[(last + 1)..];
					radio = 0;
					while (span.Length > 0 && char.IsNumber(span[0]))
					{
						radio = radio * 10 + (span[0] - '0');
						span = span[1..];
					}
					radio = radio == 0 ? 1 : radio;
					foreach (var kv in res)
					{
						AddOrUpdate(dic, kv.Key, kv.Value * radio);
					}
				}
			}
			return dic;
		}
		public string CountOfAtoms(string formula)
		{
			var dic = CountOfAtoms(formula.AsSpan());
			StringBuilder stringBuilder = new StringBuilder();
			foreach (var kv in dic)
			{
				stringBuilder.Append(kv.Key);
				if (kv.Value > 1)
					stringBuilder.Append(kv.Value);
			}
			return stringBuilder.ToString();
		}
		public void Go()
		{
			Console.WriteLine(CountOfAtoms("(NB3)33"));
			Console.WriteLine(CountOfAtoms("H2O"));
			Console.WriteLine(CountOfAtoms("Mg(OH)2"));
			Console.WriteLine(CountOfAtoms("K4(ON(SO3)2)2"));
			Console.WriteLine(CountOfAtoms("((N42)24(OB40Li30CHe3O48LiNN26)33(C12Li48N30H13HBe31)21(BHN30Li26BCBe47N40)15(H5)16)14"));
		}
	}
}
