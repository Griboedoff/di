using System.Collections.Generic;

namespace TagsCloudApp.Core.Interfaces
{
	public interface IPriorityGiver
	{
		IEnumerable<TagCloudItem> SetPriorities(List<WordInfo> words);
	}
}