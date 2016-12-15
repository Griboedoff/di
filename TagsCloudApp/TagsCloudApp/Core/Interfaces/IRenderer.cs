using System.Drawing;

namespace TagsCloudApp.Core.Interfaces
{
	public interface IRenderer
	{
		Image RenderImage(TagCloud cloud);
		void SaveImageTo(string path, Image image);
	}
}