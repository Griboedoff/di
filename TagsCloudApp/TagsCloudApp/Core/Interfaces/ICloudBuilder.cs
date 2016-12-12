using System.Collections.Generic;

namespace TagsCloudApp.Core.Interfaces
{
	public interface ICloudBuilder
	{
		TagCloud BuildCloud(List<TagCloudItem> cloudItems);
	}
}