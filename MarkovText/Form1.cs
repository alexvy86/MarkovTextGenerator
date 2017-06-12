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
			
			if (!int.TryParse(charGroupLengthStr, out int charGroupLength) || charGroupLength < 2)
			{
				MessageBox.Show("Invalid number of character group length. It must be at least 2.");
				return;
			}

			CrateMarkovChain(inputText, charGroupLength);

			btnGenerateText.Enabled = true;
		}

		private void CrateMarkovChain(string inputText, int charGroupLength)
		{
			SubstringFollowerCount.Clear();
			SubstringProbabilitiesCdf.Clear();
			
			// Count instances of substrings and following letters in text
			int counter = 0;
			while (counter + charGroupLength < inputText.Length)
			{
				var currentSubstring = inputText.Substring(counter, charGroupLength);
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
				
				var tmpList = new List<(char Character, double Probability)>();
				foreach (var sc in substrFollowers.Value)
				{
					tmpList.Add((sc.Key, (double)sc.Value / totalCount));
				}
				tmpList = tmpList.OrderBy(x => x.Probability).ToList();

				for (int i = 1; i < tmpList.Count; i++)
				{
                    var currentElement = tmpList.ElementAt(i);
                    var newTuple = (tmpList.ElementAt(i).Character, tmpList.ElementAt(i).Probability + tmpList.ElementAt(i - 1).Probability);
                    tmpList.Insert(i, newTuple);
                    tmpList.RemoveAt(i + 1);
                }

				SubstringProbabilitiesCdf.Add(substrFollowers.Key, tmpList.ToDictionary(x => x.Probability, x => x.Character));
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

			if (!int.TryParse(charsToGenStr, out int charsToGen))
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
                char newLetter = ' ';
                if (SubstringProbabilitiesCdf.TryGetValue(currentString, out var cdf))
                {
                    newLetter = cdf.First(x => randomValue < x.Key).Value;
                }
				sb.Append(newLetter);
				currentString = currentString.Substring(1) + newLetter;
			}
			
			txtGeneratedText.Text = sb.ToString();
		}
	}
}
