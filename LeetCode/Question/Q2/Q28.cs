using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>实现 strStr() 函数。</para>
	/// <para>给你两个字符串 haystack 和 needle ，请你在 haystack 字符串中找出 needle 字符串出现的第一个位置（下标从 0 开始）。如果不存在，则返回  -1 。</para>
	/// </summary>
	public class Q28 : IQuestion
	{
		public int StrStr(string haystack, string needle)
		{
			if (needle.Length == 0)
				return 0;
			for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
			{
				if (haystack[i] == needle[0])
				{
					bool has = true;
					for (int j = 1; j < needle.Length; j++)
					{
						if (haystack[i + j] != needle[j])
						{
							has = false;
							break;
						}
					}
					if (has)
						return i;
				}
			}
			return -1;
		}
		public void Go()
		{
			Console.WriteLine(StrStr("hello", "ll"));
			Console.WriteLine(StrStr("aaaaa", "bba"));
			Console.WriteLine(StrStr("", ""));
			Console.WriteLine(StrStr("abc", "bc"));
		}
	}
}
