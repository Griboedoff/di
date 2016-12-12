using System.Drawing;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Implementations
{
	class PngRenderer : IRenderer
	{
		private Bitmap image;

		public void RenderImage(TagCloud cloud)
		{
			image = new Bitmap(cloud.Size.Width, cloud.Size.Height);
			var g = Graphics.FromImage(image);
			g.FillRectangle(Brushes.Black, new Rectangle(new Point(0, 0), cloud.Size));

			foreach (var cloudItem in cloud.Items)
			{
				g.DrawString(cloudItem);
			}
		}

		public void SaveImageTo(string path)
		{
			image.Save(path);
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