﻿//
// Bindings for SKCanvas
//
// Author:
//   Miguel de Icaza
//
// Copyright 2016 Xamarin Inc
//
using System;

namespace SkiaSharp
{
	// No dispose, the Canvas is only valid while the Surface is valid.
	public class SKCanvas : SKObject
	{
		[Preserve]
		internal SKCanvas (IntPtr handle, bool owns)
			: base (handle, owns)
		{
		}

		public SKCanvas (SKBitmap bitmap)
			: this (IntPtr.Zero, true)
		{
			if (bitmap == null)
				throw new ArgumentNullException (nameof (bitmap));
			Handle = SkiaApi.sk_canvas_new_from_bitmap (bitmap.Handle);
		}

		public int Save ()
		{
			if (Handle == IntPtr.Zero)
				throw new ObjectDisposedException ("SKCanvas");
			return SkiaApi.sk_canvas_save (Handle);
		}

		public int SaveLayer (SKRect limit, SKPaint paint)
		{
			return SkiaApi.sk_canvas_save_layer (Handle, ref limit, paint == null ? IntPtr.Zero : paint.Handle);
		}

		public int SaveLayer (SKPaint paint)
		{
			return SkiaApi.sk_canvas_save_layer (Handle, IntPtr.Zero, paint == null ? IntPtr.Zero : paint.Handle);
		}

		public void DrawColor (SKColor color, SKXferMode mode = SKXferMode.Src)
		{
			SkiaApi.sk_canvas_draw_color (Handle, color, mode);
		}

