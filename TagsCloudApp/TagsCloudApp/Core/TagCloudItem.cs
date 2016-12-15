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

		public TagCloudItem SetColor(Color newColor) => new TagCloudItem(newColor, WordInfo, Font, Rectangle);

		public TagCloudItem SetFont(Font newFont) => new TagCloudItem(Color, WordInfo, newFont, Rectangle);

		public TagCloudItem SetRectangle(Rectangle newRectangle) => new TagCloudItem(Color, WordInfo, Font, newRectangle);
	}
}