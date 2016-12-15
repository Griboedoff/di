using System.Drawing;

namespace TagsCloudApp.Core.Extensions
{
	public static class RectangleExtension
	{
		public static Point GetCenter(this Rectangle rect) => rect.Location + new Size(rect.Width / 2, rect.Height / 2);
	}
}