using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkovText
{
	public partial class Form1 : Form
	{
		private Random r = new Random();
		private Dictionary<string, Dictionary<char, int>> SubstringFollowerCount = new Dictionary<string, Dictionary<char, int>>();
		private Dictionary<string, Dictionary<double, char>> SubstringProbabilitiesCdf = new Dictionary<string, Dictionary<double, char>>();
		private int _charGroupLength = 0;

		public Form1()
		{
			InitializeComponent();
		}

		private void btnAnalyzeText_Click(object sender, EventArgs e)
		{
			string inputText = txtInputText.Text;
			string charGroupLengthStr = txtCharGroupLength.Text;

			if (String.IsNullOrWhiteSpace(inputText))
			{
				MessageBox.Show("Input text cannot be empty.");
				return;
			}
			
			if (!int.TryParse(charGroupLengthStr, out _charGroupLength) || _charGroupLength < 2)
			{
				MessageBox.Show("Invalid number of character group length. It must be at least 2.");
				return;
			}

			CrateMarkovChain(inputText);

			btnGenerateText.Enabled = true;
		}

		private void CrateMarkovChain(string inputText)
		{
			SubstringFollowerCount.Clear();
			SubstringProbabilitiesCdf.Clear();
			
			// Count instances of substrings and following letters in text
			int counter = 0;
			while (counter + _charGroupLength < inputText.Length)
			{
				var currentSubstring = inputText.Substring(counter, _charGroupLength);
				var lastChar = currentSubstring[currentSubstring.Length - 1];
				var truncatedSubstring = currentSubstring.Substring(0, currentSubstring.Length - 1);

				if (!SubstringFollowerCount.ContainsKey(truncatedSubstring))
				{
					SubstringFollowerCount.Add(truncatedSubstring, new Dictionary<char, int>());
				}

				if (!SubstringFollowerCount[truncatedSubstring].ContainsKey(lastChar))
				{
					SubstringFollowerCount[truncatedSubstring].Add(lastChar, 0);
				}

				SubstringFollowerCount[truncatedSubstring][lastChar]++;
				counter++;
			}

			// Calculate the CDF for the following letter of each substring
			foreach (var substrFollowers in SubstringFollowerCount)
			{
				int totalCount = substrFollowers.Value.Sum(x => x.Value);
				
				var tmpList = new List<Tuple<char, double>>();
				foreach (var sc in substrFollowers.Value)
				{
					tmpList.Add(Tuple.Create(sc.Key, (double)sc.Value / totalCount));
				}
				tmpList = tmpList.OrderBy(x => x.Item2).ToList();

				for (int i = 0; i < tmpList.Count; i++)
				{
					if (i > 0)
					{
						var currentElement = tmpList.ElementAt(i);
						tmpList.Insert(i, Tuple.Create(tmpList.ElementAt(i).Item1, tmpList.ElementAt(i).Item2 + tmpList.ElementAt(i - 1).Item2));
						tmpList.RemoveAt(i + 1);
					}
				}

				SubstringProbabilitiesCdf.Add(substrFollowers.Key, tmpList.ToDictionary(x => x.Item2, x => x.Item1));
			}
		}

		private void btnGenerateText_Click(object sender, EventArgs e)
		{
			if (!SubstringFollowerCount.Any())
			{
				MessageBox.Show("No input text has been analyzed.");
				return;
			}

			string charsToGenStr = txtCharsToGenerate.Text;

			int charsToGen;
			if (!int.TryParse(charsToGenStr, out charsToGen))
			{
				MessageBox.Show("Invalid number of characters to generate.");
			}

			var sb = new StringBuilder();
			var initialString = SubstringProbabilitiesCdf.Keys.ElementAt(r.Next(SubstringProbabilitiesCdf.Count));
			sb.Append(initialString);
			var currentString = initialString;

			for (int i = initialString.Length; i < charsToGen; i++)
			{
				var randomValue = r.NextDouble();
				var newLetter = SubstringProbabilitiesCdf.ContainsKey(currentString) ? SubstringProbabilitiesCdf[currentString].First(x => randomValue < x.Key).Value : ' ';
				sb.Append(newLetter);
				currentString = currentString.Substring(1) + newLetter;
			}
			
			txtGeneratedText.Text = sb.ToString();
		}
	}
}
