using System.Drawing;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Core
{
	public class CloudCreator
	{
		private readonly ICloudBuilder cloudBuilder;
		private readonly IFileReader reader;
		private readonly IPrioritySetter prioritySetter;
		private readonly ITextPreprocessor textPreprocessor;

		public CloudCreator(ICloudBuilder cloudBuilder, IFileReader reader, IPrioritySetter prioritySetter,
			ITextPreprocessor textPreprocessor)
		{
			this.cloudBuilder = cloudBuilder;
			this.reader = reader;
			this.prioritySetter = prioritySetter;
			this.textPreprocessor = textPreprocessor;
		}

		public Result<TagCloud> Create(TagCloudSettings settings)
		{
			var size = settings.Size;
			return reader.GetFileContetByWords(settings.PathToWords)
				.Then(words => textPreprocessor.ProcessWords(words))
				.Then(processedWords => prioritySetter.SetPriorities(processedWords, settings))
				.Then(priorities => cloudBuilder.BuildCloud(priorities, new Point(size.Width / 2, size.Height / 2)))
				.Then(items => new TagCloud(items, size));
//				.OnFail()
		}
	}
}