using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Implementations
{
	internal class SamePrioritySetter : IPrioritySetter
	{
		public List<TagCloudItem> SetPriorities(IEnumerable<WordInfo> words)
		{
			var wordInfos = new HashSet<WordInfo>(words);
			return wordInfos
				.Select(word => new TagCloudItem(Color.Red, word, new Font("Menlo", 10), new Rectangle(0, 0, 100, 40)))
				.ToList();
		}
	}
}