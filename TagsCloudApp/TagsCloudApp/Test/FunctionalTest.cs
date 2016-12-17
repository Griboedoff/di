using System.Drawing;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudApp.Core;
using TagsCloudApp.Implementations;

namespace TagsCloudApp.Test
{
	[TestFixture]
	public class FunctionalTest
	{
		[Test]
		public void TestCloudCreation()
		{
			var creator = new CloudCreator(new CircularCloudBuilder(), new TxtReader(), new SamePrioritySetter(),
				new SimpleTextPreprocessor());
			var tagCloudSettings = new TagCloudSettings(new Font("Arial", 5), Color.Beige,
				Path.Combine(TestContext.CurrentContext.TestDirectory, "Test", "test.txt"),
				"for_test", new Size(1000, 1000));

			var cloud = creator.Create(tagCloudSettings);

			cloud.Items.Any().Should().BeTrue();
			cloud.Size.Should().Be(tagCloudSettings.Size);
		}
	}
}