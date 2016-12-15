using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Implementations
{
	internal class SamePrioritySetter : IPrioritySetter
	{
		public List<TagCloudItem> SetPriorities(IEnumerable<WordInfo> words, TagCloudSettings settings)
		{
			var wordInfos = new HashSet<WordInfo>(words);
			var g = Graphics.FromImage(new Bitmap(1, 1));
			var font = new Font(settings.Font.FontFamily, 10);
			const int offset = 10;
			return wordInfos
				.Select(word =>
				{
					var size = g.MeasureString(word.Word, font).ToSize();
					return new TagCloudItem(settings.Color, word,
						font, new Rectangle(0, 0, size.Width + offset, size.Height + offset));
				})
				.ToList();
		}
	}
}