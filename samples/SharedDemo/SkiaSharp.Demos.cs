﻿using System;
using SkiaSharp;
using System.Linq;
using System.IO;
using System.Reflection;

namespace SkiaSharp
{
	public class Demos
	{
		#pragma warning disable 414
		static readonly SKColor XamLtBlue = new SKColor (0x34, 0x98, 0xdb);
		static readonly SKColor XamGreen = new SKColor (0x77, 0xd0, 0x65);
		static readonly SKColor XamDkBlue = new SKColor (0x2c, 0x3e, 0x50);
		static readonly SKColor XamPurple = new SKColor (0xb4, 0x55, 0xb6);
		#pragma warning restore 414

		public static void DrawXamagon (SKCanvas canvas, int width, int height)
		{
			// Width 41.6587026 => 144.34135
			// Height 56 => 147

			var paddingFactor = .6f;
			var imageLeft = 41.6587026f;
			var imageRight = 144.34135f;
			var imageTop = 56f;
			var imageBottom = 147f;

			var imageWidth = imageRight - imageLeft;

			var scale = (((float)height > width ? width : height) / imageWidth) * paddingFactor;

			var translateX =  (imageLeft + imageRight) / -2 + width/scale * 1/2;
			var translateY =  (imageBottom + imageTop) / -2 + height/scale * 1/2;

			canvas.Scale (scale, scale);
			canvas.Translate (translateX , translateY);


			using (var paint = new SKPaint ()) {
				paint.Color = SKColors.White;
				canvas.DrawPaint (paint);

				paint.StrokeCap = SKStrokeCap.Round;
				var t = paint.StrokeCap;


				using (var path = new SKPath ()) {
					path.MoveTo (71.4311121f, 56f);
					path.CubicTo (68.6763107f, 56.0058575f, 65.9796704f, 57.5737917f, 64.5928855f, 59.965729f);
					path.LineTo (43.0238921f, 97.5342563f);
					path.CubicTo (41.6587026f, 99.9325978f, 41.6587026f, 103.067402f, 43.0238921f, 105.465744f);
					path.LineTo (64.5928855f, 143.034271f);
					path.CubicTo (65.9798162f, 145.426228f, 68.6763107f, 146.994582f, 71.4311121f, 147f);
					path.LineTo (114.568946f, 147f);
					path.CubicTo (117.323748f, 146.994143f, 120.020241f, 145.426228f, 121.407172f, 143.034271f);
					path.LineTo (142.976161f, 105.465744f);
					path.CubicTo (144.34135f, 103.067402f, 144.341209f, 99.9325978f, 142.976161f, 97.5342563f);
					path.LineTo (121.407172f, 59.965729f);
					path.CubicTo (120.020241f, 57.5737917f, 117.323748f, 56.0054182f, 114.568946f, 56f);
					path.LineTo (71.4311121f, 56f);
					path.Close ();

					paint.Color = XamDkBlue;
					canvas.DrawPath (path, paint);

				}

				using (var path = new SKPath ()) {

					path.MoveTo (71.8225901f, 77.9780432f);
					path.CubicTo (71.8818491f, 77.9721857f, 71.9440029f, 77.9721857f, 72.0034464f, 77.9780432f);
					path.LineTo (79.444074f, 77.9780432f);
					path.CubicTo (79.773437f, 77.9848769f, 80.0929203f, 78.1757336f, 80.2573978f, 78.4623994f);
					path.LineTo (92.8795281f, 101.015639f);
					path.CubicTo (92.9430615f, 101.127146f, 92.9839987f, 101.251384f, 92.9995323f, 101.378901f);
					path.CubicTo (93.0150756f, 101.251354f, 93.055974f, 101.127107f, 93.1195365f, 101.015639f);
					path.LineTo (105.711456f, 78.4623994f);
					path.CubicTo (105.881153f, 78.167045f, 106.215602f, 77.975134f, 106.554853f, 77.9780432f);
					path.LineTo (113.995483f, 77.9780432f);
					path.CubicTo (114.654359f, 77.9839007f, 115.147775f, 78.8160066f, 114.839019f, 79.4008677f);
					path.LineTo (102.518299f, 101.500005f);
					path.LineTo (114.839019f, 123.568869f);
					path.CubicTo (115.176999f, 124.157088f, 114.671442f, 125.027775f, 113.995483f, 125.021957f);
					path.LineTo (106.554853f, 125.021957f);
					path.CubicTo (106.209673f, 125.019028f, 105.873247f, 124.81384f, 105.711456f, 124.507327f);
					path.LineTo (93.1195365f, 101.954088f);
					path.CubicTo (93.0560031f, 101.84258f, 93.0150659f, 101.718333f, 92.9995323f, 101.590825f);
					path.CubicTo (92.983989f, 101.718363f, 92.9430906f, 101.842629f, 92.8795281f, 101.954088f);
					path.LineTo (80.2573978f, 124.507327f);
					path.CubicTo (80.1004103f, 124.805171f, 79.7792269f, 125.008397f, 79.444074f, 125.021957f);
					path.LineTo (72.0034464f, 125.021957f);
					path.CubicTo (71.3274867f, 125.027814f, 70.8220664f, 124.157088f, 71.1600463f, 123.568869f);
					path.LineTo (83.4807624f, 101.500005f);
					path.LineTo (71.1600463f, 79.400867f);
					path.CubicTo (70.8647037f, 78.86725f, 71.2250368f, 78.0919422f, 71.8225901f, 77.9780432f);
					path.LineTo (71.8225901f, 77.9780432f);
					path.Close ();

					paint.Color = SKColors.White;
					canvas.DrawPath (path, paint);
				}
			}
		}

