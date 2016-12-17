using System;
using System.Drawing;

namespace TagsCloudApp.Implementations
{
	public class Spiral
	{
		private readonly Point center;
		private readonly double deltaAngle;
		private readonly double deltaRadius;
		private Point currentPoint;

		public double CurrentAngle { get; set; }

		public double CurrentRadius { get; set; }

		public Spiral(Point center, double deltaAngle = Math.PI / 180, double deltaRadius = 0.001)
		{
			this.center = center;
			this.deltaAngle = deltaAngle;
			this.deltaRadius = deltaRadius;
			currentPoint = this.center;
			CurrentAngle = 0;
			CurrentRadius = 0;
		}

		public Point GetNextSpiralPoint()
		{
			var prevPoint = currentPoint;
			CurrentAngle += deltaAngle;
			CurrentRadius += deltaRadius;

			var newX = (int) (CurrentRadius * Math.Cos(CurrentAngle) + center.X);
			var newY = (int) (CurrentRadius * Math.Sin(CurrentAngle) + center.Y);
			currentPoint = new Point(newX, newY);
			return prevPoint;
		}
	}
}