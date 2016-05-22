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

namespace CSGeometries.ColorModels
{
	/// <summary>
	/// HSVColorクラス
	/// </summary>
	/// <remarks>
	/// 色をH(色相 hue 0～360),S(彩度 saturation 0～1.0),V(強度 value 0～1.0)で表すHSV円柱モデルクラス。
	/// </remarks>
	public struct HSV
	{
		/// <summary>
		/// Hue
		/// </summary>
		public double H { get; set; }

		/// <summary>
		/// Saturation
		/// </summary>
		public double S { get; set; }

		/// <summary>
		/// Value
		/// </summary>
		public double V { get; set; }

		/// <summary>
		/// null値判定
		/// </summary>
		/// <returns>true=初期値(全要素=0.0)</returns>
		public bool IsEmpty()
		{
			return (this.H == 0.0) && (this.S == 0.0) && (this.V == 0.0);
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="pH">色相Hue</param>
		/// <param name="pS">彩度Saturation</param>
		/// <param name="pV">強度Value</param>
		public HSV(double pH, double pS, double pV)
		{
			this.H = pH;
			this.S = pS;
			this.V = pV;
		}

		/// <summary>
		/// ColorDより生成
		/// </summary>
		/// <param name="pColorD">ColorD構造体</param>
		/// <returns>HSV構造体</returns>
		public static HSV FromColorD(ColorD pColorD)
		{
			double h, s, v;

			h = 0.0;
			v = Math.Max(Math.Max(pColorD.R, pColorD.G), pColorD.B);
			double min = Math.Min(Math.Min(pColorD.R, pColorD.G), pColorD.B);

			double diff = v - min;
			if (v == 0.0) {
				s = 0.0;
			} else {
				s = diff / v;
			}

			if (s == 0.0) {
				h = 0.0;
				return new HSV(h, s, v);
			}

			if (pColorD.R == v) {
				h = (pColorD.G - pColorD.B) / diff;
			} else if (pColorD.G == v) {
				h = 2.0 + (pColorD.B - pColorD.R) / diff;
			} else if (pColorD.B == v) {
				h = 4.0 + (pColorD.R - pColorD.G) / diff;
			}

			h *= 60.0;
			if (h < 0.0) {
				h += 360.0;
			}

			return new HSV(h, s, v);
		}

		/// <summary>
		/// 飽和(正規化)
		/// </summary>
		/// <remarks>
		/// 各要素が範囲内となるように調整する。
		/// </remarks>
		public void Saturation()
		{
			this.H %= 360.0;
			if (this.H < 0.0) {
				this.H += 360.0;
			}
			this.S = Geometry.Saturation(this.S);
			this.V = Geometry.Saturation(this.V);
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
			return Math.Sqrt((this.H * this.H) + (this.S * this.S) + (this.V * this.V));
		}

		/// <summary>
		/// Equality演算子
		/// </summary>
		/// <param name="left">比較対象1</param>
		/// <param name="right">比較対象2</param>
		/// <returns>true=同一(各要素が一致する)</returns>
		public static bool operator ==(HSV left, HSV right)
		{
			return left.Equals(right);
		}

		/// <summary>
		/// Inequality演算子
		/// </summary>
		/// <param name="left">比較対象1</param>
		/// <param name="right">比較対象2</param>
		/// <returns>true=異なる(いずれかの要素、もしくは全要素が一致しない)</returns>
		public static bool operator !=(HSV left, HSV right)
		{
			return !left.Equals(right);
		}

		/// <summary>
		/// 等価チェック
		/// </summary>
		/// <param name="obj">比較対象</param>
		/// <returns>true=同一</returns>
		/// <remarks>
		/// 全要素の一致を判定する。
		/// </remarks>
		public override bool Equals(object obj)
		{
			if (obj == null) {
				return false;
			}

			if ((obj is HSV) == false) {
				return false;
			}

			HSV target = (HSV)obj;

			if ((this.H != target.H) || (this.S != target.S) || (this.V != target.V)) {
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
			return this.H.GetHashCode() ^ this.S.GetHashCode() ^ this.V.GetHashCode();
		}

		/// <summary>
		/// 文字列取得
		/// </summary>
		/// <returns>文字列</returns>
		public override string ToString()
		{
			return string.Format("HSV [H={0}, S={1}, V={2}]", this.H, this.S, this.V);
		}
	}
}
