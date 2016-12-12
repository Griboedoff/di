namespace TagsCloudApp.Core.Interfaces
{
	public interface IRenderer
	{
		void RenderImage(TagCloud cloud);
		void SaveImageTo(string path);
	}
}