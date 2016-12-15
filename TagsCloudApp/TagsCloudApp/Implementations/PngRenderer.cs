using System.Drawing;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Implementations
{
	class PngRenderer : IRenderer
	{
		public Image RenderImage(TagCloud cloud)
		{
			var image = new Bitmap(cloud.Size.Width, cloud.Size.Height);
			var g = Graphics.FromImage(image);
			g.FillRectangle(Brushes.Black, new Rectangle(new Point(0, 0), cloud.Size));

			foreach (var cloudItem in cloud.Items)
				g.DrawString(cloudItem);
			return image;
		}

		public void SaveImageTo(string path, Image image)
		{
			image.Save(path + ".png");
		}
	}

	internal static class GraphicsExtension
	{
		public static void DrawString(this Graphics g, TagCloudItem item)
		{
			g.DrawString(item.WordInfo.Word, item.Font, new SolidBrush(item.Color), item.Rectangle);
		}
	}
}