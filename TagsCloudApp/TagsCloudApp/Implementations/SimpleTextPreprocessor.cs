using System.Collections.Generic;
using System.Linq;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Implementations
{
	internal class SimpleTextPreprocessor : ITextPreprocessor
	{
		private static readonly HashSet<string> BoringWords = new HashSet<string>
		{
			"he",
			"and",
			"it",
			"aboard",
			"about",
			"above",
			"across",
			"after",
			"against",
			"along",
			"amid",
			"among",
			"anti",
			"around",
			"as",
			"at",
			"before",
			"behind",
			"below",
			"beneath",
			"beside",
			"besides",
			"between",
			"beyond",
			"but",
			"by",
			"concerning",
			"considering",
			"despite",
			"down",
			"during",
			"except",
			"excepting",
			"excluding",
			"following",
			"for",
			"from",
			"in",
			"inside",
			"into",
			"like",
			"minus",
			"near",
			"of",
			"off",
			"on",
			"onto",
			"opposite",
			"outside",
			"over",
			"past",
			"per",
			"plus",
			"regarding",
			"round",
			"save",
			"since",
			"than",
			"the",
			"through",
			"to",
			"toward",
			"towards",
			"under",
			"underneath",
			"unlike",
			"until",
			"up",
			"upon",
			"versus",
			"via",
			"with",
			"within",
			"without"
		};

		public List<WordInfo> ProcessWords(IEnumerable<string> words)
		{
			return words.Select(w => w.ToLowerInvariant())
				.Where(CheckWord)
				.GroupBy(word => word)
				.Select(kv => new WordInfo(kv.Key, kv.Count()))
				.ToList();
		}

		private static bool CheckWord(string word)
		{
			return !(BoringWords.Contains(word) || word.Length < 2 ||
			         string.IsNullOrWhiteSpace(word) || string.IsNullOrEmpty(word));
		}
	}
}