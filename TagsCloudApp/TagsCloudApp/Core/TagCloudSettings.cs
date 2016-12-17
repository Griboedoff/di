using System.Drawing;

namespace TagsCloudApp.Core
{
	public class TagCloudSettings
	{
		public static readonly TagCloudSettings DefaultSettings =
			new TagCloudSettings(new Font("Meslo", 10), Color.GreenYellow, "test.txt", "test", new Size(500, 500));

		public Font Font { get; set; }
		public Color Color { get; set; }
		public string PathToWords { get; set; }
		public string PathToSave { get; set; }
		public Size Size { get; set; }

		public TagCloudSettings(Font font, Color color, string pathToWords, string pathToSave, Size size)
		{
			Font = font;
			Color = color;
			PathToWords = pathToWords;
			PathToSave = pathToSave;
			Size = size;
		}
	}
}