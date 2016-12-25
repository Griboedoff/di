using System.Collections.Generic;

namespace TagsCloudApp.Core.Interfaces
{
	public interface IFileReader
	{
		Result<IEnumerable<string>> GetFileContetByWords(string path);
	}
}