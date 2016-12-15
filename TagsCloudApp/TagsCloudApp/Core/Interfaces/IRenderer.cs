namespace TagsCloudApp.Core.Interfaces
{
	public interface IRenderer
	{
		bool HasRendered();
		void RenderImage(TagCloud cloud);
		void SaveImageTo(string path);
	}
}