using System.Drawing;

namespace TagsCloudApp.Core
{
	public class TagCloudItem
	{
		public readonly WordInfo WordInfo;
		public int FontSize;
		public Color Color;
		public Font Font;
		public Rectangle Rectangle;

		public TagCloudItem(Color color, WordInfo wordInfo, int fontSize, Font font, Rectangle rectangle)
		{
			Color = color;
			WordInfo = wordInfo;
			FontSize = fontSize;
			Font = font;
			Rectangle = rectangle;
		}
	}
}