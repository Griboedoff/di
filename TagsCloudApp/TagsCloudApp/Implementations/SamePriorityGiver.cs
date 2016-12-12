using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Implementations
{
	class SamePriorityGiver : IPriorityGiver
	{
		public IEnumerable<TagCloudItem> SetPriorities(List<WordInfo> words)
		{
			var wordInfos = new HashSet<WordInfo>(words);
			var tagCloudItems = new List<TagCloudItem>();
			foreach (var word in wordInfos)
				tagCloudItems.Add(new TagCloudItem(Color.White, word, 10, new Font("Menlo", 10), default(Rectangle)));
			return tagCloudItems;
		}
	}
}