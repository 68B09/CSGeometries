/*
The MIT License (MIT)

Copyright (c) 2016 ZZO.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
using System.Drawing;

namespace CSGeometries.ColorModels
{
	/// <summary>
	/// Double型Colorクラス
	/// </summary>
	/// <remarks>
	/// R,G,B各要素を0～1.0の範囲で表現する。
	/// </remarks>
	public struct ColorD
	{
		/// <summary>
		/// Red
		/// </summary>
		public double R { get; set; }

		/// <summary>
		/// Green
		/// </summary>
		public double G { get; set; }

		/// <summary>
		/// Blue
		/// </summary>
		public double B { get; set; }

		/// <summary>
		/// null値判定
		/// </summary>
		/// <returns>true=初期値(全色=0.0)</returns>
		public bool IsEmpty
		{
			get {
				return (this.R == 0.0) && (this.G == 0.0) && (this.B == 0.0);
			}
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="pR">Red</param>
		/// <param name="pG">Green</param>
		/// <param name="pB">Blue</param>
		/// <remarks>
		/// 各要素は0～1.0の範囲であること。
		/// </remarks>
		public ColorD(double pR, double pG, double pB)
		{
			this.R = pR;
			this.G = pG;
			this.B = pB;
		}

		/// <summary>
		/// 任意範囲RGBより生成
		/// </summary>
		/// <param name="pR">Red</param>
		/// <param name="pG">Green</param>
		/// <param name="pB">Blue</param>
		/// <param name="pMax">pR,pG,pBが取り得る最大値</param>
		/// <returns>ColorD構造体</returns>
		/// <remarks>
		/// 0～pMaxの範囲で表現するRGBを元にColorD構造体を作成する。
		/// </remarks>
		public static ColorD FromRGB(int pR, int pG, int pB, int pMax)
		{
			return new ColorD((double)pR / pMax, (double)pG / pMax, (double)pB / pMax);
		}

		/// <summary>
		/// Colorより生成
		/// </summary>
		/// <param name="pRGB"></param>
		/// <returns>ColorD構造体</returns>
		/// <remarks>
		/// Color構造体のRGB値を元にColorD構造体を作成する。
		/// Color構造体のRGB各値は0～255の範囲で表現するため、各色が255で除算された値が初期値となる。
		/// </remarks>
		public static ColorD FromColor(System.Drawing.Color pRGB)
		{
			return new ColorD(pRGB.R / 255.0, pRGB.G / 255.0, pRGB.B / 255.0);
		}

		/// <summary>
		/// HSVより生成
		/// </summary>
		/// <param name="pHSV">HSV値</param>
		/// <returns>ColorD構造体</returns>
		public static ColorD FromHSV(HSV pHSV)
		{
			double r = 0.0;
			double g = 0.0;
			double b = 0.0;

			double h = pHSV.H;
			double s = pHSV.S;
			double v = pHSV.V;

			h /= 60.0;
			int i = (int)Math.Truncate(h);
			double f = h % 1.0;
			double p1 = v * (1.0 - s);
			double p2 = v * (1.0 - s * f);
			double p3 = v * (1.0 - s * (1.0 - f));
			switch (i) {
				case 0:
					r = v;
					g = p3;
					b = p1;
					break;

				case 1:
					r = p2;
					g = v;
					b = p1;
					break;

				case 2:
					r = p1;
					g = v;
					b = p3;
					break;

				case 3:
					r = p1;
					g = p2;
					b = v;
					break;

				case 4:
					r = p3;
					g = p1;
					b = v;
					break;

				case 5:
					r = v;
					g = p1;
					b = p2;
					break;
			}

			return new ColorD(r, g, b);
		}

		/// <summary>
		/// Color構造体生成
		/// </summary>
		/// <returns>Color構造体</returns>
		/// <remarks>
		/// 現在の値を元にColor構造体を作成する。
		/// </remarks>
		public Color ToColor()
		{
			return Color.FromArgb((int)(this.R * 255), (int)(this.G * 255), (int)(this.B * 255));
		}

		/// <summary>
		/// 飽和(正規化)
		/// </summary>
		/// <remarks>
		/// 各色が範囲内となるように調整する。
		/// </remarks>
		public void Saturation()
		{
			this.R = Geometry.Saturation(this.R);
			this.G = Geometry.Saturation(this.G);
			this.B = Geometry.Saturation(this.B);
		}

		/// <summary>
		/// 色距離取得
		/// </summary>
		/// <returns>距離</returns>
		/// <remarks>
		/// 近似色を求めることを想定した単純な色距離を返す
		/// </remarks>
		public double GetLength()
		{
			return Math.Sqrt((this.R * this.R) + (this.G * this.G) + (this.B * this.B));
		}

		/// <summary>
		/// Equality演算子
		/// </summary>
		/// <param name="left">比較対象1</param>
		/// <param name="right">比較対象2</param>
		/// <returns>true=同一(各色が一致する)</returns>
		public static bool operator ==(ColorD left, ColorD right)
		{
			return left.Equals(right);
		}

		/// <summary>
		/// Inequality演算子
		/// </summary>
		/// <param name="left">比較対象1</param>
		/// <param name="right">比較対象2</param>
		/// <returns>true=異なる(いずれかの色、もしくは全色が一致しない)</returns>
		public static bool operator !=(ColorD left, ColorD right)
		{
			return !left.Equals(right);
		}

		/// <summary>
		/// 等価チェック
		/// </summary>
		/// <param name="obj">比較対象</param>
		/// <returns>true=同一</returns>
		/// <remarks>
		/// R,G,B各色の一致を判定する。
		/// </remarks>
		public override bool Equals(object obj)
		{
			if (obj == null) {
				return false;
			}

			if ((obj is ColorD) == false) {
				return false;
			}

			ColorD target = (ColorD)obj;

			if ((this.R != target.R) || (this.G != target.G) || (this.B != target.B)) {
				return false;
			}
			return true;
		}

		/// <summary>
		/// ハッシュコード取得
		/// </summary>
		/// <returns>ハッシュコード</returns>
		public override int GetHashCode()
		{
			return this.R.GetHashCode() ^ this.G.GetHashCode() ^ this.B.GetHashCode();
		}

		/// <summary>
		/// 文字列取得
		/// </summary>
		/// <returns>文字列</returns>
		public override string ToString()
		{
			return string.Format("ColorD [R={0}, G={1}, B={2}]", this.R, this.G, this.B);
		}
	}
}
