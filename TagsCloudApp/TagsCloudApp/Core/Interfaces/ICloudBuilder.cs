using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudApp.Core.Interfaces
{
	public interface ICloudBuilder
	{
		Result<List<TagCloudItem>> BuildCloud(List<TagCloudItem> cloudItems, Point newCenter);
	}
}