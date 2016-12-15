using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudApp.Core;
using TagsCloudApp.Core.Extensions;
using TagsCloudApp.Core.Interfaces;

namespace TagsCloudApp.Implementations
{
	internal class CircularCloudBuilder : ICloudBuilder
	{
		private Point center;
		private Spiral spiral;
		private Rectangle cloudBorders;

		private List<Rectangle> PlacedRectangles { get; set; }

		private Point Center
		{
			set
			{
				if (value.X < 0 || value.Y < 0)
					throw new ArgumentException("Center point should be non-negative");
				center = value;
			}
		}

		public CircularCloudBuilder()
		{
			PlacedRectangles = new List<Rectangle>();
		}

		public List<TagCloudItem> BuildCloud(List<TagCloudItem> cloudItems, Point newCenter)
		{
			InitCloud(newCenter);

			var placedItems = new List<TagCloudItem>();
			foreach (var cloudItem in cloudItems)
				try
				{
					placedItems.Add(cloudItem.SetRectangle(PutNextRectangle(cloudItem.Rectangle.Size)));
				}
				catch (ArgumentException ex)
				{
					break;
				}
			return placedItems;
		}

		private void InitCloud(Point newCenter)
		{
			Center = newCenter;
			spiral = new Spiral(newCenter);
			cloudBorders = new Rectangle(0, 0, newCenter.X * 2, newCenter.Y * 2);
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
			var nextRectangle = new Rectangle(GetRectangleCenterLocation(rectangleSize, spiral.GetNextSpiralPoint()),
				rectangleSize);

			while (!IsInValidPosition(nextRectangle))
			{
				var nextSpiralPoint = spiral.GetNextSpiralPoint();
				nextRectangle = new Rectangle(GetRectangleCenterLocation(rectangleSize, nextSpiralPoint), rectangleSize);
				if (!cloudBorders.Contains(nextSpiralPoint))
					throw new ArgumentException("Can't place rectangle because cloud is too small");
			}

			return nextRectangle;
		}

		private static Point GetRectangleCenterLocation(Size rectangleSize, Point nextSpiralPoint)
		{
			return new Point(nextSpiralPoint.X - rectangleSize.Width / 2, nextSpiralPoint.Y - rectangleSize.Height / 2);
		}

		private bool IsInValidPosition(Rectangle checkingRectangle)
		{
			return !PlacedRectangles.Any(rect => rect.IntersectsWith(checkingRectangle)) &&
			       cloudBorders.Contains(checkingRectangle);
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
			if (IsInValidPosition(newRect))
				rectangle = newRect;
			return rectangle;
		}
	}
}