using System.Drawing;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudApp.Implementations;

namespace TagsCloudApp.Test
{
	[TestFixture]
	public class Spiral_Should
	{
		[Test]
		public void IncrementAngleAndRadiusByDelta_OnNextStep()
		{
			const int deltaAngle = 1;
			const int deltaRadius = 2;
			var spiral = new Spiral(new Point(100, 100), deltaAngle, deltaRadius);
			var previousAngle = spiral.CurrentAngle;
			var previousRadius = spiral.CurrentRadius;
			spiral.GetNextSpiralPoint();
			(spiral.CurrentAngle - previousAngle).Should().Be(deltaAngle);
			(spiral.CurrentRadius - previousRadius).Should().Be(deltaRadius);
		}
	}
}