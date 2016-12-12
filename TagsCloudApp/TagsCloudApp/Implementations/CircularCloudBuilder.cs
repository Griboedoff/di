using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Implementations
{
	public static class RectangleExtension
	{
		public static Point GetCenter(this Rectangle rect) => rect.Location + new Size(rect.Width / 2, rect.Height / 2);
	}

	public static class PointExtensions
	{
		public static Point SnapByX(this Point p)
		{
			return new Point(p.X / (p.X != 0 ? Math.Abs(p.X) : 1), 0);
		}

		public static Point SnapByY(this Point p)
		{
			return new Point(0, p.Y / (p.Y != 0 ? Math.Abs(p.Y) : 1));
		}
	}

	internal class CircularCloudBuilder : ICloudBuilder
	{
		private Point center;
		private readonly Spiral spiral;
		private readonly Rectangle cloudBorders;

		private Point Center
		{
			set
			{
				if (value.X < 0 || value.Y < 0)
					throw new ArgumentException("Center point should be non-negative");
				center = value;
			}
		}

		private List<Rectangle> PlacedRectangles { get; }

		private bool IsInValidPosition(Rectangle checkingRectangle)
		{
			return !PlacedRectangles.Any(rect => rect.IntersectsWith(checkingRectangle)) &&
			       cloudBorders.Contains(checkingRectangle);
		}

		private static Point GetRectangleCenterLocation(Size rectangleSize, Point nextSpiralPoint)
		{
			return new Point(nextSpiralPoint.X - rectangleSize.Width / 2, nextSpiralPoint.Y - rectangleSize.Height / 2);
		}

		public CircularCloudBuilder(Point center)
		{
			spiral = new Spiral(center);
			Center = center;
			cloudBorders = new Rectangle(0, 0, center.X * 2, center.Y * 2);
			PlacedRectangles = new List<Rectangle>();
		}

		private Rectangle PutNextRectangle(Size rectangleSize)
		{
			if (rectangleSize.Height <= 0 || rectangleSize.Width <= 0)
				throw new ArgumentException($"Size must be positive {rectangleSize}");

			var nextRectangle = FindNextRectanglePosition(rectangleSize);

			if (nextRectangle.IsEmpty) return nextRectangle;

			nextRectangle = MoveToCenter(nextRectangle);
			PlacedRectangles.Add(nextRectangle);
			return nextRectangle;
		}

		private Rectangle FindNextRectanglePosition(Size rectangleSize)
		{
			var nextSpiralPoint = spiral.GetNextSpiralPoint();
			var nextRectangle = new Rectangle(GetRectangleCenterLocation(rectangleSize, nextSpiralPoint), rectangleSize);

			while (!IsInValidPosition(nextRectangle))
			{
				nextSpiralPoint = spiral.GetNextSpiralPoint();
				nextRectangle = new Rectangle(GetRectangleCenterLocation(rectangleSize, nextSpiralPoint), rectangleSize);
				if (!cloudBorders.Contains(nextSpiralPoint))
					throw new ArgumentException("Can't place rectangle because cloud is too small");
			}

			return nextRectangle;
		}

		private Rectangle MoveToCenter(Rectangle rectangle)
		{
			var newRectangle = Rectangle.Empty;
			while (rectangle != newRectangle)
			{
				if (!newRectangle.IsEmpty)
					rectangle = newRectangle;
				var vectorToCenter = center - new Size(rectangle.GetCenter());
				newRectangle = TryMove(rectangle, vectorToCenter.SnapByX());
				newRectangle = TryMove(newRectangle, vectorToCenter.SnapByY());
			}
			return rectangle;
		}

		private Rectangle TryMove(Rectangle rectangle, Point shift)
		{
			var newRect = new Rectangle(rectangle.Location + new Size(shift), rectangle.Size);
			var isInValidPosition = IsInValidPosition(newRect);
			if (isInValidPosition)
				rectangle = newRect;
			return rectangle;
		}

		public TagCloud BuildCloud(List<TagCloudItem> cloudItems)
		{
			Console.WriteLine("end build");
			foreach (var cloudItem in cloudItems)
				cloudItem.Rectangle =
					PutNextRectangle(new Size(cloudItem.FontSize * cloudItem.WordInfo.Word.Length, cloudItem.FontSize * 3));

			return new TagCloud(cloudItems, new Size(1000, 1000));
		}
	}
}