using System.Collections.Generic;
using System.IO;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Implementations
{
	public class TxtReader : IFileReader
	{
		public IEnumerable<string> GetFileContetByWords(string path)
		{
			return File.ReadAllLines(path);
		}
	}
}