		// https://fiddle.skia.org/c/3523e95a9f8b96228b6b4bdd5409cb94
		public static void TextSample (SKCanvas canvas, int width, int height)
		{
			canvas.DrawColor (SKColors.White);

			using (var paint = new SKPaint ()) {
				paint.TextSize = 64.0f;
				paint.IsAntialias = true;
				paint.Color = new SKColor (0x42, 0x81, 0xA4);
				paint.IsStroke = false;

				canvas.DrawText ("Skia", width / 2f, 64.0f, paint);
			}

			using (var paint = new SKPaint ()) {
				paint.TextSize = 64.0f;
				paint.IsAntialias = true;
				paint.Color = new SKColor (0x9C, 0xAF, 0xB7);
				paint.IsStroke = true;
				paint.StrokeWidth = 3;
				paint.TextAlign = SKTextAlign.Center;

				canvas.DrawText ("Skia", width / 2f, 144.0f, paint);
			}

			using (var paint = new SKPaint ()) {
				paint.TextSize = 64.0f;
				paint.IsAntialias = true;
				paint.Color = new SKColor (0xE6, 0xB8, 0x9C);
				paint.TextScaleX = 1.5f;
				paint.TextAlign = SKTextAlign.Right;

				canvas.DrawText ("Skia", width / 2f, 224.0f, paint);
			}
		}

		public static void DrawGradient (SKCanvas canvas, int width, int height)
		{
			var ltColor = SKColors.White;
			var dkColor = SKColors.Black;

			using (var paint = new SKPaint ()) {
				using (var shader = SKShader.CreateLinearGradient (
					new SKPoint (0, 0),
					new SKPoint (0, height),
					new [] {ltColor, dkColor},
					null,
					SKShaderTileMode.Clamp)) {

					paint.Shader = shader;
					canvas.DrawPaint (paint);
				}
			}

			// Center and Scale the Surface
			var scale = (width < height ? width : height) / (240f);
			canvas.Translate (width/2f, height/2f);
			canvas.Scale (scale, scale);
			canvas.Translate (-128, -128);

			using (var paint = new SKPaint ()) {
				using (var shader = SKShader.CreateTwoPointConicalGradient (
					new SKPoint (115.2f, 102.4f), 
					25.6f,
					new SKPoint (102.4f, 102.4f),
					128.0f,
					new [] {ltColor, dkColor},
					null,
					SKShaderTileMode.Clamp
				)) {
					paint.Shader = shader;

					canvas.DrawOval (new SKRect (51.2f, 51.2f, 204.8f, 204.8f), paint);
				}
			}
		}