		public void DrawLine (float x0, float y0, float x1, float y1, SKPaint paint)
		{
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));
			SkiaApi.sk_canvas_draw_line (Handle, x0, y0, x1, y1, paint.Handle);
		}

		public void Clear ()
		{
			DrawColor (SKColors.Empty, SKXferMode.Src);
		}

		public void Clear (SKColor color)
		{
			DrawColor (color, SKXferMode.Src);
		}

		public void Restore ()
		{
			SkiaApi.sk_canvas_restore (Handle);
		}

		public void RestoreToCount (int count)
		{
			SkiaApi.sk_canvas_restore_to_count (Handle, count);
		}

		public void Translate (float dx, float dy)
		{
			SkiaApi.sk_canvas_translate (Handle, dx, dy);
		}

		public void Translate (SKPoint point)
		{
			SkiaApi.sk_canvas_translate (Handle, point.X, point.Y);
		}

		public void Scale (float sx, float sy)
		{
			SkiaApi.sk_canvas_scale (Handle, sx, sy);
		}

		public void Scale (SKPoint size)
		{
			SkiaApi.sk_canvas_scale (Handle, size.X, size.Y);
		}

		public void Scale (float sx, float sy, float px, float py)
		{
			Translate (px, py);
			Scale (sx, sy);
			Translate (-px, -py);
		}

		public void RotateDegrees (float degrees)
		{
			SkiaApi.sk_canvas_rotate_degrees (Handle, degrees);
		}

		public void RotateRadians (float radians)
		{
			SkiaApi.sk_canvas_rotate_radians (Handle, radians);
		}

		public void RotateDegrees (float degrees, float px, float py)
		{
			Translate (px, py);
			RotateDegrees (degrees);
			Translate (-px, -py);
		}

		public void RotateRadians(float radians, float px, float py)
		{
			Translate (px, py);
			RotateRadians (radians);
			Translate (-px, -py);
		}

		public void Skew (float sx, float sy)
		{
			SkiaApi.sk_canvas_skew (Handle, sx, sy);
		}

		public void Skew (SKPoint skew)
		{
			SkiaApi.sk_canvas_skew (Handle, skew.X, skew.Y);
		}

		public void Concat (ref SKMatrix m)
		{
			SkiaApi.sk_canvas_concat (Handle, ref m);
		}

		public void ClipRect (SKRect rect, SKRegionOperation operation = SKRegionOperation.Intersect, bool antialias = false)
		{
			SkiaApi.sk_canvas_clip_rect_with_operation (Handle, ref rect, operation, antialias);
		}

		public void ClipPath (SKPath path, SKRegionOperation operation = SKRegionOperation.Intersect, bool antialias = false)
		{
			if (path == null)
				throw new ArgumentNullException (nameof (path));
			
			SkiaApi.sk_canvas_clip_path_with_operation (Handle, path.Handle, operation, antialias);
		}

		public bool GetClipBounds (ref SKRect bounds)
		{
			return SkiaApi.sk_canvas_get_clip_bounds(Handle, ref bounds);
		}

		public bool GetClipDeviceBounds (ref SKRectI bounds)
		{
			return SkiaApi.sk_canvas_get_clip_device_bounds(Handle, ref bounds);
		}

		public void DrawPaint (SKPaint paint)
		{
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));
			SkiaApi.sk_canvas_draw_paint (Handle, paint.Handle);
		}

		public void DrawRect (SKRect rect, SKPaint paint)
		{
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));
			SkiaApi.sk_canvas_draw_rect (Handle, ref rect, paint.Handle);
		}

		public void DrawRoundRect (SKRect rect, float rx, float ry, SKPaint paint)
		{
				if (paint == null)
						throw new ArgumentNullException (nameof (paint));
				SkiaApi.sk_canvas_draw_round_rect (Handle, ref rect, rx, ry, paint.Handle);
		}

		public void DrawOval (SKRect rect, SKPaint paint)
		{
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));
			SkiaApi.sk_canvas_draw_oval (Handle, ref rect, paint.Handle);
		}

		public void DrawCircle (float cx, float cy, float radius, SKPaint paint)
		{
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));
			SkiaApi.sk_canvas_draw_circle (Handle, cx, cy, radius, paint.Handle);
		}
		
		public void DrawPath (SKPath path, SKPaint paint)
		{
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));
			if (path == null)
				throw new ArgumentNullException (nameof (path));
			SkiaApi.sk_canvas_draw_path (Handle, path.Handle, paint.Handle);
		}

		public void DrawPoints (SKPointMode mode, SKPoint [] points, SKPaint paint)
		{
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));
			if (points == null)
				throw new ArgumentNullException (nameof (points));
			SkiaApi.sk_canvas_draw_points (Handle, mode, (IntPtr)points.Length, points, paint.Handle);
		}

		public void DrawPoint (float x, float y, SKPaint paint)
		{
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));
			SkiaApi.sk_canvas_draw_point (Handle, x, y, paint.Handle);
		}

		public void DrawPoint (float x, float y, SKColor color)
		{
			SkiaApi.sk_canvas_draw_point_color (Handle, x, y, color);
		}
		
		public void DrawImage (SKImage image, float x, float y, SKPaint paint = null)
		{
			if (image == null)
				throw new ArgumentNullException (nameof (image));
			SkiaApi.sk_canvas_draw_image (Handle, image.Handle, x, y, paint == null ? IntPtr.Zero : paint.Handle);
		}

		public void DrawImage (SKImage image, SKRect dest, SKPaint paint = null)
		{
			if (image == null)
				throw new ArgumentNullException (nameof (image));
			SkiaApi.sk_canvas_draw_image_rect (Handle, image.Handle, IntPtr.Zero, ref dest, paint == null ? IntPtr.Zero : paint.Handle);
		}

		public void DrawImage (SKImage image, SKRect source, SKRect dest, SKPaint paint = null)
		{
			if (image == null)
				throw new ArgumentNullException (nameof (image));
			SkiaApi.sk_canvas_draw_image_rect (Handle, image.Handle, ref source, ref dest, paint == null ? IntPtr.Zero : paint.Handle);
		}

		public void DrawPicture (SKPicture picture, ref SKMatrix matrix, SKPaint paint = null)
		{
			if (picture == null)
				throw new ArgumentNullException ("picture");
			SkiaApi.sk_canvas_draw_picture (Handle, picture.Handle, ref matrix, paint == null ? IntPtr.Zero : paint.Handle);
		}

		public void DrawPicture (SKPicture picture, SKPaint paint = null)
		{
			if (picture == null)
				throw new ArgumentNullException ("picture");
			SkiaApi.sk_canvas_draw_picture (Handle, picture.Handle, IntPtr.Zero, paint == null ? IntPtr.Zero : paint.Handle);
		}

		public void DrawBitmap (SKBitmap bitmap, float x, float y, SKPaint paint = null)
		{
			if (bitmap == null)
				throw new ArgumentNullException ("bitmap");
			SkiaApi.sk_canvas_draw_bitmap (Handle, bitmap.Handle, x, y, paint == null ? IntPtr.Zero : paint.Handle);
		}

		public void DrawBitmap (SKBitmap bitmap, SKRect dest, SKPaint paint = null)
		{
			if (bitmap == null)
				throw new ArgumentNullException ("bitmap");
			SkiaApi.sk_canvas_draw_bitmap_rect (Handle, bitmap.Handle, IntPtr.Zero, ref dest, paint == null ? IntPtr.Zero : paint.Handle);
		}

		public void DrawBitmap (SKBitmap bitmap, SKRect source, SKRect dest, SKPaint paint = null)
		{
			if (bitmap == null)
				throw new ArgumentNullException ("bitmap");
			SkiaApi.sk_canvas_draw_bitmap_rect (Handle, bitmap.Handle, ref source, ref dest, paint == null ? IntPtr.Zero : paint.Handle);
		}

		public void DrawText (string text, float x, float y, SKPaint paint)
		{
			if (text == null)
				throw new ArgumentNullException ("text");
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));

			var bytes = Util.GetEncodedText (text, paint.TextEncoding);
			SkiaApi.sk_canvas_draw_text (Handle, bytes, bytes.Length, x, y, paint.Handle);
		}

		public void DrawText (string text, SKPoint [] points, SKPaint paint)
		{
			if (text == null)
				throw new ArgumentNullException ("text");
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));
			if (points == null)
				throw new ArgumentNullException ("points");

			var bytes = Util.GetEncodedText (text, paint.TextEncoding);
			SkiaApi.sk_canvas_draw_pos_text (Handle, bytes, bytes.Length, points, paint.Handle);
		}

		public void DrawText (IntPtr buffer, int length, SKPath path, float hOffset, float vOffset, SKPaint paint)
		{
			if (buffer == IntPtr.Zero)
				throw new ArgumentNullException ("buffer");
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));
			
			SkiaApi.sk_canvas_draw_text_on_path (Handle, buffer, length, path.Handle, hOffset, vOffset, paint.Handle);
		}

		public void DrawText (IntPtr buffer, int length, float x, float y, SKPaint paint)
		{
			if (buffer == IntPtr.Zero)
				throw new ArgumentNullException ("buffer");
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));
			
			SkiaApi.sk_canvas_draw_text (Handle, buffer, length, x, y, paint.Handle);
		}

		public void DrawText (IntPtr buffer, int length, SKPoint[] points, SKPaint paint)
		{
			if (buffer == IntPtr.Zero)
				throw new ArgumentNullException ("buffer");
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));
			if (points == null)
				throw new ArgumentNullException ("points");
			
			SkiaApi.sk_canvas_draw_pos_text (Handle, buffer, length, points, paint.Handle);
		}

		public void DrawText (string text, SKPath path, float hOffset, float vOffset, SKPaint paint)
		{
			if (text == null)
				throw new ArgumentNullException ("text");
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));
			if (paint == null)
				throw new ArgumentNullException (nameof (paint));

			var bytes = Util.GetEncodedText (text, paint.TextEncoding);
			SkiaApi.sk_canvas_draw_text_on_path (Handle, bytes, bytes.Length, path.Handle, hOffset, vOffset, paint.Handle);
		}

		public void DrawBitmapNinePatch (SKBitmap bitmap, SKRectI center, SKRect dst, SKPaint paint = null)
		{
			if (bitmap == null)
				throw new ArgumentNullException (nameof (bitmap));
			// the "center" rect must fit inside the bitmap "rect"
			if (!SKRect.Create (bitmap.Info.Size).Contains (center))
				throw new ArgumentOutOfRangeException (nameof (center));

			var xDivs = new [] { center.Left, center.Right };
			var yDivs = new [] { center.Top, center.Bottom };
			DrawBitmapLattice (bitmap, xDivs, yDivs, dst, paint);
		}

		public void DrawImageNinePatch (SKImage image, SKRectI center, SKRect dst, SKPaint paint = null)
		{
			if (image == null)
				throw new ArgumentNullException (nameof (image));
			// the "center" rect must fit inside the image "rect"
			if (!SKRect.Create (image.Width, image.Height).Contains (center))
				throw new ArgumentOutOfRangeException (nameof (center));

			var xDivs = new [] { center.Left, center.Right };
			var yDivs = new [] { center.Top, center.Bottom };
			DrawImageLattice (image, xDivs, yDivs, dst, paint);
		}

		public void DrawBitmapLattice (SKBitmap bitmap, int[] xDivs, int[] yDivs, SKRect dst, SKPaint paint = null)
		{
			if (bitmap == null)
				throw new ArgumentNullException (nameof (bitmap));
			if (xDivs == null)
				throw new ArgumentNullException (nameof (xDivs));
			if (yDivs == null)
				throw new ArgumentNullException (nameof (yDivs));

			SkiaApi.sk_canvas_draw_bitmap_lattice (Handle, bitmap.Handle, xDivs, xDivs.Length, yDivs, yDivs.Length, ref dst, paint == null ? IntPtr.Zero : paint.Handle);
		}

		public void DrawImageLattice (SKImage image, int[] xDivs, int[] yDivs, SKRect dst, SKPaint paint = null)
		{
			if (image == null)
				throw new ArgumentNullException (nameof (image));
			if (xDivs == null)
				throw new ArgumentNullException (nameof (xDivs));
			if (yDivs == null)
				throw new ArgumentNullException (nameof (yDivs));

			SkiaApi.sk_canvas_draw_image_lattice (Handle, image.Handle, xDivs, xDivs.Length, yDivs, yDivs.Length, ref dst, paint == null ? IntPtr.Zero : paint.Handle);
		}

		public void ResetMatrix ()
		{
			SkiaApi.sk_canvas_reset_matrix (Handle);
		}

		public void SetMatrix (SKMatrix matrix)
		{
			SkiaApi.sk_canvas_set_matrix (Handle, ref matrix);
		}

		public SKMatrix TotalMatrix {
			get {
				SKMatrix matrix = new SKMatrix();
				SkiaApi.sk_canvas_get_total_matrix (Handle, ref matrix);
				return matrix;
			}
		}

		public int SaveCount => SkiaApi.sk_canvas_get_save_count (Handle);
	}

	public class SKAutoCanvasRestore : IDisposable
	{
		private SKCanvas canvas;
		private readonly int saveCount;

		public SKAutoCanvasRestore (SKCanvas canvas, bool doSave)
		{
			this.canvas = canvas;
			this.saveCount = 0;

			if (canvas != null) {
				saveCount = canvas.SaveCount;
				if (doSave) {
					canvas.Save ();
				}
			}
		}

		public void Dispose ()
		{
			if (canvas != null) {
				canvas.RestoreToCount (saveCount);
			}
		}

		/// <summary>
		/// Perform the restore now, instead of waiting for the Dispose.
		/// Will only do this once.
		/// </summary>
		public void Restore ()
		{
			if (canvas != null) {
				canvas.RestoreToCount (saveCount);
				canvas = null;
			}
		}
	}
}

