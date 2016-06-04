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

namespace CSGeometries
{
	/// <summary>
	/// 線分クラス
	/// </summary>
	public class Line
	{
		/// <summary>
		/// 点１
		/// </summary>
		private System.Drawing.Point p1;

		/// <summary>
		/// 点１取得･設定
		/// </summary>
		public System.Drawing.Point P1
		{
			get {
				return this.p1;
			}

			set {
				this.p1 = value;
			}
		}

		/// <summary>
		/// 点２
		/// </summary>
		private System.Drawing.Point p2;

		/// <summary>
		/// 点２取得･設定
		/// </summary>
		public System.Drawing.Point P2
		{
			get {
				return this.p2;
			}

			set {
				this.p2 = value;
			}
		}

		/// <summary>
		/// 点１X座標取得･設定
		/// </summary>
		public int X1
		{
			get {
				return this.P1.X;
			}

			set {
				p1.X = value;
			}
		}

		/// <summary>
		/// 点１Y座標取得･設定
		/// </summary>
		public int Y1
		{
			get {
				return this.P1.Y;
			}

			set {
				p1.Y = value;
			}
		}

		/// <summary>
		/// 点２X座標取得･設定
		/// </summary>
		public int X2
		{
			get {
				return this.P2.X;
			}

			set {
				p2.X = value;
			}
		}

		/// <summary>
		/// 点２Y座標取得･設定
		/// </summary>
		public int Y2
		{
			get {
				return this.P2.Y;
			}

			set {
				p2.Y = value;
			}
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Line()
		{
			this.P1 = new System.Drawing.Point(0, 0);
			this.P2 = new System.Drawing.Point(0, 0);
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="pSrc">コピー元</param>
		public Line(Line pSrc)
		{
			this.P1 = new System.Drawing.Point(pSrc.p1.X, pSrc.p1.Y);
			this.P2 = new System.Drawing.Point(pSrc.p2.X, pSrc.p2.Y);
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="px1">点1X座標</param>
		/// <param name="py1">点1Y座標</param>
		/// <param name="px2">点2X座標</param>
		/// <param name="py2">点2Y座標</param>
		public Line(int px1, int py1, int px2, int py2)
		{
			this.P1 = new System.Drawing.Point(px1, py1);
			this.P2 = new System.Drawing.Point(px2, py2);
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="p1">点1座標</param>
		/// <param name="p2">点2座標</param>
		public Line(System.Drawing.Point p1, System.Drawing.Point p2)
		{
			this.P1 = p1;
			this.P2 = p2;
		}

		/// <summary>
		/// 線分長取得
		/// </summary>
		/// <returns>線分長</returns>
		public int Length()
		{
			int dx = (this.p1.X - this.p2.X);
			int dy = (this.p1.Y - this.p2.Y);
			return (int)Math.Sqrt((dx * dx) + (dy * dy));
		}

		/// <summary>
		/// 線分長取得(long)
		/// </summary>
		/// <returns>線分長</returns>
		public long LengthL()
		{
			long dx = ((long)this.p1.X - this.p2.X);
			long dy = ((long)this.p1.Y - this.p2.Y);
			return (long)Math.Sqrt((dx * dx) + (dy * dy));
		}

		/// <summary>
		/// 線分長取得(double)
		/// </summary>
		/// <returns>線分長</returns>
		public double LengthD()
		{
			double dx = ((double)this.p1.X - this.p2.X);
			double dy = ((double)this.p1.Y - this.p2.Y);
			return Math.Sqrt((dx * dx) + (dy * dy));
		}

		/// <summary>
		/// 最小・最大値整合
		/// </summary>
		/// <returns>this</returns>
		/// <remarks>
		/// P1に最小値、P2に最大値を設定する。
		/// 対角線で矩形領域を表している場合を想定。
		/// </remarks>
		public Line MarshalMaxmin()
		{
			int wk;

			if (this.X1 > this.X2) {
				wk = this.X1;
				this.X1 = this.X2;
				this.X2 = wk;
			}

			if (this.Y1 > this.Y2) {
				wk = this.Y1;
				this.Y1 = this.Y2;
				this.Y2 = wk;
			}

			return this;
		}

		/// <summary>
		/// Equality演算子
		/// </summary>
		/// <param name="left">比較対象1</param>
		/// <param name="right">比較対象2</param>
		/// <returns>true=同一(各色が一致する)</returns>
		public static bool operator ==(Line left, Line right)
		{
			return left.Equals(right);
		}

		/// <summary>
		/// Inequality演算子
		/// </summary>
		/// <param name="left">比較対象1</param>
		/// <param name="right">比較対象2</param>
		/// <returns>true=異なる(いずれかの色、もしくは全色が一致しない)</returns>
		public static bool operator !=(Line left, Line right)
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

			if ((obj is Line) == false) {
				return false;
			}

			Line target = (Line)obj;

			if (this.p1.Equals(target.p1) && this.p2.Equals(target.p2)) {
				return true;
			}

			return false;
		}

		/// <summary>
		/// ハッシュコード取得
		/// </summary>
		/// <returns>ハッシュコード</returns>
		public override int GetHashCode()
		{
			return this.p1.GetHashCode() ^ this.p2.GetHashCode();
		}

		/// <summary>
		/// 文字列取得
		/// </summary>
		/// <returns>文字列</returns>
		public override string ToString()
		{
			return string.Format("Line {{X1={0}, Y1={1}, X2={2}, Y2={3}{4}", this.X1, this.Y1, this.X2, this.Y2, '}');
		}
	}
}