		public static void UnicodeText (SKCanvas canvas, int width, int height)
		{
			// stops at 0x530 on Android
			string text = "\u03A3 and \u0750";

			using (var paint = new SKPaint ())
			using (var tf = SKTypeface.FromFamilyName ("Tahoma")) {
				canvas.DrawColor (SKColors.White);

				paint.TextSize = 60;
				paint.Typeface = tf;
				canvas.DrawText (text, 50, 100, paint);
			}


			using (var paint = new SKPaint ())
			using (var tf = SKTypeface.FromFamilyName ("Times New Roman")) {
				paint.Color = XamDkBlue;

				paint.TextSize = 60;
				paint.Typeface = tf;
				canvas.DrawText (text, 50, 200, paint);
			}
		}

		public static void FilledHeptagram (SKCanvas canvas, int width, int height)
		{
			var size = ((float)height > width ? width : height) * 0.75f;
			var R = 0.45f * size;
			var TAU = 6.2831853f;

			using (var path = new SKPath ()) {
				path.MoveTo (R, 0.0f);
				for (int i = 1; i < 7; ++i) {
					var theta = 3f * i * TAU / 7f;
					path.LineTo (R * (float)Math.Cos (theta), R * (float)Math.Sin (theta));
				}
				path.Close ();

				using (var paint = new SKPaint ()) {
					paint.IsAntialias = true;
					canvas.Clear (SKColors.White);
					canvas.Translate (width / 2f, height / 2f);
					canvas.DrawPath (path, paint);
				}
			}
		}

		public static void ManageDrawMatrix (SKCanvas canvas, int width, int height)
		{
			var size = ((float)height > width ? width : height) * 0.5f;
			var center = new SKPoint ((width - size) / 2f, (height - size) / 2f);

			// draw these at specific locations
			var leftRect = SKRect.Create (center.X - size / 2f, center.Y, size, size);
			var rightRect = SKRect.Create (center.X + size / 2f, center.Y, size, size);

			// draw this at the current location / transformation
			var rotatedRect = SKRect.Create (0f, 0f, size, size);

			using (var paint = new SKPaint ()) {
				paint.IsAntialias = true;
				canvas.Clear (XamPurple);

				// draw
				paint.Color = XamDkBlue;
				canvas.DrawRect (leftRect, paint);

				// save
				canvas.Save();

				// transform
				canvas.Translate (width / 2f, center.Y);
				canvas.RotateDegrees (45);

				// draw
				paint.Color = XamGreen;
				canvas.DrawRect (rotatedRect, paint);

				// undo transform / restore
				canvas.Restore();

				// draw
				paint.Color = XamLtBlue;
				canvas.DrawRect (rightRect, paint);
			}
		}

		public static void CustomFonts (SKCanvas canvas, int width, int height)
		{
			string text = "\u03A3 and \u0750";

			using (var paint = new SKPaint ()) {
				canvas.Clear (SKColors.White);

				using (var tf = SKTypeface.FromFile (CustomFontPath)) {
					paint.TextSize = 40;
					paint.Typeface = tf;

					canvas.DrawText (text, 50, 50, paint);
				}

				using (var stream = new SKFileStream (CustomFontPath))
				using (var tf = SKTypeface.FromStream (stream)) {
					paint.Color = XamDkBlue;
					paint.TextSize = 40;
					paint.Typeface = tf;

					canvas.DrawText (text, 50, 100, paint);
				}

				var assembly = typeof(Demos).GetTypeInfo ().Assembly;
				var fontName = assembly.GetName ().Name + ".weblysleekuil.ttf";

				using (var resource = assembly.GetManifestResourceStream (fontName))
				using (var memory = new MemoryStream ()) {
					resource.CopyTo (memory);
					var bytes = memory.ToArray ();
					using (var stream = new SKMemoryStream (bytes))
					using (var tf = SKTypeface.FromStream (stream)) {
						paint.Color = XamLtBlue;
						paint.TextSize = 40;
						paint.Typeface = tf;

						canvas.DrawText (text, 50, 150, paint);
					}
				}

				using (var resource = assembly.GetManifestResourceStream (fontName))
				using (var stream = new SKManagedStream (resource))
				using (var tf = SKTypeface.FromStream (stream)) {
					paint.Color = XamLtBlue;
					paint.TextSize = 40;
					paint.Typeface = tf;

					canvas.DrawText (text, 50, 200, paint);
				}
			}
		}

