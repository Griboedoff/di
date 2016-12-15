using System.Collections.Generic;
using System.Drawing;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Core
{
	public class TagCloud
	{
		private readonly ICloudBuilder cloudBuilder;
		private readonly IFileReader reader;
		private readonly IPrioritySetter prioritySetter;
		private readonly IRenderer renderer;
		private readonly ITextPreprocessor textPreprocessor;
		private readonly IVizualizer vizualizer;
		private List<TagCloudItem> items;
		public Size Size { get; private set; }

		public IEnumerable<TagCloudItem> Items => items.AsReadOnly();

		public TagCloud(ICloudBuilder cloudBuilder, IFileReader reader, IPrioritySetter prioritySetter, IRenderer renderer,
			ITextPreprocessor textPreprocessor, IVizualizer vizualizer)
		{
			this.cloudBuilder = cloudBuilder;
			this.reader = reader;
			this.prioritySetter = prioritySetter;
			this.renderer = renderer;
			this.textPreprocessor = textPreprocessor;
			this.vizualizer = vizualizer;
		}

		public void Build(string pathToWords, Size size)
		{
			Size = size;
			var words = reader.GetFileContetByWords(pathToWords);
			var processedWords = textPreprocessor.ProcessWords(words);
			var priorities = prioritySetter.SetPriorities(processedWords);
			items = cloudBuilder.BuildCloud(priorities, new Point(size.Width / 2, size.Height / 2));
		}

		public void RenderCloud()
		{
			renderer.RenderImage(this);
		}

		public void Save(string path)
		{
			if (!renderer.HasRendered())
				renderer.RenderImage(this);
			renderer.SaveImageTo(path);
		}

		public void Vizualize()
		{

		}
	}
}