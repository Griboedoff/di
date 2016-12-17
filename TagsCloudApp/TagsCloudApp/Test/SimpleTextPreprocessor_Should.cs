using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudApp.Implementations;

namespace TagsCloudApp.Test
{
	[TestFixture]
	public class SimpleTextPreprocessor_Should
	{
		private SimpleTextPreprocessor proc;

		[SetUp]
		public void SetUp()
		{
			proc = new SimpleTextPreprocessor();
		}

		[Test]
		public void RemoveStopWords()
		{
			var words = new List<string> {"He", "was", "shocked", "off"};

			var processed = proc.ProcessWords(words);

			processed.Select(w => w.Word).Should().NotContain("He");
		}

		[Test]
		public void CalculateWordCount()
		{
			var words = new List<string> {"He", "was", "He", "was", "He", "He", "He"};

			var processed = proc.ProcessWords(words);

			Console.WriteLine(1);
			processed.First(w => w.Word == "was").Frequency.Should().Be(2);
		}

	}
}