		public static void Xfermode (SKCanvas canvas, int width, int height)
		{
			var modes = Enum.GetValues (typeof(SKXferMode)).Cast<SKXferMode> ().ToArray ();

			var cols = width < height ? 3 : 5;
			var rows = (modes.Length - 1) / cols + 1;

			var w = width / cols;
			var h = (float)height / rows;
			var rect = SKRect.Create (w, h);
			var srcPoints = new[] {
				new SKPoint (0.0f, 0.0f),
				new SKPoint (w, 0.0f)
			};
			var srcColors = new [] {
				SKColors.Magenta.WithAlpha (0),
				SKColors.Magenta
			};
			var dstPoints = new [] {
				new SKPoint (0.0f, 0.0f),
				new SKPoint (0.0f, h)
			};
			var dstColors = new [] {
				SKColors.Cyan.WithAlpha (0),
				SKColors.Cyan
			};

			using (var text = new SKPaint ())
			using (var stroke = new SKPaint ())
			using (var src = new SKPaint ())
			using (var dst = new SKPaint ())
			using (var srcShader = SKShader.CreateLinearGradient (srcPoints [0], srcPoints [1], srcColors, null, SKShaderTileMode.Clamp))
			using (var dstShader = SKShader.CreateLinearGradient (dstPoints [0], dstPoints [1], dstColors, null, SKShaderTileMode.Clamp)) {
				text.TextSize = 12.0f;
				text.IsAntialias = true;
				text.TextAlign = SKTextAlign.Center;
				stroke.IsStroke = true;
				src.Shader = srcShader;
				dst.Shader = dstShader;

				canvas.Clear (SKColors.White);

				for (var i = 0; i < modes.Length; ++i) {
					using (new SKAutoCanvasRestore (canvas, true)) {
						canvas.Translate (w * (i / rows), h * (i % rows));

						canvas.ClipRect (rect);
						canvas.DrawColor (SKColors.LightGray);

						canvas.SaveLayer (null);
						canvas.Clear (SKColors.Transparent);
						canvas.DrawPaint (dst);

						src.XferMode = modes [i];
						canvas.DrawPaint (src);
						canvas.DrawRect (rect, stroke);

						var desc = modes [i].ToString ();
						canvas.DrawText (desc, w / 2f, h / 2f, text);
					}
				}
			}
		}

		[Flags]
		public enum Platform
		{
			iOS = 1,
			Android = 2,
			OSX = 4,
			All = 0xFFFF,
		}

		class Sample 
		{
			public string Title { get; set; }
			public Action <SKCanvas, int, int> Method { get; set; }
			public Platform Platform { get; set; }
		}

		public static string [] SamplesForPlatform (Platform platform)
		{
			return sampleList.Where (s => 0 != (s.Platform & platform)).Select (s => s.Title).ToArray ();
		}

		public static Action <SKCanvas, int, int> MethodForSample (string title)
		{
			return sampleList.Where (s => s.Title == title).First ().Method;
		}

		public static string CustomFontPath { get; set; }

		static Sample [] sampleList = new Sample[] {
			new Sample {Title="Xamagon", Method = DrawXamagon, Platform = Platform.All},
			new Sample {Title="Text Sample", Method = TextSample, Platform = Platform.All},
			new Sample {Title="Gradient Sample", Method = DrawGradient, Platform = Platform.All},
			new Sample {Title="Unicode Text", Method = UnicodeText, Platform = Platform.All},
			new Sample {Title="Filled Heptagram", Method = FilledHeptagram, Platform = Platform.All},
			new Sample {Title="Manage Draw Matrix", Method = ManageDrawMatrix, Platform = Platform.All},
			new Sample {Title="Custom Fonts", Method = CustomFonts, Platform = Platform.All},
			new Sample {Title="Xfermode", Method = Xfermode, Platform = Platform.All},
		};
	}
}

