using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagsCloudApp.Core
{
	public class TagCloud
	{
		public readonly List<TagCloudItem> Items;
		public Size Size;

		public TagCloud(IEnumerable<TagCloudItem> items, Size size)
		{
			Items = items.ToList();
			Size = size;
		}
	}
}