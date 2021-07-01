using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个单词数组和一个长度 maxWidth，重新排版单词，使其成为每行恰好有 maxWidth 个字符，且左右两端对齐的文本。</para>
	/// <para>你应该使用“贪心算法”来放置给定的单词；也就是说，尽可能多地往每行中放置单词。必要时可用空格 ' ' 填充，使得每行恰好有 maxWidth 个字符。</para>
	/// <para>要求尽可能均匀分配单词间的空格数量。如果某一行单词间的空格不能均匀分配，则左侧放置的空格数要多于右侧的空格数。</para>
	/// <para>文本的最后一行应为左对齐，且单词之间不插入额外的空格。</para>
	/// </summary>
	/// <remarks>
	/// <para>单词是指由非空格字符组成的字符序列。</para>
	/// <para>每个单词的长度大于 0，小于等于 maxWidth。</para>
	/// <para>输入单词数组 words 至少包含一个单词。</para>
	/// </remarks>
	public class Q68 : IQuestion
	{
		public IList<string> FullJustify(string[] words, int maxWidth)
		{
			List<string> result = new List<string>();
			List<string> temp = new List<string>();
			int currentWidth = 0;
			foreach (var word in words)
			{
				if (currentWidth + (temp.Count - 1) + word.Length >= maxWidth)
				{
					result.Add(AsString(temp, currentWidth, maxWidth));
					currentWidth = 0;
					temp.Clear();
				}
				temp.Add(word);
				currentWidth += word.Length;
			}
			if (temp.Count != 0)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(string.Join(' ', temp));
				sb.Append(' ', maxWidth - sb.Length);
				result.Add(sb.ToString());
			}
			return result;
		}
		public string AsString(List<string> temp, int width, int maxWidth)
		{
			StringBuilder sb = new StringBuilder();
			if (temp.Count == 1)
			{
				sb.Append(temp[0]);
				sb.Append(' ', maxWidth - width);
				return sb.ToString();
			}
			int pre = (maxWidth - width) / (temp.Count - 1);
			int countOfBigSpace = maxWidth - width - pre * (temp.Count - 1);
			sb.Append(temp[0]);
			for (int i = 0; i < countOfBigSpace; i++)
			{
				sb.Append(' ', pre + 1);
				sb.Append(temp[i + 1]);
			}
			for (int i = countOfBigSpace + 1; i < temp.Count; i++)
			{
				sb.Append(' ', pre);
				sb.Append(temp[i]);
			}
			return sb.ToString();
		}
		public void Go()
		{
			Console.WriteLine(FullJustify(Helper.GetArray("ask", "not", "what", "your", "country", "can", "do", "for", "you", "ask", "what", "you", "can", "do", "for", "your", "country"), 16).ToArrayString());
			Console.WriteLine(FullJustify(Helper.GetArray("This", "is", "an", "example", "of", "text", "justification."), 16).ToArrayString());
			Console.WriteLine(FullJustify(Helper.GetArray("What", "must", "be", "acknowledgment", "shall", "be"), 16).ToArrayString());
			Console.WriteLine(FullJustify(Helper.GetArray("Science", "is", "what", "we", "understand", "well", "enough", "to", "explain",
		"to", "a", "computer.", "Art", "is", "everything", "else", "we", "do"), 20).ToArrayString());
		}
	}
}
