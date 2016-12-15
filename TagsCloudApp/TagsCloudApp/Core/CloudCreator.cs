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

		public TagCloud Create(TagCloudSettings settings)
		{
			var words = reader.GetFileContetByWords(settings.PathToWords);
			var processedWords = textPreprocessor.ProcessWords(words);
			var priorities = prioritySetter.SetPriorities(processedWords, settings);
			var size = settings.Size;
			return new TagCloud(cloudBuilder.BuildCloud(priorities, new Point(size.Width / 2, size.Height / 2)), size);
		}
	}
}