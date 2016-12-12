using System.Collections.Generic;

namespace TagsCloudApp.Core.Interfaces
{
	public interface IFileReader
	{
		IEnumerable<string> GetFileContetByWords(string path);
	}
}