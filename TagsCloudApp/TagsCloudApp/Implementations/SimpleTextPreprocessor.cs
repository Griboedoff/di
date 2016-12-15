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
			var counter = new Dictionary<string, int>();
			var c = 0;
			foreach (var word in words.Where(word => !BoringWords.Contains(word.ToLowerInvariant())))
			{
				if (!counter.ContainsKey(word))
					counter.Add(word, 0);
				counter[word]++;
				c++;
			}
			return counter
				.Select(kv => new WordInfo(kv.Key, kv.Value / c))
				.ToList();
		}
	}
}