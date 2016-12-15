using System.Collections.Generic;

namespace TagsCloudApp.Core.Interfaces
{
	public interface IPrioritySetter
	{
		List<TagCloudItem> SetPriorities(IEnumerable<WordInfo> words);
	}
}