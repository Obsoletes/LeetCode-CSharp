using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给定一个字符串数组，将字母异位词组合在一起。字母异位词指字母相同，但排列不同的字符串。
	/// </summary>
	public class Q49
	{
		public IList<IList<string>> GroupAnagrams(string[] strs)
		{
			Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();
			foreach (var item in strs)
			{
				int[] arr = new int[26];
				foreach (var ch in item)
				{
					arr[ch - 'a']++;
				}
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < 26; i++)
				{
					if (arr[i] != 0)
						sb.Append((char)(i + 'a')).Append(arr[i]);
				}
				var key = sb.ToString(); ;
				if (dic.ContainsKey(key))
				{
					dic[key].Add(item);
				}
				else
				{
					var list = new List<string>(); ;
					list.Add(item);
					dic.Add(key, list);
				}
			}
			return dic.Values.ToList();
		}
		public void Go()
		{
			Console.WriteLine(GroupAnagrams(Helper.GetArray("eat", "tea", "tan", "ate", "nat", "bat")).ToArrayString2());
		}
	}
}
