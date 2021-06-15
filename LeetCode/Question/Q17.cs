using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	 给定一个仅包含数字 2-9 的字符串，返回所有它能表示的字母组合。答案可以按 任意顺序 返回。

	给出数字到字母的映射如下（与电话按键相同）。注意 1 不对应任何字母。	
	 */
	public class Q17 : IQuestion
	{
		private static Dictionary<char, string> Dic { get; } = new Dictionary<char, string>
		{
			{ '2', "abc" },
			{ '3', "def" },
			{ '4', "ghi" },
			{ '5', "jkl" },
			{ '6', "mno" },
			{ '7', "pqrs" },
			{ '8', "tuv" },
			{ '9', "wxyz" },
		};
		public IList<string> LetterCombinations(string digits)
		{
			List<string> list = new List<string>();
			foreach (var ch in digits)
			{
				var letter = Dic[ch];
				if (list.Count == 0)
					list.AddRange(letter.Select(c => c.ToString()));
				else
					list = letter.SelectMany(l => list.Select(c => c + l)).ToList();
			}
			return list;
		}
		public void Go()
		{
			Console.WriteLine($"[{string.Join(',', LetterCombinations("23"))}]");
			Console.WriteLine($"[{string.Join(',', LetterCombinations(""))}]");
			Console.WriteLine($"[{string.Join(',', LetterCombinations("2"))}]");
		}
	}
}
