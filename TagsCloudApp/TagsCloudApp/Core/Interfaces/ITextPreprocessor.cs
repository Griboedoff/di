using System.Collections.Generic;

namespace TagsCloudApp.Core.Interfaces
{
	public interface ITextPreprocessor
	{
		IEnumerable<WordInfo> ProcessWords(IEnumerable<string> words);
	}
}