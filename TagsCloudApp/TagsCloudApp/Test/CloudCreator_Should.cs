using System;
using System.Collections.Generic;
using System.Drawing;
using FakeItEasy;
using NUnit.Framework;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Test
{
	[TestFixture]
	public class CloudCreator_Should
	{
		[Test]
		public void DoSomething_WhenSomething()
		{
			var builder = A.Fake<ICloudBuilder>();
			var reader = A.Fake<IFileReader>();
			var prioritySetter = A.Fake<IPrioritySetter>();
			var textPreprocessor = A.Fake<ITextPreprocessor>();
			var creator = new CloudCreator(builder, reader, prioritySetter, textPreprocessor);
			var random = new Random(1);

			A.CallTo(() => reader.GetFileContetByWords(null))
				.WithAnyArguments()
				.Returns(new List<string> {"one", "two", "three"});
			A.CallTo(() => textPreprocessor.ProcessWords(null))
				.WithAnyArguments()
				.Returns(new List<WordInfo> {new WordInfo("one", 1), new WordInfo("two", 1)});
			A.CallTo(() => prioritySetter.SetPriorities(null, null))
				.WithAnyArguments()
				.Returns(new List<TagCloudItem> {TagCloudItem.GetRandomFontSize(random)});
			A.CallTo(() => builder.BuildCloud(null, default(Point)))
				.WithAnyArguments()
				.Returns(new List<TagCloudItem> {TagCloudItem.GetRandomFontSize(random)});

			creator.Create(TagCloudSettings.DefaultSettings);

			A.CallTo(() => reader.GetFileContetByWords(null))
				.WithAnyArguments()
				.MustHaveHappened(Repeated.Exactly.Once);
			A.CallTo(() => textPreprocessor.ProcessWords(null))
				.WithAnyArguments()
				.MustHaveHappened(Repeated.Exactly.Once);
			A.CallTo(() => prioritySetter.SetPriorities(null, null))
				.WithAnyArguments()
				.MustHaveHappened(Repeated.Exactly.Once);
			A.CallTo(() => builder.BuildCloud(null, default(Point)))
				.WithAnyArguments()
				.MustHaveHappened(Repeated.Exactly.Once);
		}
	}
}