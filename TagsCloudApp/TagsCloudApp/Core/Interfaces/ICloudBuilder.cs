using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudApp.Core.Interfaces
{
	public interface ICloudBuilder
	{
		List<TagCloudItem> BuildCloud(List<TagCloudItem> cloudItems, Point newCenter);
	}
}