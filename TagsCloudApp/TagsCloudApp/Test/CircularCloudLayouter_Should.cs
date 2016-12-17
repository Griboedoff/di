using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudApp.Core;
using TagsCloudApp.Implementations;

namespace TagsCloudApp.Test
{
	[TestFixture]
	internal class CircularCloudLayouter_Should
	{
		[Test]
		public void PlaceRectWOIntersection_WhenBuildCloudCalls()
		{
			var cloud = new CircularCloudBuilder();

			var placed = cloud.BuildCloud(GenerateRectangleSizes(10, 1).ToList(), new Point(1000, 1000));

			placed
				.SelectMany(r1 => placed,
					(r2, r1) => r1.Rectangle.IntersectsWith(r2.Rectangle))
				.Any(r => r)
				.Should().BeFalse();
		}


		private static IEnumerable<TagCloudItem> GenerateRectangleSizes(int numberOfRectangles, int seed)
		{
			var rand = new Random(seed);
			return Enumerable.Range(0, numberOfRectangles)
				.Select(i => TagCloudItem.GetRandomFontSize(rand));
		}
	}
}