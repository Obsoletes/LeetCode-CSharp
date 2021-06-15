using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{

	/*
	 编写一个函数来查找字符串数组中的最长公共前缀。

	如果不存在公共前缀，返回空字符串 ""。
	 */
	public class Q14 : IQuestion
	{
		public string LongestCommonPrefix(string[] strs)
		{
			if (strs.Length == 0)
				return "";
			string s = strs[0];
			foreach (var item in strs)
			{
				if (item.Length < s.Length)
					s = item;
			}
			while (s.Length != 0)
			{
				if (strs.All(str => str.StartsWith(s)))
					return s;
				else
					s = s.Substring(0, s.Length - 1);
			}
			return "";
		}
		public void Go()
		{
			Console.WriteLine(LongestCommonPrefix(Helper.GetArray("flower", "flow", "flight")));
			Console.WriteLine(LongestCommonPrefix(Helper.GetArray("dog", "racecar", "car")));
		}
	}
}
