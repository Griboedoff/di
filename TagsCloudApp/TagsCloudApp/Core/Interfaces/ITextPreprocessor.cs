using System.Collections.Generic;

namespace TagsCloudApp.Core.Interfaces
{
	public interface ITextPreprocessor
	{
		List<WordInfo> ProcessWords(IEnumerable<string> words);
	}
}