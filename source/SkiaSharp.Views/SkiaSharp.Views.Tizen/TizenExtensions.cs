﻿using ElmSharp;

namespace SkiaSharp.Views.Tizen
{
	public static class TizenExtensions
	{
		// Point

		public static SKPoint ToSKPoint(this Point point)
		{
			return new SKPoint(point.X, point.Y);
		}

		public static SKPointI ToSKPointI(this Point point)
		{
			return new SKPointI(point.X, point.Y);
		}

		public static Point ToPoint(this SKPoint point)
		{
			return new Point { X = (int)point.X, Y = (int)point.Y };
		}

		public static Point ToPoint(this SKPointI point)
		{
			return new Point { X = point.X, Y = point.Y };
		}

		// Rectangle

		public static SKRect ToSKRect(this Rect rect)
		{
			return new SKRect(rect.Left, rect.Top, rect.Right, rect.Bottom);
		}

		public static SKRectI ToSKRectI(this Rect rect)
		{
			return new SKRectI(rect.Left, rect.Top, rect.Right, rect.Bottom);
		}

		public static Rect ToRect(this SKRect rect)
		{
			return new Rect((int)rect.Left, (int)rect.Top, (int)rect.Right, (int)rect.Bottom);
		}

		public static Rect ToRect(this SKRectI rect)
		{
			return new Rect(rect.Left, rect.Top, rect.Right, rect.Bottom);
		}

		// Color

		public static SKColor ToSKColor(this Color color)
		{
			return new SKColor((byte)color.R, (byte)color.G, (byte)color.B, (byte)color.A);
		}

		public static Color ToColor(this SKColor color)
		{
			return Color.FromRgba(color.Red, color.Green, color.Blue, color.Alpha);
		}
	}
}
