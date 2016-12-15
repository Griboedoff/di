using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudApp.Core
{
	public class TagCloud
	{
		private readonly List<TagCloudItem> items;
		public Size Size { get; }
		public IEnumerable<TagCloudItem> Items => items.AsReadOnly();

		public TagCloud(List<TagCloudItem> items, Size size)
		{
			this.items = items;
			Size = size;
		}
	}
}