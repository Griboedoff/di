using System;
using System.Drawing;

namespace TagsCloudApp.Core
{
	public class TagCloudItem
	{
		public readonly WordInfo WordInfo;
		public readonly Color Color;
		public readonly Font Font;
		public readonly Rectangle Rectangle;

		public TagCloudItem(Color color, WordInfo wordInfo, Font font, Rectangle rectangle)
		{
			Color = color;
			WordInfo = wordInfo;
			Font = font;
			Rectangle = rectangle;
		}

		public TagCloudItem SetRectangle(Rectangle newRectangle) => new TagCloudItem(Color, WordInfo, Font, newRectangle);

		public static TagCloudItem GetRandomFontSize(Random rnd)
		{
			return new TagCloudItem(Color.AliceBlue, new WordInfo("", 100), new Font("Menlo", rnd.Next(int.MaxValue)),
				default(Rectangle));
		}
	}
}