using System.Collections.Generic;
using System.IO;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Implementations
{
	public class TxtReader : IFileReader
	{
		public Result<IEnumerable<string>> GetFileContetByWords(string path)
		{
			return File.ReadAllLines(path);
		}
	}
}